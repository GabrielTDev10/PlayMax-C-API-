using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayMax.Dtos.Favorito;
using PlayMax.Services;

namespace PlayMax.Controllers
{
    [ApiController]
    [Route("Favoritos")]

    public class FavoritoControllers : ControllerBase
    {
        
        private readonly FavoritoServico _favoritoservico;

        public FavoritoControllers([FromServices]FavoritoServico servico){

            _favoritoservico = servico;
        }


        [Authorize]
        [HttpPost]
        public ActionResult<FavoritoResposta> PostFavorito(FavoritoCriarRequisicao novoFavorito){

            var FavoritoResposta = _favoritoservico.CriarFavorito(novoFavorito);
            return FavoritoResposta;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<FavoritoResposta> GetFavoritos(){

            return Ok(_favoritoservico.ListarFavoritos());
        }

        [Authorize]
        [HttpGet("{id:int}")]

        public ActionResult<FavoritoResposta> Getfavoritos([FromRoute]int id){
            try{
                return Ok(_favoritoservico.BuscarpeloId(id));
            }
            catch(Exception e){
                return NotFound(e.Message);
            }
        }


        [Authorize]
        [HttpDelete("{id:int}")]
        public ActionResult DeletarFavorito([FromRoute]int id){
            try{
                _favoritoservico.RemoverFavorito(id);
                return NoContent();
            }
            catch(Exception e){
                return NotFound(e.Message);

            }
        }


        [Authorize]
        [HttpPut("{id:int}")]
        public ActionResult<FavoritoResposta> PutFavorito([FromRoute]int id,[FromBody]FavoritoAtualizarRequisicao favoritoeditado){
            try{
                return Ok(_favoritoservico.AtualizarFavorito(id,favoritoeditado));
            }
            catch(Exception e){
                return NotFound(e.Message);
            }
        }


        [Authorize]
        [HttpPut("{FavoritosId:int}/Musica/{MusicasId:int}")]
        public ActionResult<FavoritoResposta> PutFavoritosMusicas([FromRoute] int FavoritosId,[FromRoute] int MusicasId){
            try{
                return Ok(_favoritoservico.AtribuirFavorito(FavoritosId,MusicasId));
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