﻿using MediatR;
using SME.Simulador.Prova.Serap.Aplicacao.Commands.QuestaoArquivo;
using SME.Simulador.Prova.Serap.Aplicacao.Commands.TextoBase.Salvar;
using SME.Simulador.Prova.Serap.Aplicacao.Interfaces;
using SME.Simulador.Prova.Serap.Aplicacao.Queries.ObterListaQuestaoAudioPorQuestaoId;
using SME.Simulador.Prova.Serap.Aplicacao.Queries.Questao.ObterQuestaoPorId;
using SME.Simulador.Prova.Serap.Aplicacao.Queries.VerificaSeEhProvaBibPorProvaId;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra.Dtos;
using SME.Simulador.Prova.Serap.Infra.Dtos.Parametros;


namespace SME.Simulador.Prova.Serap.Aplicacao.UseCases
{
    public class GerarNovaVersaoQuestaoUseCase : AbstractUseCase, IGerarNovaVersaoQuestaoUseCase
    {
        public GerarNovaVersaoQuestaoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> ExecutarAsync(ParametrosQuestaoSalvar request)
        {
            try
            {
                var questaoAtual = await mediator.Send(new ObterQuestaoPorIdQuery(request.Questao.Id));
                var textoBaseQuestao = await mediator.Send(new ObterTextoBasePorIdQuery(questaoAtual.TextoBaseId));
                if (questaoAtual.Enunciado != request.Questao.Enunciado || textoBaseQuestao?.Descricao != request.Questao.TextoBase)
                {
                    long textoBaseId = questaoAtual.TextoBaseId;

                    if (textoBaseQuestao?.Descricao != request.Questao.TextoBase)
                    {
                         textoBaseId = await IncluiNovoTextoBase(request, textoBaseQuestao);
                    }

                    Questao questaoNovaVersao = NovaVersaoQuestaoMap(request, questaoAtual, textoBaseId);
                    var novaVersaoQuestaoId = await mediator.Send(new GerarNovaVersaoQuestaoCommand(questaoNovaVersao));

                    if (!questaoAtual.UltimaVersao) ;
                    //Atualizar Para ultima versao

                    foreach (var alternativaDto in request.Alternativas)
                        await CriaAlternativasNovaVersao(novaVersaoQuestaoId, alternativaDto);


                    //Habilidade
                    var listaQuestaoHabilidades = await mediator.Send(new ObterListaQuestaoHabilidadesPorQuestaoIdQuery(request.Questao.Id));
                    foreach (var questaoHabilidade in listaQuestaoHabilidades)
                    {
                        var questaoHabilidadeNovaVersao = new QuestaoHabilidade()
                        {
                            QuestaoId = novaVersaoQuestaoId,
                            HabilidadeId = questaoHabilidade.HabilidadeId,
                            HabilidadeOriginal = questaoHabilidade.HabilidadeOriginal,
                            DataCriacao = DateTime.Now,
                            DataAtualizacao = DateTime.Now,
                            Situacao = (int)LegadoState.Ativo
                        };

                        await mediator.Send(new IncluirQuestaoHabilidadeCommand(questaoHabilidadeNovaVersao));
                    }

                    //Grade
                    var listaQuestaoGradesCurriculares = await mediator.Send(new ObterListaQuestaoGradesCurricularesQuery(request.Questao.Id));
                    foreach (var questaoGradeCurricular in listaQuestaoGradesCurriculares)
                    {
                        var questaoGradeCurricularNovaVersao = new QuestaoGradeCurricular()
                        {
                            QuestaoId = novaVersaoQuestaoId,
                            TipoGradeCurricular = questaoGradeCurricular.TipoGradeCurricular,
                            DataCriacao = DateTime.Now,
                            DataAtualizacao = DateTime.Now,
                            Situacao = (int)LegadoState.Ativo
                        };

                        await mediator.Send(new IncluirQuestaoGradeCurricularCommand(questaoGradeCurricularNovaVersao));
                    }

                    //Arquivo
                    var listaQuestaoArquivo = await mediator.Send(new ObterListaQuestaoArquivoPorQuestaoIdQuery(request.Questao.Id));
                    foreach (var questaoArquivo in listaQuestaoArquivo)
                    {
                        var questaoArquivoNovaVersao = new QuestaoArquivo()
                        {
                            QuestaoId = novaVersaoQuestaoId,
                            ArquivoConvertidoId = questaoArquivo.ArquivoConvertidoId,
                            ArquivoId = questaoArquivo.ArquivoId,
                            ThumbnailId = questaoArquivo.ThumbnailId,
                            DataCriacao = DateTime.Now,
                            DataAtualizacao = DateTime.Now,
                            Situacao = (int)LegadoState.Ativo,

                        };

                        await mediator.Send(new IncluirQuestaoArquivoCommand(questaoArquivoNovaVersao));
                    }

                    // audio

                    var listaQuestaoAudio = await mediator.Send(new ObterListaQuestaoAudioPorQuestaoIdQuery(request.Questao.Id));
                    foreach (var questaoArquivo in listaQuestaoAudio)
                    {
                        var questaoAudioNovaVersao = new QuestaoAudio()
                        {
                            QuestaoId = novaVersaoQuestaoId,
                            ArquivoId = questaoArquivo.ArquivoId,
                            DataCriacao = DateTime.Now,
                            DataAtualizacao = DateTime.Now,
                            Situacao = (int)LegadoState.Ativo,
                        };

                        await mediator.Send(new IncluirQuestaoAudioCommand(questaoAudioNovaVersao));
                    }
                    foreach (var provaId in request.ProvasId)
                    {
                        await AtualizaBlocos(request, novaVersaoQuestaoId, provaId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        private async Task AtualizaBlocos(ParametrosQuestaoSalvar request, long novaVersaoQuestaoId, int provaId)
        {
            var provaBib = await mediator.Send(new VerificaSeEhProvaBibQuery(provaId));

            if (provaBib)
            {
                var cadeiaBlocoQuestaoProva = await mediator.Send(new ObterCadeiaBlocoQuestaoPorItemEProvaIdQuery(provaId, request.Questao.Id));
                var cadeiaBlocoQuestao = MapeaCadeiaBlocoQuestaoProvaParaNovaEntidade(cadeiaBlocoQuestaoProva);
                cadeiaBlocoQuestao.Situacao = (int)LegadoState.Excluido;
                await mediator.Send(new CadeiaBlocoQuestaoCommand(cadeiaBlocoQuestao));
                await CriaCadeiaBlocoQuestaoNovaVersao(novaVersaoQuestaoId, cadeiaBlocoQuestaoProva, cadeiaBlocoQuestao);
            }

            else
            {
                var blocoQuestaoProva = await mediator.Send(new ObterQuestaoBlocoPorItemEProvaIdQuery(provaId, request.Questao.Id));
                QuestaoBloco QuestaoBloco = MapeaItemBlocoProvaIdParaNovaEntidade(blocoQuestaoProva);
                await InativaItemVersaoAntigaDoBloco(QuestaoBloco);
                await CriaBlocoQuestaoNovaVersao(novaVersaoQuestaoId, QuestaoBloco.BlocoId, QuestaoBloco.Ordem);
            }
        }

        private async Task CriaAlternativasNovaVersao(long novaVersaoQuestaoId, AlternativaAlteracaoDto alternativaDto)
        {
            var alternativaQuestao = await mediator.Send(new ObterAlternativasPorIdQuery(alternativaDto.Id));

            var entidadeAlternativa = new Alternativa()
            {
                QuestaoId = novaVersaoQuestaoId,
                Correta = alternativaQuestao.Correta,
                DataCriacao = DateTime.Now,
                Descricao = alternativaDto.Descricao,
                DiscriminaçãoTCT = alternativaQuestao.DiscriminaçãoTCT,
                Justificativa = alternativaQuestao.Justificativa,
                Numeracao = alternativaQuestao.Numeracao,
                Ordem = alternativaQuestao.Ordem,
                Situacao = alternativaQuestao.Situacao,
                TCTCoeficienteBisserial = alternativaQuestao.TCTCoeficienteBisserial,
                TCTDificuldade = alternativaQuestao.TCTDificuldade,
            };
            await mediator.Send(new IncluirAlternativaCommand(entidadeAlternativa));
        }

        private async Task CriaCadeiaBlocoQuestaoNovaVersao(long novaVersaoQuestaoId, CadeiaBlocoQuestaoDto cadeiaBlocoQuestaoProva, CadeiaBlocoQuestao cadeiaBlocoQuestao)
        {
            var c = new CadeiaBlocoQuestao()
            {
                Id = cadeiaBlocoQuestaoProva.Id,
                CadeiaBlocoId = cadeiaBlocoQuestaoProva.CadeiaBlocoId,
                QuestaoId = novaVersaoQuestaoId,
                DataCricao = cadeiaBlocoQuestaoProva.DataCriacao,
                Ordem = cadeiaBlocoQuestaoProva.Ordem,
                DataAtualizacao = DateTime.Now,
                Situacao = (int)LegadoState.Ativo
            };
            await mediator.Send(new CadeiaBlocoQuestaoCommand(cadeiaBlocoQuestao));
        }

        private static CadeiaBlocoQuestao MapeaCadeiaBlocoQuestaoProvaParaNovaEntidade(CadeiaBlocoQuestaoDto cadeiaBlocoQuestaoProva)
        {
            return new CadeiaBlocoQuestao()
            {
                Id = cadeiaBlocoQuestaoProva.Id,
                CadeiaBlocoId = cadeiaBlocoQuestaoProva.CadeiaBlocoId,
                QuestaoId = cadeiaBlocoQuestaoProva.QuestaoId,
                DataCricao = cadeiaBlocoQuestaoProva.DataCriacao,
                Ordem = cadeiaBlocoQuestaoProva.Ordem,
                DataAtualizacao = DateTime.Now,

            };
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

        private static Questao NovaVersaoQuestaoMap(ParametrosQuestaoSalvar request, Questao questaoAtual, long textoBaseId)
        {
            var questaoNovaVersao = new Questao
            {
                AreaConhecimentoId = questaoAtual.AreaConhecimentoId,
                CodigoItem = questaoAtual.CodigoItem,
                VersaoItem = questaoAtual.VersaoItem + 1,
                TextoBaseId = textoBaseId, // novoIdTextoBase
                Enunciado = request.Questao.Enunciado,
                LevelItemId = questaoAtual.LevelItemId,
                DataAtualizacao = DateTime.Now,
                DataCriacao = DateTime.Now,
                DeclaracaoAluno = questaoAtual.DeclaracaoAluno,
                DescriptorSentence = questaoAtual.DescriptorSentence,
                EhRestrito = questaoAtual.EhRestrito,
                Situacao = questaoAtual.Situacao,
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
