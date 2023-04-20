using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayMax.Dtos.Musica;
using PlayMax.Services;

namespace PlayMax.Controllers

{
    [ApiController]
    [Route("Musica")]

    public class MusicaControllers : ControllerBase
    {

        private readonly MusicaServico _musicaservico;

        public MusicaControllers([FromServices] MusicaServico servico){

            _musicaservico = servico;
        }

        
        [Authorize]
        [HttpPost]

        public ActionResult<MusicaResposta> PostMusica(MusicaCriarRequisicao novomusica){

                var MusicaResposta = _musicaservico.CriarMusica(novomusica);

                return MusicaResposta;

        }

       [Authorize]
       [HttpGet]

       public ActionResult<MusicaResposta> GetMusicas(){

        return Ok(_musicaservico.ListarMusicas());
       }

        [Authorize]
        [HttpGet("{nome}")]

        public ActionResult<MusicaResposta> Getmusica([FromRoute] string nome){

            try{
                return Ok(_musicaservico.BuscarPeloNome(nome));
            }
            catch(Exception e){
                return NotFound(e.Message);
            }

        }

        [Authorize]
        [HttpDelete("{nome}")]
        public ActionResult DeletarMusica([FromRoute] string nome){

            try{
                _musicaservico.RemoverMusica(nome);
                return NoContent();
            }
            catch(Exception e){
                return NotFound(e.Message);
            }

        }

        [Authorize]
        [HttpPut("{nome}")]

        public ActionResult<MusicaResposta> PutMusica([FromRoute] string nome,[FromBody] MusicaAtualizarRequisicao musicaeditada){

            try{
                return Ok(_musicaservico.AtualizarMusica(nome,musicaeditada));
            }
            catch(Exception e){

                return NotFound(e.Message);

            }
        }
   
    }
}