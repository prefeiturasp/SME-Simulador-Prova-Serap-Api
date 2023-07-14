using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao.Commands.QuestaoArquivo
{
    public class IncluirQuestaoArquivoCommand : IRequest<long>
    {
        public IncluirQuestaoArquivoCommand(Dominio.QuestaoArquivo questaoArquivo)
        {
            QuestaoArquivo = questaoArquivo;
        }


        public Dominio.QuestaoArquivo QuestaoArquivo { get; set; }
    }
}
