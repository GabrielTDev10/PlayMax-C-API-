using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayMax.Dtos.Artista;
using PlayMax.Dtos.Favorito;

namespace PlayMax.Dtos.Musica
{
    public class MusicaResposta
    {
        public int Id {get;set;}

        public string Nome{get;set;}

        public DateTime Data_lanc_Musica {get;set;}

        public string URL {get;set;}

         public int UsuarioId{get;set;}

         public int GeneroId{get;set;}

        public List<ArtistaResposta> Artistas{get;set;}

       public List<FavoritoResposta> Favoritos {get;set;}
         

    }
}