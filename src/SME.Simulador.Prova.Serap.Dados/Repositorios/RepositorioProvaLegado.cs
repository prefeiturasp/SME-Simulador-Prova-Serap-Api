﻿using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioProvaLegado : IRepositorioProvaLegado
{
    private readonly GestaoAvaliacaoContexto gestaoAvaliacaoContexto;

    public RepositorioProvaLegado(GestaoAvaliacaoContexto gestaoAvaliacaoContexto)
    {
        this.gestaoAvaliacaoContexto = gestaoAvaliacaoContexto ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContexto));
    }

    public async Task<IEnumerable<ProvaLegadoDto>> ObterProvasPorQuestaoIdAsync(long questaoId)
    {
        const string query = @"select distinct t.id,
                                    t.Description as descricao,
                                    t.ApplicationStartDate as datainicioaplicacao
                                from test t with (NOLOCK)
                                left join TestPermission tp with (NOLOCK) on tp.Test_Id = t.Id
                                    and tp.gru_id = 'BD6D9CE6-9456-E711-9541-782BCB3D218E'
                                where t.State = @state
                                and (EXISTS (select bi.Id
                                                from BlockItem bi with (NOLOCK)
                                                inner join Block b with (NOLOCK) on b.Id = bi.Block_Id
                                                where bi.Item_Id = @questaoId
                                                and b.Test_Id = t.Id
                                                and bi.State = @state
                                                and b.State = @state)
                                    or EXISTS (select bci.Id
                                                from BlockChainItem bci with (NOLOCK)
                                                inner join BlockChain bc with (NOLOCK) on bc.Id = bci.BlockChain_Id
                                                where bci.Item_Id = @questaoId
                                                and bc.Test_Id = t.Id
                                                and bci.State = @state
                                                and bc.State = @state))
                                order by t.ApplicationStartDate, t.Id, t.Description desc";

        return await gestaoAvaliacaoContexto.Conexao.QueryAsync<ProvaLegadoDto>(query,
            new
            {
                questaoId,
                state = (int)LegadoStatus.Ativo
            }, transaction: gestaoAvaliacaoContexto.Transacao);
    }

    public async Task<IEnumerable<ProvaLegadoDto>> ObterProvasPorQuestaoParaSeremSincronizadasAsync(FiltroProvasParaSeremSincronizadasDto filtro)
    {
        const string query = @"select distinct t.id,
                                    t.Description as descricao,
                                    t.ApplicationStartDate as datainicioaplicacao
                                from test t with (NOLOCK)
                                left join TestPermission tp with (NOLOCK) on tp.Test_Id = t.Id
                                    and tp.gru_id = 'BD6D9CE6-9456-E711-9541-782BCB3D218E'
                                where (t.UpdateDate > @ultimaAtualizacao or tp.UpdateDate > @ultimaAtualizacao)
                                and t.State = @state
                                and (EXISTS (select bi.Id
                                                from BlockItem bi with (NOLOCK)
                                                inner join Block b with (NOLOCK) on b.Id = bi.Block_Id
                                                where bi.Item_Id = @questaoId
                                                and b.Test_Id = t.Id
                                                and bi.State = @state
                                                and b.State = @state)
                                    or EXISTS (select bci.Id
                                                from BlockChainItem bci with (NOLOCK)
                                                inner join BlockChain bc with (NOLOCK) on bc.Id = bci.BlockChain_Id
                                                where bci.Item_Id = @questaoId
                                                and bc.Test_Id = t.Id
                                                and bci.State = @state
                                                and bc.State = @state))
                                order by t.ApplicationStartDate, t.Id, t.Description desc";
        
        return await gestaoAvaliacaoContexto.Conexao.QueryAsync<ProvaLegadoDto>(query,
            new
            {
                questaoId = filtro.QuestaoId,
                ultimaAtualizacao = filtro.UltimaAtualizacao,
                state = (int)LegadoStatus.Ativo
            }, transaction: gestaoAvaliacaoContexto.Transacao);        
    }
}