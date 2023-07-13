using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class QuestaoBlocoCommand : IRequest<long>
    {
        public QuestaoBlocoCommand(Dominio.QuestaoBloco itemBloco)
        {
            ItemBloco = itemBloco;
        }
        public Dominio.QuestaoBloco ItemBloco { get; set; }
    }
}