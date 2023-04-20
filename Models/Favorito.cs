using System.ComponentModel.DataAnnotations;

namespace PlayMax.Models
{
    public class Favorito
    {
        [Required]
       
        public int Id {get;set;}

       public Usuario usuario{get;set;}

       public int UsuarioId{get;set;}

       public List<Musica> Musicas {get;set;}

       
    }
}