using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioUsuarioSerapCoreSso : IRepositorioUsuarioSerapCoreSso
{
    private readonly SerapEstudantesContexto serapEstudantesContexto;

    public RepositorioUsuarioSerapCoreSso(SerapEstudantesContexto serapEstudantesContexto)
    {
        this.serapEstudantesContexto = serapEstudantesContexto ?? throw new ArgumentNullException(nameof(serapEstudantesContexto));
    }

    public async Task<UsuarioSerapCoreSso> ObterPorLoginAsync(string login)
    {
        const string query = @"select id, 
                                    id_coresso, 
                                    login, 
                                    nome, 
                                    criado_em, 
                                    atualizado_em 
                                from usuario_serap_coresso 
                                where login = @login";

        return await serapEstudantesContexto.Conexao.QueryFirstOrDefaultAsync<UsuarioSerapCoreSso>(query, new { login },
            transaction: serapEstudantesContexto.Transacao);
    }
}