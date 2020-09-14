using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace NormasExternas.WebAPI.DTO.Normas
{
    public class AdicionarNormaRequestDTO
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
        [Required]
        public DateTime DataHoraInclusao { get; set; }
        public string Resumo { get; set; }
        public string Observacao { get; set; }
        public IFormFile ArquivoNorma { get; set; }
    }
}
