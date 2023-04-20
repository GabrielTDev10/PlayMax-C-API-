using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayMax.Models
{
    public class Genero
    {

        [Required]
        public int Id{get;set;}

        [Required]
        [Column (TypeName ="varchar(100)")]
        public string Nome{get;set;}

        [Required]
        [Column (TypeName ="varchar(100)")]
        public string Descricao {get;set;}

        public List<Musica> Musicas{get;set;}

    }
}