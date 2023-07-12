using SME.Simulador.Prova.Serap.Infra.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Dados.Interfaces
{
    public interface IRepositorioCadeiaBlocos
    {
        Task<CadeiaBlocoQuestaoDto> ObterBlocoIdPorItemEhProvaId(long provaId, long itemId)
    }
}
