using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayMax.Dtos.Musica
{
    public class MusicaCriarRequisicao
    {
        public int Id {get;set;}

        public string Nome{get;set;}

        public DateTime Data_lanc_Musica {get;set;}

        public string URL {get;set;}

        public int UsuarioId{get;set;}

        public int GeneroId{get;set;}
    }
}