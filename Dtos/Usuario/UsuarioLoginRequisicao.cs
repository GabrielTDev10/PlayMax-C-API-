using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlayMax.Dtos.Usuario
{
    public class UsuarioLoginRequisicao
    {
        [Required]
        [Column (TypeName ="varchar(50)")]
        public string Email{get;set;}

         [Required]
        [Column (TypeName ="varchar(50)")]
        public  string Senha{get;set;}

    }
}