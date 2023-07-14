using MediatR;
using SME.Simulador.Prova.Serap.Dados;


namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class GerarNovaVersaoQuestaoCommandHandler : IRequestHandler<GerarNovaVersaoQuestaoCommand, long>
    {
        private readonly IRepositorioQuestao repositorioQuestao;

        public GerarNovaVersaoQuestaoCommandHandler(IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao;
        }

        public async Task<long> Handle(GerarNovaVersaoQuestaoCommand request, CancellationToken cancellationToken)
        {
            return await repositorioQuestao.SalvarAsync(request.Questao) ;
        }
    }
}
