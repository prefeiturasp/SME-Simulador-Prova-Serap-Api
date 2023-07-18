using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra.Dtos.Parametros;

namespace SME.Simulador.Prova.Serap.Aplicacao.Interfaces;

public interface IGerarNovaVersaoQuestaoUseCase : IUseCase<ParametrosQuestaoSalvarDto, bool>
{
}