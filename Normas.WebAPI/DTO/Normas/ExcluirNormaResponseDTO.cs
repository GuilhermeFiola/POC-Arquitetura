using System;

namespace Normas.WebAPI.DTO.Normas
{
    public class ExcluirNormaResponseDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string TipoDocumento { get; set; }
        public string OrgaoExpedicao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Resumo { get; set; }
        public string Observacao { get; set; }
    }
}
