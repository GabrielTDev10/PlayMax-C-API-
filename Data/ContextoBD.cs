using Microsoft.EntityFrameworkCore;
using PlayMax.Models;

namespace PlayMax
{
    public class ContextoBD : DbContext
    {

        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios {get;set;}

        public DbSet<Musica> Musicas{get;set;}

        public DbSet<Genero> Generos {get;set;}


        public DbSet<Favorito> Favoritos {get;set;}

        public DbSet<Artista> Artistas {get;set;}

    }
}