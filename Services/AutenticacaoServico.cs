using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PlayMax.Dtos.Usuario;
using PlayMax.Models;
using PlayMax.Repositorios;

namespace PlayMax.Services
{
    public class AutenticacaoServico
    {
        private readonly UsuarioRepositorio _usuariorepositorio;

        private readonly IConfiguration _configuration;

        public AutenticacaoServico([FromServices]UsuarioRepositorio repositorio,[FromServices] IConfiguration config){

            _usuariorepositorio = repositorio;
            _configuration = config;
        }

        public string Login(UsuarioLoginRequisicao usuarioLogin){
            
            var Usuario = _usuariorepositorio.BuscarUsuarioPeloEmail(usuarioLogin.Email);

            if( (Usuario is null) || (BCrypt.Net.BCrypt.Verify(usuarioLogin.Senha, Usuario.Senha) ) ) {
                throw new Exception("Usuario Ou Senha Incorretos");
            }

            var tokenJWT = GerarJWT(Usuario);



            return tokenJWT;
        }

            private string GerarJWT(Usuario usuario){
                //Pegando a chave JWT
                            var JWTChave = Encoding.ASCII.GetBytes(_configuration["JWTChave"]);

                            //Criando as credenciais
                            var credenciais = new SigningCredentials(
                                    new SymmetricSecurityKey(JWTChave),
                                    SecurityAlgorithms.HmacSha256);

                            var claims = new List<Claim>();
                           claims.Add(new Claim(ClaimTypes.Name, usuario.Nome));
                           claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString() ));

                           foreach(var musica in usuario.Musicas){
                                    claims.Add(new Claim(ClaimTypes.Role, musica.Nome));
                           }

                            //Criando o token
                            var tokenJWT = new JwtSecurityToken(
                                expires: DateTime.Now.AddHours(8),
                                signingCredentials: credenciais,
                                claims: claims
                            );

                            //Escrevendo o token e retornando
                            return new JwtSecurityTokenHandler().WriteToken(tokenJWT);
            }              
    }
}