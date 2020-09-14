using Microsoft.IdentityModel.Tokens;
using Seguranca.WebAPI.Helpers;
using Seguranca.WebAPI.Entitites;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Seguranca.WebAPI.DTO;
using System.Linq;

namespace Seguranca.WebAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private List<Usuario> _usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nome = "João", Sobrenome = "Pedro", Papel = "Usuario", Login = "usuario", Senha = "usuario" },
            new Usuario { Id = 1, Nome = "Maria", Sobrenome = "Lima", Papel = "Analista", Login = "analistaqa", Senha = "qa" }
        };

        public AuthResponseDTO Autenticar(AuthRequestDTO authRequestDTO)
        {
            var usuario = _usuarios.SingleOrDefault(x => x.Login == authRequestDTO.Usuario && x.Senha == authRequestDTO.Senha);

            if (usuario == null) return null;

            var token = GerarTokenJwt(usuario);

            return new AuthResponseDTO(usuario, token);
        }

        private string GerarTokenJwt(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes(AppSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { 
                    new Claim(ClaimTypes.Name, user.Nome.ToString()),
                    new Claim(ClaimTypes.Role, user.Papel.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(240),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
