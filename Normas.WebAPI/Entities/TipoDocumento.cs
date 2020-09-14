using System.Collections.Generic;
using Newtonsoft.Json;

namespace Normas.WebAPI.Entities
{
    public class TipoDocumento
    {
        public TipoDocumento()
        {
            Normas = new HashSet<Norma>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        [JsonIgnore]
        public IEnumerable<Norma> Normas { get; set; }
    }
}
