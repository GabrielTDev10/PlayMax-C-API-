using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayMax.Models;

namespace PlayMax.Repositorios
{
    public class FavoritoRepositorio
    {
        
        private readonly ContextoBD _contexto;

        public FavoritoRepositorio([FromServices] ContextoBD contexto){
            _contexto = contexto;
        }

        public Favorito CriarFavorito(Favorito Favorito){
                _contexto.Add(Favorito);
                _contexto.SaveChanges();

                return Favorito;

        }

        public List<Favorito> ListarFavoritos(){

            return _contexto.Favoritos.AsNoTracking().ToList();
        }

        public Favorito BuscarPeloId(int id,bool Tracking= true){
            return Tracking?
            _contexto.Favoritos.Include(Favorito => Favorito.Musicas).FirstOrDefault(f => f.Id == id):
            _contexto.Favoritos.AsNoTracking().Include(Favorito => Favorito.Musicas).FirstOrDefault(f => f.Id == id);
        }   

        public void  RemoverFavorito(Favorito favorito){

             _contexto.Remove(favorito);
            _contexto.SaveChanges();
        }

        public void AtualizarFavorito(){

            _contexto.SaveChanges();
        }


        public List<Favorito> ListarFavoritoscomMusicas(){
            return _contexto.Favoritos
            .Include(favorito => favorito.Musicas)
            .AsNoTracking()
            .ToList();
        }

    }
}