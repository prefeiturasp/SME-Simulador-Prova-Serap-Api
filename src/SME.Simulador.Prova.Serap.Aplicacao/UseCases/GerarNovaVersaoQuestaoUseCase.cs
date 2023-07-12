using MediatR;
using SME.Simulador.Prova.Serap.Aplicacao.Commands.Questao.GerarNovaVersaoQuestao;
using SME.Simulador.Prova.Serap.Aplicacao.Commands.TextoBase.Salvar;
using SME.Simulador.Prova.Serap.Aplicacao.Interfaces;
using SME.Simulador.Prova.Serap.Aplicacao.Queries.Questao.ObterQuestaoPorId;
using SME.Simulador.Prova.Serap.Aplicacao.Queries.VerificaSeEhProvaBibPorProvaId;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra.Dtos;
using SME.Simulador.Prova.Serap.Infra.Dtos.Parametros;
using StackExchange.Redis;


namespace SME.Simulador.Prova.Serap.Aplicacao.UseCases
{
    public class GerarNovaVersaoQuestaoUseCase : AbstractUseCase, IGerarNovaVersaoQuestaoUseCase
    {
        public GerarNovaVersaoQuestaoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> ExecutarAsync(ParametrosQuestaoSalvar request)
        {
            // Obter item
            var questaoAtual = await mediator.Send(new ObterQuestaoPorIdQuery(request.Questao.Id)); ;
            var textoBaseQuestao = await mediator.Send(new ObterTextoBasePorIdQuery(questaoAtual.TextoBaseId));
            if (textoBaseQuestao?.Descricao != request.Questao.TextoBase)
            {
                var idNovoTextoBase = await IncluiNovoTextoBase(request, textoBaseQuestao);
            }

            Questao questaoNovaVersao = NovaVersaoQuestaoMap(request, questaoAtual);
            var NovaVersaoQuestaoId = await mediator.Send(new GerarNovaVersaoQuestaoCommand(questaoNovaVersao));

            foreach (var alternativaDto in request.Alternativas)
            {
                var alternativa = await mediator.Send(new ObterAlternativasPorIdQuery(alternativaDto.Id));

                var entidadeAlternativa = new Alternativa()
                {
                    Correta = alternativa.Correta,
                    DataCriacao = DateTime.Now,
                    Descricao = alternativaDto.Descricao,
                    DiscriminaçãoTCT = alternativa.DiscriminaçãoTCT,
                    Justificativa = alternativa.Justificativa,
                    Numeracao = alternativa.Numeracao,
                    Ordem = alternativa.Ordem,
                    Situacao = alternativa.Situacao,
                    TCTCoeficienteBisserial = alternativa.TCTCoeficienteBisserial,
                    TCTDificuldade = alternativa.TCTDificuldade,
                    ItemId = NovaVersaoQuestaoId,


                };
                await mediator.Send(new IncluirAlternativaCommand(entidadeAlternativa));
            }
            foreach (var provaId in request.ProvasId)
            {
                var provaBib = await mediator.Send(new VerificaSeEhProvaBibQuery(provaId));

                if (provaBib)
                {
                    var blocoId = mediator.Send(new ObterIdBlocoPorQuestaoEProvaIdQuery(provaId, request.Questao.Id));
                    // Recuperar o block completo 
                    // Criar um novo block 
                    // inativar o antigo 
                    // Altear tabelas correspondentes 

                }

                else
                {
                    var blocoQuestao = await mediator.Send(new ObterIdBlocoPorQuestaoEProvaIdQuery(provaId, request.Questao.Id));
                    QuestaoBloco itemBloco = MapeaItemBlocoProvaIdParaNovaEntidade(blocoQuestao);
                    await InativaItemVersaoAntigaDoBloco(itemBloco);
                    await CriaBlocoQuestaoNovaVersao(NovaVersaoQuestaoId, itemBloco.BlocoId, itemBloco.Ordem);
                }
            }

            return true;


        }

