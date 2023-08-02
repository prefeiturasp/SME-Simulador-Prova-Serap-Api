using Dapper;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioProvaLegado : IRepositorioProvaLegado
{
    private readonly GestaoAvaliacaoContexto gestaoAvaliacaoContexto;

    public RepositorioProvaLegado(GestaoAvaliacaoContexto gestaoAvaliacaoContexto)
    {
        this.gestaoAvaliacaoContexto = gestaoAvaliacaoContexto ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContexto));
    }

    public async Task<IEnumerable<ProvaLegadoDto>> ObterProvasEVersaoItemPorQuestaoCodigoEProvasIdAsync(string questaoCodigo, long[] provasId )
    {
          const string query = @"
								select distinct  t.id,
                                    i.id as questaoId,
                                    t.Description as descricao,
                                    t.ApplicationStartDate as datainicioaplicacao,
                             	    i.ItemVersion as versao,
                             	    d.Description as componenteCurricular   
                                from test t with (NOLOCK)
                                inner join discipline d on t.Discipline_id = d.Id
                                inner join Item i on i.ItemCode = @questaoCodigo
                                inner join BlockChainItem bci on bci.Item_id = i.id
                                inner join BlockChain bc with (NOLOCK) on bc.Id = bci.BlockChain_Id and bc.test_id = t.id
                                where t.State = @state
								  and i.State = @state
								  and t.id in @provasId
								  and bci.State = @state
								  and bc.State = @state";

        return await gestaoAvaliacaoContexto.Conexao.QueryAsync<ProvaLegadoDto>(query,
            new
            {
                questaoCodigo,
                provasId,
                state = (int)LegadoState.Ativo
            }, transaction: gestaoAvaliacaoContexto.Transacao);
    }

    public async Task<IEnumerable<ProvaLegadoDto>> ObterProvasPorQuestaoParaSeremSincronizadasAsync(
        FiltroProvasParaSeremSincronizadasDto filtro)
    {
        const string query = @"select distinct t.id,
                                    t.Description as descricao,
                                    t.ApplicationStartDate as datainicioaplicacao
                                from test t with (NOLOCK)
                                left join TestPermission tp with (NOLOCK) on tp.Test_Id = t.Id
                                    and tp.gru_id = 'BD6D9CE6-9456-E711-9541-782BCB3D218E'
                                where (t.UpdateDate > @ultimaAtualizacao or tp.UpdateDate > @ultimaAtualizacao)
                                and  t.ApplicationStartDate >= getDate()
                                and t.State = 1
                                and (EXISTS (select bi.Id
                                                from BlockItem bi with (NOLOCK)
                                                inner join Block b with (NOLOCK) on b.Id = bi.Block_Id
                                                inner join Item i with (NOLOCK) on i.id  = bi.Item_Id
					                            where i.itemCode =  @questaoCodigo
											    and i.state = @state
                                                and b.Test_Id = t.Id
                                                and bi.State = @state
                                                and b.State = @state)
                                    or EXISTS (select bci.Id
                                                from BlockChainItem bci with (NOLOCK)
                                                inner join BlockChain bc with (NOLOCK) on bc.Id = bci.BlockChain_Id
                                               inner join Item i with (NOLOCK) on i.id  = bci.Item_Id
					                             where i.itemCode =  @questaoCodigo
											    and i.state = @state
                                                and bc.Test_Id = t.Id
                                                and bci.State = @state
                                                and bc.State = @state))
                                order by t.ApplicationStartDate, t.Id, t.Description desc";

        return await gestaoAvaliacaoContexto.Conexao.QueryAsync<ProvaLegadoDto>(query,
            new
            {
                questaoCodigo = filtro.QuestaoCodigo,
                ultimaAtualizacao = filtro.UltimaAtualizacao,
                state = (int)LegadoState.Ativo
            }, transaction: gestaoAvaliacaoContexto.Transacao);
    }

    public async Task<bool> EhProvaIniciadaAsync(long provaId)
    {
        const string query = @"select top 1 t.Id
                                from Test t
                                where t.Id = @provaId
                                and t.State = @state
                                and CAST(GETDATE() AS DATE) > CAST(t.ApplicationStartDate AS DATE) 
                                and CAST(GETDATE() AS DATE) <= CAST(t.ApplicationEndDate AS DATE)
                                order by t.Id";

        var id = await gestaoAvaliacaoContexto.Conexao.QuerySingleOrDefaultAsync<long>(query,
            new { provaId, state = (int)LegadoState.Ativo },
            transaction: gestaoAvaliacaoContexto.Transacao);

        return id > 0;
    }

    public async Task<IEnumerable<ProvaLegadoDto>> ObterProvasNaoIniciadasPorQuestaoIdAsync(string questaoCodigo)
    {
        const string query = @"select distinct t.id,
                                    t.Description as descricao,
                                    t.ApplicationStartDate as datainicioaplicacao
                                from test t with (NOLOCK)
                                where DATEADD(d,DATEDIFF(d,0,getdate()),0) <= t.ApplicationStartDate
                                and t.State = @state
                                and (EXISTS (select bi.Id
                                                from BlockItem bi with (NOLOCK)
                                                inner join Block b with (NOLOCK) on b.Id = bi.Block_Id
                                                inner join Item i with (NOLOCK) on i.id  = bi.Item_Id
					                            where i.itemCode =  @questaoCodigo
                                                and i.state = @state
                                                and b.Test_Id = t.Id
                                                and bi.State = @state
                                                and b.State = @state)
                                    or EXISTS (select bci.Id
                                                from BlockChainItem bci with (NOLOCK)
                                                inner join BlockChain bc with (NOLOCK) on bc.Id = bci.BlockChain_Id
                                                  inner join Item i with (NOLOCK) on i.id  = bci.Item_Id
						                        where i.itemCode =  @questaoCodigo
                                                and i.state = @state
                                                and bc.Test_Id = t.Id
                                                and bci.State = @state
                                                and bc.State = @state))
                                order by t.ApplicationStartDate, t.Id, t.Description desc";

        return await gestaoAvaliacaoContexto.Conexao.QueryAsync<ProvaLegadoDto>(query,
            new
            {
                questaoCodigo,
                state = (int)LegadoState.Ativo
            }, transaction: gestaoAvaliacaoContexto.Transacao);
    }

    public async Task<bool> EhProvaBib(long provaId)
    {
        const string query = @"select top 1 t.Bib
                                from Test t
                                where t.Id = @provaId
                                and t.State = @state";

        var bib = await gestaoAvaliacaoContexto.Conexao.QuerySingleOrDefaultAsync<long>(query,
            new { provaId, state = (int)LegadoState.Ativo },
            transaction: gestaoAvaliacaoContexto.Transacao);

        return bib > 0;
    }
}