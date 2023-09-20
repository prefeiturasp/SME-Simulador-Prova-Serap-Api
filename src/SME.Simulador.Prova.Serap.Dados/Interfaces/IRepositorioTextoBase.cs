using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioTextoBase : IRepositorioBase<TextoBase>
{
    public Task<long> InserirTextoBase(TextoBase entidade);
}