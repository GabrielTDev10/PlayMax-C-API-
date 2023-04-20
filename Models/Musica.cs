using System.ComponentModel.DataAnnotations;

namespace PlayMax.Models
{
    public class Musica
    {
        [Required]
        public int Id {get;set;}

        public string Nome{get;set;}

        public DateTime Data_lanc_Musica {get;set;}

        public string URL {get;set;}

        //propriedade de navegacao
        public Usuario Usuario{get;set;}

        //chave estrangeira
        public int UsuarioId{get;set;}

        public List<Artista> Artistas{get;set;}

        public Genero Genero{get;set;}

       public int GeneroId{get;set;}

       public List<Favorito> Favoritos {get;set;}

    }
}