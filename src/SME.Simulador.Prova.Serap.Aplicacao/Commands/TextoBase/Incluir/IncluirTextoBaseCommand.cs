﻿using MediatR;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class IncluirTextoBaseCommand : IRequest<long>
{
    public IncluirTextoBaseCommand(Dominio.TextoBase textoBase)
    {
        TextoBase = textoBase;
    }
        
    public Dominio.TextoBase TextoBase { get; }
}