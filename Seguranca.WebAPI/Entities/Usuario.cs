using System.Text.Json.Serialization;

namespace Seguranca.WebAPI.Entitites
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Login { get; set; }
        
        [JsonIgnore]
        public string Senha { get; set; }
    }
}
