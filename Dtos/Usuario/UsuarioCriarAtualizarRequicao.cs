using System.ComponentModel.DataAnnotations;

namespace PlayMax.Dtos.Usuario
{
    public class UsuarioCriarAtualizarRequicao
    {
         [Required (ErrorMessage = "{0} é obrigatorio")]
         [StringLength(45,MinimumLength = 3,ErrorMessage ="{0} deve ter entre {2} a {1} caracteres")]
        public string Nome{get;set;}

         [Required (ErrorMessage = "{0} é obrigatorio")]
         [StringLength(50,MinimumLength = 3,ErrorMessage ="{0} deve ter entre {2} a {1} caracteres")]
        public string Email{get;set;}

         [Required (ErrorMessage = "{0} é obrigatorio")]
         [StringLength(30,MinimumLength = 3,ErrorMessage ="{0} deve ter entre {2} a {1} caracteres")]
        public string Telefone{get;set;}

         [Required (ErrorMessage = "{0} é obrigatorio")]
         [StringLength(50,MinimumLength = 3,ErrorMessage ="{0} deve ter entre {2} a {1} caracteres")]
        public string Senha{get;set;}
    }
}