using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayMax.Models;

namespace PlayMax.Repositorios
{
    public class MusicaRepositorio
    {
        private readonly ContextoBD _contexto;

        public MusicaRepositorio([FromServices]ContextoBD contexto ){
            _contexto = contexto;
        }

       public Musica CriarMusica(Musica musica){
            _contexto.Add(musica);
            _contexto.SaveChanges();

            return musica;
       }

        public List<Musica> ListarMusicas(){

            return _contexto.Musicas.AsNoTracking().ToList();
        }

        public Musica BuscarPeloNome(string nome,bool Tracking= true){

            return Tracking?
            _contexto.Musicas.FirstOrDefault(M => M.Nome == nome):
            _contexto.Musicas.AsNoTracking().FirstOrDefault(M => M.Nome == nome);

        }

        public void RemoverMusica(Musica musica){
            _contexto.Remove(musica);
            _contexto.SaveChanges();

        }

        public void AtualizarMusica(){

            _contexto.SaveChanges();
        }

    }
}