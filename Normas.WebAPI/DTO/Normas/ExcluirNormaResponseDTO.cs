using tipoDocumento = Normas.WebAPI.Entities.TipoDocumento;
using orgaoExpedidor = Normas.WebAPI.Entities.OrgaoExpedidor;
using System;

namespace Normas.WebAPI.DTO.Normas
{
    public class ExcluirNormaResponseDTO
    {
        public int Id { get; set; }
        public string CodigoNorma { get; set; }
        public string Descricao { get; set; }
        public tipoDocumento TipoDocumento { get; set; }
        public orgaoExpedidor OrgaoExpedidor { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Resumo { get; set; }
        public string Observacao { get; set; }
    }
}
