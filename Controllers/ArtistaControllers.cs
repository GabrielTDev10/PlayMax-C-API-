using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayMax.Dtos.Artista;
using PlayMax.Services;

namespace PlayMax.Controllers
{
    [ApiController]
    [Route("Artistas")]
    
    public class ArtistaControllers : ControllerBase
    {
        private readonly ArtistaServico _artistaservico;

        public ArtistaControllers([FromServices]ArtistaServico servico){

            _artistaservico = servico;

        }

        [Authorize]
        [HttpPost]
        public ActionResult<ArtistaResposta> PostArtista(ArtistaCriarRequisicao novoArtista){

                var ArtistaResposta = _artistaservico.CriarArtista(novoArtista);
                return ArtistaResposta;
        }


        [Authorize]
        [HttpGet]
        public ActionResult<ArtistaResposta> GetArtista(){

            return Ok(_artistaservico.ListarArtista());
        }

        [Authorize]
        [HttpGet("{nome}")]
        public ActionResult<ArtistaResposta> GetArtistas([FromRoute]string nome){

            try{

                return Ok(_artistaservico.BuscarPeloNome(nome));
            }
            catch(Exception e){
                return NotFound(e.Message);
            }
        }


        [Authorize]
        [HttpDelete("{nome}")]
        public ActionResult DeletarArtista([FromRoute] string nome){

            try{
                _artistaservico.RemoverArtista(nome);
                return NoContent();
            }
            catch(Exception e){
                return  NotFound(e.Message);
            }
        }


        [Authorize]
        [HttpPut("{nome}")]
        public ActionResult<ArtistaResposta> PutArtista([FromRoute] string nome,[FromBody]ArtistaAtualizarRequisicao artistaeditado){
            try{
                return Ok(_artistaservico.AtualizarArtista(nome,artistaeditado));
            }
            catch(Exception e){
                return NotFound(e.Message);
            }
        }


        [Authorize]
        [HttpPut("{ArtistasId:int}/Musica/{MusicasId:int}")]
        public ActionResult<ArtistaResposta> PutArtistamusica([FromRoute]int ArtistasId,[FromRoute] int MusicasId){

                try{
                    return Ok(_artistaservico.AtribuirMusica(ArtistasId,MusicasId));
                }
                catch(BadHttpRequestException e){
                    return BadRequest(e.Message);
                }
                catch(Exception e){
                    return NotFound(e.Message);
                }

        }

       

    }
}