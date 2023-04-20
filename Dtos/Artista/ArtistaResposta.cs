using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayMax.Dtos.Musica;

namespace PlayMax.Dtos.Artista
{
    public class ArtistaResposta
    {
        
         public string Id{get;set;}


         public string Nome {get;set;}

        public List<MusicaResposta> Musicas {get;set;}

    }

     public class MusicaResposta
    {
        public int Id {get;set;}

        public string Nome{get;set;}

        public DateTime Data_lanc_Musica {get;set;}

        public string URL {get;set;}

         public int UsuarioId{get;set;}

         public int GeneroId{get;set;}

    }

 
    
}