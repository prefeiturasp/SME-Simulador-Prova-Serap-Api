using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterListaQuestaoGradesCurricularesQueryHandler : IRequestHandler<ObterListaQuestaoGradesCurricularesQuery, IEnumerable<QuestaoGradeCurricular>>
{
    private readonly IRepositorioQuestaoGradeCurricular repositorioQuestaGradeCurricular;
    
    public ObterListaQuestaoGradesCurricularesQueryHandler(IRepositorioQuestaoGradeCurricular repositorioQuestaGradeCurricular)
    {
        this.repositorioQuestaGradeCurricular = repositorioQuestaGradeCurricular ?? throw new ArgumentNullException(nameof(repositorioQuestaGradeCurricular));
    }
    
    public async Task<IEnumerable<QuestaoGradeCurricular>> Handle(ObterListaQuestaoGradesCurricularesQuery request, CancellationToken cancellationToken)
    {
        return await repositorioQuestaGradeCurricular.ObterListaQuestaoGradesCurriculares(request.QuestaoId);
    }
}