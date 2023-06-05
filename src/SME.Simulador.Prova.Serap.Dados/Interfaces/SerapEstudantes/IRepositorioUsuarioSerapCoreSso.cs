using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioUsuarioSerapCoreSso
{
    Task<UsuarioSerapCoreSso> ObterPorLoginAsync(string login);
}