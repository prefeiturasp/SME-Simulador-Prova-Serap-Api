using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public interface IAutenticarUsuarioUseCase : IUseCase<AutenticacaoDto, AutenticacaoValidarDto>
{
}