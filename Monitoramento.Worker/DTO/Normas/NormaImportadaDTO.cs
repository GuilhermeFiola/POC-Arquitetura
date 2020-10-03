using System;

namespace Monitoramento.Worker.DTO.Normas
{
    public class NormaImportadaDTO
    {
        public int Id { get; set; }
        public string CodigoNorma { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string LocalArquivoNormas { get; set; }
    }
}


