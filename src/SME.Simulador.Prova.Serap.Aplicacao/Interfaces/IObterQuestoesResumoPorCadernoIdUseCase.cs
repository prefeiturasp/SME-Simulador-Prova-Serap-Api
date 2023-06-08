using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public interface IObterQuestoesResumoPorCadernoIdUseCase : IUseCase<long, IEnumerable<QuestaoResumoDto>>
{
}