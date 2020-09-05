using System.ComponentModel.DataAnnotations;

namespace Seguranca.WebAPI.DTO
{
    public class AuthRequestDTO
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
