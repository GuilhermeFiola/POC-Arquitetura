using System;

namespace Monitoramento.DTO.Normas
{
    public class NormasExternasDTO
    {
        public int Id { get; set; }
        public string CodigoNorma { get; set; }
        public string Descricao { get; set; }
        public string TipoDocumento { get; set; }
        public string OrgaoExpedidor { get; set; }
        public DateTime DataPublicacao { get; set; }
        public DateTime DataHoraInclusao { get; set; }
        public string Resumo { get; set; }
        public string Observacao { get; set; }
        public string LocalArquivoNormas { get; set; }
    }
}
