using Dapper;
using SME.Simulador.Prova.Serap.Dados.Interfaces;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Dados.Repositorios
{
    public class RepositorioTextoBase : RepositorioGestaoAvaliacaoBase<TextoBase>, IRepositorioTextoBase
    {
        private readonly GestaoAvaliacaoContexto gestaoAvaliacaoContexto;

        public RepositorioTextoBase(GestaoAvaliacaoContexto gestaoAvaliacaoContexto) : base(gestaoAvaliacaoContexto)
        {
            this.gestaoAvaliacaoContexto = gestaoAvaliacaoContexto ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContexto));
        }

        public async Task<long> InserirTextoBase(TextoBase entidade)
        {
            var query = @"INSERT INTO [dbo].[BaseText]
           ([Description]
           ,[CreateDate]
           ,[UpdateDate]
           ,[State]
           ,[Source]
           ,[InitialOrientation]
           ,[InitialStatement]
           ,[NarrationInitialStatement]
           ,[StudentBaseText]
           ,[NarrationStudentBaseText]
           ,[BaseTextOrientation])
     VALUES
           (@Descricao
           ,@DataCriacao
           ,@DataAtualizacao
           ,@Situacao
           ,@Fonte
           ,@OrientacaoInicial
           ,@DeclaracaoInicial
           ,@DeclaracaoInicialNarracao
           ,@TextoBaseAluno
           ,@TextoBaseAlunoNarracao
           ,@OrientacaTextoBase)";

            var ret = await gestaoAvaliacaoContexto.Conexao.ExecuteAsync(query, new
            {
                entidade.Descricao,
                entidade.DataCriacao,
                entidade.DataAtualizacao,
                entidade.Situacao,
                entidade.Fonte,
                entidade.OrientacaoInicial,
                entidade.DeclaracaoInicial,
                entidade.DeclaracaoInicialNarracao,
                entidade.TextoBaseAluno,
                entidade.TextoBaseAlunoNarracao,
                entidade.OrientacaTextoBase
            });

            return ret;
        }
    }
}
