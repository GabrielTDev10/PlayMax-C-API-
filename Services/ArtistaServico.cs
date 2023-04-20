using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using PlayMax.Dtos.Artista;
using PlayMax.Models;
using PlayMax.Repositorios;

namespace PlayMax.Services
{
    public class ArtistaServico
    {
        private readonly ArtistaRepositorio _artistarepositorio;

        private readonly ArtistaMusicaRepositorio _artistamusicarepositorio;
      

        public ArtistaServico([FromServices]ArtistaRepositorio repositorio, [FromServices]ArtistaMusicaRepositorio mrepositorio){

            _artistarepositorio = repositorio;
            _artistamusicarepositorio = mrepositorio;

        }

        public ArtistaResposta CriarArtista(ArtistaCriarRequisicao novoArtista){

                var artista = novoArtista.Adapt<Artista>();

                artista = _artistarepositorio.CriarArtista(artista);

                var ArtistaResposta = artista.Adapt<ArtistaResposta>();

                return ArtistaResposta;
        }

        public List<ArtistaResposta> ListarArtista(){

            return _artistarepositorio.ListarArtista().Adapt<List<ArtistaResposta>>();
        }

        public ArtistaResposta BuscarPeloNome(string nome){

            return BuscarArtistaPeloNome(nome).Adapt<ArtistaResposta>();
        }

        public ArtistaResposta BuscarPeloid(int id){

            return BuscarArtistaPeloid(id).Adapt<ArtistaResposta>();
        }

       

        private Artista BuscarArtistaPeloNome(string nome,bool Tracking=true){

            var artista = _artistarepositorio.BuscarPeloNome(nome,Tracking);

            if(artista is null){
                throw new Exception("Artista não Encontrado");
            }

            return artista;
        }

        private Artista BuscarArtistaPeloid(int id,bool Tracking=true){

            var artista= _artistarepositorio.BuscarPeloid(id,Tracking);

            if(artista is null){
                throw new Exception("Artista não encontrado");
            }

            return artista;

        }



        public void RemoverArtista(string nome){
            var artista = BuscarArtistaPeloNome(nome);

            _artistarepositorio.RemoverArtista(artista);
        }

        public ArtistaResposta AtualizarArtista(string nome,ArtistaAtualizarRequisicao artistaeditado){

            var artista = BuscarArtistaPeloNome(nome);
            artistaeditado.Adapt(artista);
            _artistarepositorio.AtualizarArtista();

            var ArtistaResposta = artista.Adapt<ArtistaResposta>();

            return ArtistaResposta;
        }

        public ArtistaResposta AtribuirMusica(int ArtistasId,int MusicasId){


            var  artista = BuscarArtistaPeloid(ArtistasId);

            var musica = _artistamusicarepositorio.BuscarMusicaPeloId(MusicasId);


            if(musica is null){
                throw new Exception("Musica não encontrada");
            }
            if(artista.Musicas.Exists(musica => musica.Id == MusicasId)){
                throw new BadHttpRequestException("Musica já esta associado");
            }

            artista.Musicas.Add(musica);


            _artistarepositorio.AtualizarArtista();


            return  artista.Adapt<ArtistaResposta>();

          


        }

      
    }
}