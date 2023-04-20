using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayMax.Dtos.Usuario;
using PlayMax.Services;

namespace PlayMax.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AutenticacaoController : ControllerBase
    {
        private readonly AutenticacaoServico _autenticacaoservico;


        public AutenticacaoController([FromServices]AutenticacaoServico servico){

            _autenticacaoservico = servico;

        }

        [HttpPost]
        public ActionResult<string> Login([FromBody]UsuarioLoginRequisicao usuarioLogin){

            try{
                var tokenJWT = _autenticacaoservico.Login(usuarioLogin);

                return Ok(tokenJWT);
            }
            catch(Exception e){
                return NotFound(e.Message);
            }

        }

    }
}