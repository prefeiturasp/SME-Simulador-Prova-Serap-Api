﻿namespace SME.Simulador.Prova.Serap.Infra;

public class ProvaLegadoDto : DtoBase
{
    public long Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataInicioAplicacao { get; set; }
}