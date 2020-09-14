using Newtonsoft.Json;
using System.Collections.Generic;

namespace Normas.WebAPI.Entities
{
    public class OrgaoExpedidor
    {
        public OrgaoExpedidor()
        {
            Normas = new HashSet<Norma>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        [JsonIgnore]
        public IEnumerable<Norma> Normas { get; set; }
    }
}
