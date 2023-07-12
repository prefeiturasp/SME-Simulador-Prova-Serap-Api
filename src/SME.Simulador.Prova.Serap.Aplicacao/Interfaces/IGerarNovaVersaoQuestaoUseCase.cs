using SME.Simulador.Prova.Serap.Infra.Dtos.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao.Interfaces
{
    public interface IGerarNovaVersaoQuestaoUseCase
    {
        public  Task<bool> ExecutarAsync(ParametrosQuestaoSalvar request);
    }
}
