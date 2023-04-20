using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayMax.Dtos.Usuario;
using PlayMax.Models;
using PlayMax.Repositorios;
using Mapster;

namespace PlayMax.Services
{
    public class UsuarioServico
    {

        private readonly UsuarioRepositorio _usuarioRepositorio;      

        public UsuarioServico([FromServices] UsuarioRepositorio repositorio){
                _usuarioRepositorio = repositorio;
        }                                                          

        public UsuarioResposta CriarUsuario(UsuarioCriarAtualizarRequicao NovoUsuario){

            var usuarioExistente = _usuarioRepositorio.BuscarUsuarioPeloEmail(NovoUsuario.Email);
            if(usuarioExistente is not null){
                throw new Exception("Já existe um Usuario com esse email");
            }

            // var Usuario = new Usuario();
            // ConverterRequicaoparaModelo(NovoUsuario,Usuario);
            var  Usuario = NovoUsuario.Adapt<Usuario>();



            Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(Usuario.Senha);

            Usuario = _usuarioRepositorio.CriarUsuario(Usuario);

            // var UsuarioResposta = ConverterModeloParaResposta(Usuario);
            var UsuarioResposta = Usuario.Adapt<UsuarioResposta>();

            return UsuarioResposta;
        }      

        public List<UsuarioResposta> ListarUsuario(){

            var Usuarios = _usuarioRepositorio.ListarUsuario();

            var usuarioRespostas = Usuarios.Adapt<List<UsuarioResposta>>();

            // List<UsuarioResposta> usuarioRespostas = new();

            // foreach(var Usuario in Usuarios){
            //       var UsuarioResposta = ConverterModeloParaResposta(Usuario);
            //      usuarioRespostas.Add(UsuarioResposta);
            // }

            return usuarioRespostas;

        }

       public UsuarioResposta BuscarUsuarioporid(int id){

           var Usuario = BuscarPeloId(id,false);

           
           return Usuario.Adapt<UsuarioResposta>();
       }

       public void RemoverUsuario(int id){
            
           var Usuario = BuscarPeloId(id);

            _usuarioRepositorio.RemoverUsuario(Usuario);
       }

       public UsuarioResposta AtualizarUsuario(int id, UsuarioCriarAtualizarRequicao UsuarioEditado){

            var Usuario = BuscarPeloId(id);

            // ConverterRequicaoparaModelo(UsuarioEditado, Usuario);
            UsuarioEditado.Adapt(Usuario);

            _usuarioRepositorio.AtualizarUsuario();


            // return ConverterModeloParaResposta(Usuario);
            return Usuario.Adapt<UsuarioResposta>();
                
        
       }

       private Usuario BuscarPeloId(int id,bool tracking = true){
             var Usuario = _usuarioRepositorio.BuscarUsuarioporid(id,tracking);

            if(Usuario is null){

               throw new Exception("Usuario não encontrado!");
            }

            return Usuario;
       }
    }
}