        private async Task<long> IncluiNovoTextoBase(ParametrosQuestaoSalvar request, TextoBase? textoBaseItem)
        {
            var novoTextoBase = new TextoBase()
            {
                Descricao = request.Questao.TextoBase,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now,
                DeclaracaoInicial = textoBaseItem?.DeclaracaoInicial,
                DeclaracaoInicialNarracao = textoBaseItem?.DeclaracaoInicialNarracao,
                Fonte = textoBaseItem?.Fonte,
                OrientacaoInicial = textoBaseItem?.OrientacaoInicial,
                OrientacaTextoBase = textoBaseItem?.OrientacaTextoBase,
                TextoBaseAluno = textoBaseItem?.TextoBaseAluno,
                TextoBaseAlunoNarracao = textoBaseItem?.TextoBaseAlunoNarracao,
                Situacao = (int)LegadoState.Ativo
            };

            return await mediator.Send(new IncluirTextoBaseCommand(novoTextoBase));
        }

        private async Task<long> CriaBlocoQuestaoNovaVersao(long novaVersaoItemId, long blocoId, int ordem)
        {

            var novoItemBloco = new QuestaoBloco()
            {
                Ordem = ordem,
                BlocoId = blocoId,
                ItemId = novaVersaoItemId,
                Situacao = (int)LegadoState.Ativo,
                DataCricao = DateTime.Now,
                DataAtualizacao = DateTime.Now,
            };
            var idRetorno = await mediator.Send(new QuestaoBlocoCommand(novoItemBloco));

            return idRetorno;
        }

        private async Task InativaItemVersaoAntigaDoBloco(QuestaoBloco itemBloco)
        {
            itemBloco.Situacao = (int)LegadoState.Excluido;
            await mediator.Send(new QuestaoBlocoCommand(itemBloco));
        }

        private static QuestaoBloco MapeaItemBlocoProvaIdParaNovaEntidade(BlocoItemDto blocoQuestao)
        {
            return new QuestaoBloco()
            {
                Id = blocoQuestao.Id,
                BlocoId = blocoQuestao.BlocoId,
                ItemId = blocoQuestao.ItemId,
                DataCricao = blocoQuestao.DataCriacao,
                Ordem = blocoQuestao.Ordem,
                DataAtualizacao = DateTime.Now,

            };
        }

        private static Questao NovaVersaoQuestaoMap(ParametrosQuestaoSalvar request, Questao questaoAtual)
        {
            var questaoNovaVersao = new Questao
            {
                AreaConhecimentoId = questaoAtual.AreaConhecimentoId,
                CodigoItem = questaoAtual.CodigoItem,
                VersaoItem = questaoAtual.VersaoItem + 1,
                TextoBaseId = questaoAtual.TextoBaseId, // novoIdTextoBase
                Enunciado = request.Questao.Enunciado,
                LevelItemId = questaoAtual.LevelItemId,
                DataAtualizacao = DateTime.Now,
                DataCriacao = DateTime.Now,
                DeclaracaoAluno = questaoAtual.DeclaracaoAluno,
                DescriptorSentence = questaoAtual.DescriptorSentence,
                EhRestrito = questaoAtual.EhRestrito,
                Estado = questaoAtual.Estado,
                ItemNarrado = questaoAtual.ItemNarrado,
                MatrizId = questaoAtual.MatrizId,
                NarracaoAlternativas = questaoAtual.NarracaoAlternativas,
                PalavrasChaves = questaoAtual.PalavrasChaves,
                NarracaoDeclaracaoAluno = questaoAtual.NarracaoDeclaracaoAluno,
                Proeficiencia = questaoAtual.Proeficiencia,
                Revogado = questaoAtual.Revogado,
                SituacaoItemId = questaoAtual.SituacaoItemId,
                SubAssunto = questaoAtual.SubAssunto,
                TipoItem = questaoAtual.TipoItem,
                Tips = questaoAtual.Tips,
                TRICasualSetting = questaoAtual.TRICasualSetting,
                TRIDifficulty = questaoAtual.TRIDifficulty,
                TRIDiscrimination = questaoAtual.TRIDiscrimination,
                UltimaVersao = true,
                VersaoCodigoItem = questaoAtual.VersaoCodigoItem,
            };
            return questaoNovaVersao;
        }
    }
}
