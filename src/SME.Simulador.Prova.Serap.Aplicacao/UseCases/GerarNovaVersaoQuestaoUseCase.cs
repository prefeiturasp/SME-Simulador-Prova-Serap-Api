﻿using MediatR;
using SME.Simulador.Prova.Serap.Aplicacao.Interfaces;
using SME.Simulador.Prova.Serap.Aplicacao.Queries.ObterListaQuestaoAudioPorQuestaoId;
using SME.Simulador.Prova.Serap.Aplicacao.Queries.VerificaSeEhProvaBibPorProvaId;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class GerarNovaVersaoQuestaoUseCase : AbstractUseCase, IGerarNovaVersaoQuestaoUseCase
{
    private readonly IUnitOfWorkBaseGestaoAvaliacao unitOfWorkBaseGestaoAvaliacao;

    public GerarNovaVersaoQuestaoUseCase(IMediator mediator, IUnitOfWorkBaseGestaoAvaliacao unitOfWorkBaseGestaoAvaliacao) : base(mediator)
    {
        this.unitOfWorkBaseGestaoAvaliacao = unitOfWorkBaseGestaoAvaliacao ?? throw new ArgumentNullException(nameof(unitOfWorkBaseGestaoAvaliacao));
    }

    public async Task<bool> ExecutarAsync(ParametrosQuestaoSalvarDto request)
    {
        if (request.Questao == null || request.ProvasQuestoes == null)
            return false;

        unitOfWorkBaseGestaoAvaliacao.BeginTransaction();
        try
        {
            var questaoAtual = await mediator.Send(new ObterQuestaoPorIdQuery(request.Questao.Id));

            if (questaoAtual == null)
                return false;
            
            var textoBaseQuestao = await mediator.Send(new ObterTextoBasePorIdQuery(questaoAtual.TextoBaseId));

            if (textoBaseQuestao == null)
                return false;

            if (await ExisteAlteracaoNaQuestao(request, questaoAtual, textoBaseQuestao))
            {
                var textoBaseId = await TrataTextoBase(request, questaoAtual, textoBaseQuestao);

                await mediator.Send(new DesabilitarUltimaVersaoQuestaoPorCodigoCommand(questaoAtual.CodigoItem));

                var novaVersaoQuestaoId = await TrataQuestaoNovaVersao(request, questaoAtual, textoBaseId);

                await TrataAlternativas(request, novaVersaoQuestaoId);
                await TrataQuestaoHabilidates(request, novaVersaoQuestaoId);
                await TrataQuestaoGradeCurricular(request, novaVersaoQuestaoId);
                await TrataQuestaoArquivo(request, novaVersaoQuestaoId);
                await TrataQuestaoAudio(request, novaVersaoQuestaoId);

                foreach (var provaId in request.ProvasQuestoes)
                    await AtualizaBlocos(request, novaVersaoQuestaoId, provaId);
            }

            unitOfWorkBaseGestaoAvaliacao.Commit();
            return true;
        }
        catch (Exception ex)
        {
            unitOfWorkBaseGestaoAvaliacao.Rollback();
            throw new ErroException(ex.Message);
        }
    }

    private async Task<bool> ExisteAlteracaoNaQuestao(ParametrosQuestaoSalvarDto request, Questao questaoAtual, TextoBase textoBaseQuestao)
    {
        var questao = request.Questao;

        if (questao == null)
            return false;

        return await PossuiAlteracaoNasAlternativas(request) || questaoAtual.Enunciado != questao.Enunciado ||
               textoBaseQuestao.Descricao != questao.TextoBase;
    }

    private async Task<bool> PossuiAlteracaoNasAlternativas(ParametrosQuestaoSalvarDto request)
    {
        if (request.Alternativas == null)
            return false;
        
        var possuiAlteracao = false;
        
        foreach (var alternativaDto in request.Alternativas)
        {
            var alternativa = await mediator.Send(new ObterAlternativasPorIdQuery(alternativaDto.Id));

            if (alternativaDto.Descricao == alternativa.Descricao) 
                continue;
            
            possuiAlteracao = true;
            break;
        }

        return possuiAlteracao;
    }

    private async Task TrataQuestaoAudio(ParametrosQuestaoSalvarDto request, long novaVersaoQuestaoId)
    {
        if (request.Questao == null)
            return;

        var listaQuestaoAudio = await mediator.Send(new ObterListaQuestaoAudioPorQuestaoIdQuery(request.Questao.Id));

        foreach (var questaoArquivo in listaQuestaoAudio)
        {
            var questaoAudioNovaVersao = new QuestaoAudio
            {
                QuestaoId = novaVersaoQuestaoId,
                ArquivoId = questaoArquivo.ArquivoId,
                DataCriacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
                DataAtualizacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
                Situacao = (int)LegadoState.Ativo,
            };

            await mediator.Send(new IncluirQuestaoAudioCommand(questaoAudioNovaVersao));
        }
    }

    private async Task TrataQuestaoArquivo(ParametrosQuestaoSalvarDto request, long novaVersaoQuestaoId)
    {
        if (request.Questao == null)
            return;

        var listaQuestaoArquivo = await mediator.Send(new ObterListaQuestaoArquivoPorQuestaoIdQuery(request.Questao.Id));

        foreach (var questaoArquivo in listaQuestaoArquivo)
        {
            var questaoArquivoNovaVersao = new QuestaoArquivo
            {
                QuestaoId = novaVersaoQuestaoId,
                ArquivoConvertidoId = questaoArquivo.ArquivoConvertidoId,
                ArquivoId = questaoArquivo.ArquivoId,
                ThumbnailId = questaoArquivo.ThumbnailId,
                DataCriacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
                DataAtualizacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
                Situacao = (int)LegadoState.Ativo
            };

            await mediator.Send(new IncluirQuestaoArquivoCommand(questaoArquivoNovaVersao));
        }
    }

    private async Task TrataQuestaoGradeCurricular(ParametrosQuestaoSalvarDto request, long novaVersaoQuestaoId)
    {
        if (request.Questao == null)
            return;

        var listaQuestaoGradesCurriculares = await mediator.Send(new ObterListaQuestaoGradesCurricularesQuery(request.Questao.Id));

        foreach (var questaoGradeCurricular in listaQuestaoGradesCurriculares)
        {
            var questaoGradeCurricularNovaVersao = new QuestaoGradeCurricular
            {
                QuestaoId = novaVersaoQuestaoId,
                TipoGradeCurricular = questaoGradeCurricular.TipoGradeCurricular,
                DataCriacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
                DataAtualizacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
                Situacao = (int)LegadoState.Ativo
            };

            await mediator.Send(new IncluirQuestaoGradeCurricularCommand(questaoGradeCurricularNovaVersao));
        }
    }

    private async Task TrataQuestaoHabilidates(ParametrosQuestaoSalvarDto request, long novaVersaoQuestaoId)
    {
        if (request.Questao == null)
            return;

        var listaQuestaoHabilidades = await mediator.Send(new ObterListaQuestaoHabilidadesPorQuestaoIdQuery(request.Questao.Id));

        foreach (var questaoHabilidade in listaQuestaoHabilidades)
        {
            var questaoHabilidadeNovaVersao = new QuestaoHabilidade
            {
                QuestaoId = novaVersaoQuestaoId,
                HabilidadeId = questaoHabilidade.HabilidadeId,
                HabilidadeOriginal = questaoHabilidade.HabilidadeOriginal,
                DataCriacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
                DataAtualizacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
                Situacao = (int)LegadoState.Ativo
            };

            await mediator.Send(new IncluirQuestaoHabilidadeCommand(questaoHabilidadeNovaVersao));
        }
    }

    private async Task TrataAlternativas(ParametrosQuestaoSalvarDto request, long novaVersaoQuestaoId)
    {
        if (request.Alternativas == null)
            return;

        foreach (var alternativaDto in request.Alternativas)
            await CriaAlternativasNovaVersao(novaVersaoQuestaoId, alternativaDto);
    }

    private async Task<long> TrataQuestaoNovaVersao(ParametrosQuestaoSalvarDto request, Questao questaoAtual, long textoBaseId)
    {
        var ultimaVersao = await mediator.Send(new ObterUltimaVersaoQuestaoPorCodigoQuery(questaoAtual.CodigoItem));
        var questaoNovaVersao = NovaVersaoQuestaoMap(request, questaoAtual, textoBaseId, ultimaVersao);
        var novaVersaoQuestaoId = await mediator.Send(new GerarNovaVersaoQuestaoCommand(questaoNovaVersao));
        return novaVersaoQuestaoId;
    }

    private async Task<long> TrataTextoBase(ParametrosQuestaoSalvarDto request, Questao questaoAtual, TextoBase textoBaseQuestao)
    {
        var textoBaseId = questaoAtual.TextoBaseId;

        if (textoBaseQuestao?.Descricao != request.Questao?.TextoBase)
            textoBaseId = await IncluiNovoTextoBase(request, textoBaseQuestao);

        return textoBaseId;
    }

    private async Task AtualizaBlocos(ParametrosQuestaoSalvarDto request, long novaVersaoQuestaoId, ProvasQuestoesDto provaQuestao)
    {
        var provaBib = await mediator.Send(new VerificaSeEhProvaBibQuery(provaQuestao.ProvaId));

        try
        {
            if (provaBib)
            {
                if (request.Questao == null)
                    return;

                var cadeiaBlocoQuestaoProva = await mediator.Send(new ObterCadeiaBlocoQuestaoPorItemEProvaIdQuery(provaQuestao.ProvaId, provaQuestao.QuestaoId));

                if (cadeiaBlocoQuestaoProva == null)
                    return;

                var cadeiaBlocoQuestao = MapeaCadeiaBlocoQuestaoProvaParaNovaEntidade(cadeiaBlocoQuestaoProva);

                await InativaCadeiaBlocoQuestaoVersaoAntiga(cadeiaBlocoQuestao);
                await CriaCadeiaBlocoQuestaoNovaVersao(novaVersaoQuestaoId, cadeiaBlocoQuestaoProva);
                await TrataBlocoQuestao(novaVersaoQuestaoId, provaQuestao.ProvaId, provaQuestao.QuestaoId);
            }
            else
                await TrataBlocoQuestao(novaVersaoQuestaoId, provaQuestao.ProvaId, provaQuestao.QuestaoId);

            async Task InativaCadeiaBlocoQuestaoVersaoAntiga(CadeiaBlocoQuestao cadeiaBlocoQuestao)
            {
                cadeiaBlocoQuestao.Situacao = (int)LegadoState.Excluido;
                await mediator.Send(new CadeiaBlocoQuestaoCommand(cadeiaBlocoQuestao));
            }
        }
        catch (Exception ex)
        {
            if (provaBib)
                throw new ErroException($"Erro ao atualizar blocos: {ex.Message}");

            throw new ErroException($"Erro ao atualizar cadernos: {ex.Message}");
        }
    }

    private async Task TrataBlocoQuestao(long novaVersaoQuestaoId, long provaId, long questaoId)
    {
        if (questaoId == 0)
            return;

        var blocosQuestoesProva = await mediator.Send(new ObterQuestoesBlocosPorItemEProvaIdQuery(provaId, questaoId));

        foreach (var blocoQuestaoProva in blocosQuestoesProva)
        {
            var questaoBloco = MapeaItemBlocoProvaIdParaNovaEntidade(blocoQuestaoProva);
            await InativaItemVersaoAntigaDoBloco(questaoBloco);
            await CriaBlocoQuestaoNovaVersao(novaVersaoQuestaoId, questaoBloco.BlocoId, questaoBloco.Ordem);            
        }
    }

    private async Task CriaAlternativasNovaVersao(long novaVersaoQuestaoId, AlternativaAlteracaoDto alternativaDto)
    {
        var alternativaQuestao = await mediator.Send(new ObterAlternativasPorIdQuery(alternativaDto.Id));

        var entidadeAlternativa = new Alternativa
        {
            QuestaoId = novaVersaoQuestaoId,
            Correta = alternativaQuestao.Correta,
            DataCriacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
            DataAtualizacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
            Descricao = alternativaDto.Descricao,
            DiscriminaçãoTCT = alternativaQuestao.DiscriminaçãoTCT,
            Justificativa = alternativaQuestao.Justificativa,
            Numeracao = alternativaQuestao.Numeracao,
            Ordem = alternativaQuestao.Ordem,
            Situacao = alternativaQuestao.Situacao,
            TCTCoeficienteBisserial = alternativaQuestao.TCTCoeficienteBisserial,
            TCTDificuldade = alternativaQuestao.TCTDificuldade
        };

        await mediator.Send(new IncluirAlternativaCommand(entidadeAlternativa));
    }

    private async Task CriaCadeiaBlocoQuestaoNovaVersao(long novaVersaoQuestaoId,
        CadeiaBlocoQuestaoDto cadeiaBlocoQuestaoProva)
    {
        var cadeiaBlocoQuestaoNovo = new CadeiaBlocoQuestao()
        {
            CadeiaBlocoId = cadeiaBlocoQuestaoProva.CadeiaBlocoId,
            QuestaoId = novaVersaoQuestaoId,
            DataCricao = cadeiaBlocoQuestaoProva.DataCriacao,
            Ordem = cadeiaBlocoQuestaoProva.Ordem,
            DataAtualizacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
            Situacao = (int)LegadoState.Ativo
        };

        await mediator.Send(new CadeiaBlocoQuestaoCommand(cadeiaBlocoQuestaoNovo));
    }

    private static CadeiaBlocoQuestao MapeaCadeiaBlocoQuestaoProvaParaNovaEntidade(CadeiaBlocoQuestaoDto cadeiaBlocoQuestaoProva)
    {
        return new CadeiaBlocoQuestao
        {
            Id = cadeiaBlocoQuestaoProva.Id,
            CadeiaBlocoId = cadeiaBlocoQuestaoProva.CadeiaBlocoId,
            QuestaoId = cadeiaBlocoQuestaoProva.QuestaoId,
            DataCricao = cadeiaBlocoQuestaoProva.DataCriacao,
            Ordem = cadeiaBlocoQuestaoProva.Ordem,
            DataAtualizacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc()
        };
    }

    private async Task<long> IncluiNovoTextoBase(ParametrosQuestaoSalvarDto request, TextoBase? textoBaseItem)
    {
        var novoTextoBase = new TextoBase
        {
            Descricao = request.Questao?.TextoBase,
            DataCriacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
            DataAtualizacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
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

    private async Task CriaBlocoQuestaoNovaVersao(long novaVersaoItemId, long blocoId, int ordem)
    {
        var novoItemBloco = new QuestaoBloco
        {
            Ordem = ordem,
            BlocoId = blocoId,
            QuestaoId = novaVersaoItemId,
            Situacao = (int)LegadoState.Ativo,
            DataCricao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
            DataAtualizacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc()
        };

        await mediator.Send(new QuestaoBlocoCommand(novoItemBloco));
    }

    private async Task InativaItemVersaoAntigaDoBloco(QuestaoBloco itemBloco)
    {
        itemBloco.Situacao = (int)LegadoState.Excluido;
        await mediator.Send(new QuestaoBlocoCommand(itemBloco));
    }

    private static QuestaoBloco MapeaItemBlocoProvaIdParaNovaEntidade(BlocoItemDto blocoQuestao)
    {
        return new QuestaoBloco
        {
            Id = blocoQuestao.Id,
            BlocoId = blocoQuestao.BlocoId,
            QuestaoId = blocoQuestao.ItemId,
            DataCricao = blocoQuestao.DataCriacao,
            Ordem = blocoQuestao.Ordem,
            DataAtualizacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc()
        };
    }

    private static Questao NovaVersaoQuestaoMap(ParametrosQuestaoSalvarDto request, Questao questaoAtual, long textoBaseId,
        int ultimaVersaoQuestao)
    {
        var questaoNovaVersao = new Questao
        {
            AreaConhecimentoId = questaoAtual.AreaConhecimentoId,
            CodigoItem = questaoAtual.CodigoItem,
            VersaoItem = ultimaVersaoQuestao + 1,
            TextoBaseId = textoBaseId,
            Enunciado = request.Questao?.Enunciado,
            LevelItemId = questaoAtual.LevelItemId,
            DataAtualizacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
            DataCriacao = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
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
            VersaoCodigoQuestao = questaoAtual.VersaoCodigoQuestao
        };

        return questaoNovaVersao;
    }
}