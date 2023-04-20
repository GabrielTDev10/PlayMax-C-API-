using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using PlayMax.Dtos.Genero;
using PlayMax.Models;
using PlayMax.Repositorios;

namespace PlayMax.Services
{
    public class GeneroServico
    {
        private readonly GeneroRepositorio _generorepositorio;

        public GeneroServico(GeneroRepositorio repositorio){
            
            _generorepositorio = repositorio;
        }

        public GeneroResposta CriarGenero(GeneroCriarRequisicao NovoGenero){

            var genero = NovoGenero.Adapt<Genero>();

            genero = _generorepositorio.CriarGenero(genero);

            var GeneroResposta =  genero.Adapt<GeneroResposta>();

            return GeneroResposta;
        }

        public List<GeneroResposta> ListarGeneros(){

            return _generorepositorio.ListarGeneros().Adapt<List<GeneroResposta>>();
        }

       public GeneroResposta BuscarPeloNome(string nome){

            return BuscargeneroPeloNome(nome).Adapt<GeneroResposta>();
       }

       private Genero BuscargeneroPeloNome(string nome,bool Tracking = true){

                var genero = _generorepositorio.BuscarPeloNome(nome,Tracking);

                if(genero is null){
                    throw new Exception("Genero não encontrado");
                }

                return genero;
       }

       public void RemoverGenero(string nome){

        var genero = BuscargeneroPeloNome(nome);

        _generorepositorio.RemoverGenero(genero);


       }

       public GeneroResposta AtualizarGenero(string nome, GeneroAtualizarRequisicao generoeditado){
            
            var genero = BuscargeneroPeloNome(nome);

            generoeditado.Adapt(genero);

            _generorepositorio.AtualizarGenero();

            var GeneroResposta = genero.Adapt<GeneroResposta>();

            return GeneroResposta; 
       }

    }


}