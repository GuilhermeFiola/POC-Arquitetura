using Seguranca.WebAPI.Entitites;

namespace Seguranca.WebAPI.DTO
{
    public class AuthResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Papel { get; set; }
        public string Usuario { get; set; }
        public string Token { get; set; }

        public AuthResponseDTO(Usuario usuario, string token)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Sobrenome = usuario.Sobrenome;
            Papel = usuario.Papel;
            Usuario = usuario.Login;
            Token = token;
        }
    }
}
