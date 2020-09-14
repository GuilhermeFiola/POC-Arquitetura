using System;
using System.ComponentModel.DataAnnotations;

namespace Normas.WebAPI.DTO.Normas
{
    public class ImportarNormaRequestDTO
    {
        [Required]
        public string CodigoNorma { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string TipoDocumento { get; set; }
        [Required]
        public string OrgaoExpedidor { get; set; }
        [Required]
        public DateTime DataPublicacao { get; set; }
        public string Resumo { get; set; }
        public string Observacao { get; set; }
        [Required]
        public string LocalArquivoNormas { get; set; }
    }
}
