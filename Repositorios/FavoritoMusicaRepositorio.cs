using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayMax.Models;

namespace PlayMax.Repositorios
{
    public class FavoritoMusicaRepositorio
    {
        private readonly ContextoBD _contexto;

        public FavoritoMusicaRepositorio([FromServices] ContextoBD contexto){
            _contexto = contexto;
        }

        public Musica BuscarMusicaPeloidF(int id){
            return _contexto.Musicas.AsNoTracking().Include(Musica => Musica.Favoritos).FirstOrDefault(Musica => Musica.Id == id);
        }

    }
}