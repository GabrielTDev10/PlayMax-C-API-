using Microsoft.AspNetCore.Mvc;
using PlayMax.Dtos.Usuario;
using PlayMax.Services;

namespace PlayMax.Controllers
{
    [ApiController]
    [Route("Usuarios")]

    public class UsuarioController : ControllerBase
    {

        private readonly UsuarioServico _UsuarioServico;

        public UsuarioController([FromServices] UsuarioServico servico){

            _UsuarioServico = servico;

        }

        [HttpPost]

        public ActionResult<UsuarioResposta>  PostUsuario([FromBody] UsuarioCriarAtualizarRequicao NovoUsuario){

            try{
                 var UsuarioResposta = _UsuarioServico.CriarUsuario(NovoUsuario);
                 return StatusCode(201,UsuarioResposta);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
           
         

        //    return StatusCode(201,UsuarioResposta);
            //   return CreatedAtAction(nameof(GetUsuario), new{ id = UsuarioResposta.Id }, UsuarioResposta );
        }
        
        [HttpGet]
       
        public ActionResult<List<UsuarioResposta>>  GetUsuarios(){


            return Ok(_UsuarioServico.ListarUsuario()) ;
        
        }
 
        [HttpGet("{id:int}")]
        public ActionResult<UsuarioResposta>  GetUsuario([FromRoute]int id){

            try{
                 return Ok(_UsuarioServico.BuscarUsuarioporid(id)) ;
            }
            catch(Exception e){
                return NotFound(e.Message);
            }

           

        }
        
        [HttpDelete("{id:int}")]
        public ActionResult DeleteUsuario([FromRoute] int id){

            try{
                _UsuarioServico.RemoverUsuario(id);
                return NoContent();
            }
            catch(Exception e){
                return NotFound(e.Message);
            }


            
        }

        [HttpPut("{id:int}")]
        public ActionResult<UsuarioResposta> PutUsuario([FromRoute] int id,[FromBody] UsuarioCriarAtualizarRequicao usuarioEditado){

            try{
                 return Ok(_UsuarioServico.AtualizarUsuario(id,usuarioEditado));
            }
            catch(Exception e){
                return NotFound(e.Message);
            }

               
        }
    }
}