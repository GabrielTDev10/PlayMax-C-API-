using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using PlayMax.Dtos.Favorito;
using PlayMax.Models;
using PlayMax.Repositorios;

namespace PlayMax.Services
{
    public class FavoritoServico
    {
        private readonly FavoritoRepositorio _favoritorepositorio;

        private readonly FavoritoMusicaRepositorio _favoritomusicarepositorio;

        public FavoritoServico([FromServices]FavoritoRepositorio repositorio,[FromServices] FavoritoMusicaRepositorio repositoriof){

            _favoritorepositorio = repositorio;
            _favoritomusicarepositorio = repositoriof;
        }
        
        public FavoritoResposta CriarFavorito(FavoritoCriarRequisicao NovoFavorito){

            var Favorito = NovoFavorito.Adapt<Favorito>();

            Favorito = _favoritorepositorio.CriarFavorito(Favorito);

            var FavoritoResposta = Favorito.Adapt<FavoritoResposta>();

            return FavoritoResposta;

        }

        public List<FavoritoResposta> ListarFavoritos(){

            return _favoritorepositorio.ListarFavoritos().Adapt<List<FavoritoResposta>>();
        }

        public FavoritoResposta BuscarpeloId(int id){

            return Buscarfavoritopeloid(id).Adapt<FavoritoResposta>();
        }

        private Favorito Buscarfavoritopeloid(int id,bool Tracking=true){

            var Favorito = _favoritorepositorio.BuscarPeloId(id,Tracking);

            if(Favorito is null){

                throw new Exception("Favorito não encontrado");

            }

            return Favorito;
        }

        public void RemoverFavorito(int id){

            var favorito = Buscarfavoritopeloid(id);
            _favoritorepositorio.RemoverFavorito(favorito);
        }

        public FavoritoResposta AtualizarFavorito(int id,FavoritoAtualizarRequisicao favoritoeditado){

            var Favorito = Buscarfavoritopeloid(id);
            favoritoeditado.Adapt(Favorito);
            _favoritorepositorio.AtualizarFavorito();

            var FavoritoResposta = Favorito.Adapt<FavoritoResposta>();

            return FavoritoResposta;
        }

        public FavoritoResposta AtribuirFavorito(int FavoritosId,int MusicasId){

            var favorito = Buscarfavoritopeloid(FavoritosId);

            var musica = _favoritomusicarepositorio.BuscarMusicaPeloidF(MusicasId);

            if(musica is null){
                throw new Exception("Musica não encontrada");
            }
            if(favorito.Musicas.Exists(musica => musica.Id == MusicasId )){
                    throw new BadHttpRequestException("Musica já associada");
            }

            favorito.Musicas.Add(musica);

            _favoritorepositorio.AtualizarFavorito();

            return favorito.Adapt<FavoritoResposta>();

        }

    }
}