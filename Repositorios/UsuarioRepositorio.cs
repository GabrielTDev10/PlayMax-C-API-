using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayMax.Models;
using Microsoft.EntityFrameworkCore;

namespace PlayMax.Repositorios
{
    public class UsuarioRepositorio
    {

        private readonly ContextoBD _contexto;

        public UsuarioRepositorio([FromServices] ContextoBD contexto){
            _contexto = contexto;
        }

        public Usuario BuscarUsuarioPeloEmail(string email){
                return _contexto.Usuarios.AsNoTracking().Include(Usuario => Usuario.Musicas).Include(Usuario => Usuario.Favoritos).FirstOrDefault(usuario =>usuario.Email == email);
        }

        public Usuario  CriarUsuario(Usuario Usuario){
                _contexto.Usuarios.Add(Usuario);
                _contexto.SaveChanges();

                return Usuario;

        }   

        public  List<Usuario> ListarUsuario(){

            return _contexto.Usuarios.AsNoTracking().ToList();
        }

        public Usuario BuscarUsuarioporid(int Id,bool tracking = true){


            return(tracking) ?  _contexto.Usuarios.FirstOrDefault(Usuario => Usuario.Id == Id) : _contexto.Usuarios.AsNoTracking().FirstOrDefault(Usuario => Usuario.Id == Id);
        }

        public void RemoverUsuario(Usuario usuario){

            _contexto.Remove(usuario);
            _contexto.SaveChanges();
        }

        public void AtualizarUsuario(){

            _contexto.SaveChanges();
        }




    }
}