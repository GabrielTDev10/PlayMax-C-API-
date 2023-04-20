using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using PlayMax.Dtos.Musica;
using PlayMax.Models;
using PlayMax.Repositorios;

namespace PlayMax.Services
{
    public class MusicaServico
    {
        private readonly MusicaRepositorio _musicarepositorio;

        public MusicaServico([FromServices]MusicaRepositorio repositorio){

            _musicarepositorio = repositorio;
        }

        public MusicaResposta CriarMusica(MusicaCriarRequisicao NovoMusica){

            var musica = NovoMusica.Adapt<Musica>();

            musica = _musicarepositorio.CriarMusica(musica);

            var MusicaResposta = musica.Adapt<MusicaResposta>();

            return MusicaResposta;

        }

        public List<MusicaResposta> ListarMusicas(){

            return _musicarepositorio.ListarMusicas().Adapt<List<MusicaResposta>>();
        }

        public MusicaResposta BuscarPeloNome(string nome){

            return BuscarMusicaPeloNome(nome).Adapt<MusicaResposta>();
        }

        private Musica BuscarMusicaPeloNome(string nome,bool Tracking = true){

            var musica = _musicarepositorio.BuscarPeloNome(nome,Tracking);
            if(musica is null){
                throw new Exception("musica não encontrada");
            }

            return musica;

        }

        public void RemoverMusica(string nome){
            var musica = BuscarMusicaPeloNome(nome);

            _musicarepositorio.RemoverMusica(musica);

        }

        public MusicaResposta AtualizarMusica(string nome, MusicaAtualizarRequisicao musicaeditada){

            var musica = BuscarMusicaPeloNome(nome);

            musicaeditada.Adapt(musica);

            _musicarepositorio.AtualizarMusica();

            var MusicaResposta = musica.Adapt<MusicaResposta>();

            return MusicaResposta;
        }
    
    }
}