using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Server_Teste_Web_CSharp.Facade;

namespace Server_Teste_Web_CSharp.Controllers
{
    [ApiController]
    [Route("v2/pontosTuristicos")]
    [EnableCors("MyPolicy")]
    public class PontosController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public IActionResult Post()
        {

            //Lista dos campos do formulário
            string nome = Request.Form["txtNome"];
            string descricao = Request.Form["txtDescricao"];
            string localizacao = Request.Form["txtEnderdeco"];
            string cidade = Request.Form["cbCidade"];
            string estado = Request.Form["cbEstado"];

            return Ok(new PontoTuristicoFacade().CadastrarPontoTuristico(nome, descricao, localizacao, cidade, estado));
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok(new PontoTuristicoFacade().Listar());
        }
    }
}
