using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayMax.Dtos.Genero;
using PlayMax.Services;

namespace PlayMax.Controllers
{

    [ApiController]
    [Route("Generos")]
    public class GeneroControllers :ControllerBase
    {

        private readonly GeneroServico _generoservico;
        
        public GeneroControllers([FromServices] GeneroServico servico){

            _generoservico = servico;
        }

        [Authorize]
        [HttpPost]

        public ActionResult<GeneroResposta> PostGenero(GeneroCriarRequisicao novoGenero){

            var GeneroResposta = _generoservico.CriarGenero(novoGenero);
            return GeneroResposta;    
        
        }


       [Authorize]
       [HttpGet]

        public ActionResult<GeneroResposta> GetGenero(){
            return Ok(_generoservico.ListarGeneros());
        }


        [Authorize]
        [HttpGet("{nome}")] 
        public ActionResult<GeneroResposta> GetGeneros([FromRoute] string nome){
            try{
                return Ok(_generoservico.BuscarPeloNome(nome));
            }
            catch(Exception e){
                return NotFound(e.Message);
            }
        }


        [Authorize]
        [HttpDelete("{nome}")]
        public ActionResult DeletarGenero([FromRoute] string nome){

            try{
                _generoservico.RemoverGenero(nome);
                return NoContent();
            }
            catch(Exception e){
                return NotFound(e.Message);

            }

        
        }


        [Authorize]
        [HttpPut("{nome}")]
        public ActionResult<GeneroResposta> PutGenero([FromRoute] string nome,[FromBody]GeneroAtualizarRequisicao generoeditado){

            try{    
                return Ok(_generoservico.AtualizarGenero(nome,generoeditado));
            }
            catch(Exception e){
                return NotFound(e.Message);
            }
        }

     }
    
    
    
}