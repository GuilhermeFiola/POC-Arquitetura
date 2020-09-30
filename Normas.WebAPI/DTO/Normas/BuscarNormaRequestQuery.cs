using System;

namespace Normas.WebAPI.DTO.Normas
{
    public class BuscarNormaRequestQuery
    {
        public string CodigoNorma { get; set; }
        public string Descricao { get; set; }
        public int? TipoDocumento{ get; set; }
        public int? OrgaoExpedidor { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}
