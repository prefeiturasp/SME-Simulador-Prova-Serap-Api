﻿using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioGestaoAvaliacaoBase<TEntidadeBase> : RepositorioBase<TEntidadeBase, GestaoAvaliacaoContexto> 
    where TEntidadeBase : EntidadeBase
{
    protected RepositorioGestaoAvaliacaoBase(GestaoAvaliacaoContexto contexto) : base(contexto)
    {
    }
}