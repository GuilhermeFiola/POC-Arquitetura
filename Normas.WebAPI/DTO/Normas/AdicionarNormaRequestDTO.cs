using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Normas.WebAPI.DTO.Normas
{
    public class AdicionarNormaRequestDTO
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int TipoDocumento { get; set; }
        [Required]
        public int OrgaoExpedicao { get; set; }
        [Required]
        public DateTime DataPublicacao { get; set; }
        public string Resumo { get; set; }
        public string Observacao { get; set; }
        public IFormFile ArquivoNorma { get; set; }
    }
}
