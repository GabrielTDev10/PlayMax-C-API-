using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayMax.Models;

namespace PlayMax.Repositorios
{
    public class ArtistaMusicaRepositorio
    {
        private readonly ContextoBD _contexto;


        public ArtistaMusicaRepositorio([FromServices] ContextoBD contexto){

            _contexto = contexto;
        }

      
        public Musica BuscarMusicaPeloId(int id){

            return _contexto.Musicas.AsNoTracking().Include(musica => musica.Artistas).FirstOrDefault(musica => musica.Id == id);

        }



    }
}