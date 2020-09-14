using Normas.WebAPI.Entities;
using System;

namespace Normas.WebAPI.DTO.Normas
{
    public class AdicionarNormaResponseDTO
    {
        public int Id { get; set; }
        public string CodigoNorma { get; set; }
        public string Descricao { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public OrgaoExpedidor OrgaoExpedidor { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Resumo { get; set; }
        public string Observacao { get; set; }
    }
}
