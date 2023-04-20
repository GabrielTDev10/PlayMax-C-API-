using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayMax.Models;

namespace PlayMax.Repositorios
{
    public class ArtistaRepositorio
    {
        public readonly ContextoBD _contexto;


        public ArtistaRepositorio([FromServices]ContextoBD contexto){
            _contexto = contexto;
        }

        public Artista CriarArtista(Artista artista){
            _contexto.Add(artista);
            _contexto.SaveChanges();

            return artista;
        }

        public List<Artista> ListarArtista(){

            return _contexto.Artistas.AsNoTracking().ToList();
        }

        public Artista BuscarPeloNome(string nome,bool Tracking=true){

            return Tracking?
            _contexto.Artistas .Include(artista => artista.Musicas).FirstOrDefault(a => a.Nome ==nome):
            _contexto.Artistas.AsNoTracking().Include(artista => artista.Musicas).FirstOrDefault(a => a.Nome ==nome);
        }

       public Artista BuscarPeloid(int id,bool Tracking=true){

            return Tracking?
            _contexto.Artistas.Include(artista => artista.Musicas).FirstOrDefault(m=> m.Id == id):
            _contexto.Artistas.AsNoTracking().Include(artista => artista.Musicas).FirstOrDefault(m=> m.Id == id);
       }

    
        public void RemoverArtista(Artista artista){
            _contexto.Remove(artista);
            _contexto.SaveChanges();
        }

        public void AtualizarArtista(){

            _contexto.SaveChanges();
        }

        public List<Artista> ListarArtistacommusica(){

            return _contexto.Artistas
            .Include(artista => artista.Musicas)
            .AsNoTracking().
            ToList();

            
        }
    }
}