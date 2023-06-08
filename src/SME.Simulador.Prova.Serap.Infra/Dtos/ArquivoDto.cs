namespace SME.Simulador.Prova.Serap.Infra
{
    public class ArquivoDto
    {
        public ArquivoDto()
        {

        }

        public ArquivoDto(string caminho, long tamanhoBytes, long id)
        {
            Caminho = caminho;
            TamanhoBytes = tamanhoBytes;
            Id = id;
        }

        public string Caminho { get; set; }
        public long TamanhoBytes { get; set; }
        public long Id { get; set; }
    }
}
