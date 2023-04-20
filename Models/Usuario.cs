using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PlayMax.Models
{
    [Index(nameof(Email), IsUnique = true)]

    public class Usuario
    {

        [Required]
        public int Id{get;set;}

        [Required]
        [Column (TypeName ="varchar(45)")]
        public string Nome{get;set;}

        [Required]
        [Column (TypeName ="varchar(50)")]
        public string Email{get;set;}

        [Required]
        [Column (TypeName ="varchar(30)")]
        public string Telefone{get;set;}

        [Required]
        [Column (TypeName ="varchar(50)")]
        public  string Senha{get;set;}

        public List<Musica> Musicas{get;set;}

        public List<Favorito> Favoritos{get;set;}
    
    }
}