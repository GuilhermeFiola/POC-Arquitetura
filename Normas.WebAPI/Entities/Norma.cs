using System;

namespace Normas.WebAPI.Entities
{
    public class Norma
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdOrgaoExpedidor { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public OrgaoExpedidor OrgaoExpedicao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Resumo { get; set; }
        public string Observacao { get; set; }
        public string LocalArquivoNorma { get; set; }

    }
}
