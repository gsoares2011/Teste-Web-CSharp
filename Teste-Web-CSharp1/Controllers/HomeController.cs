using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Teste_Web_CSharp1.Facade;

namespace Teste_Web_CSharp1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [Route("pontosTuristicos")]
        public IActionResult Post()
        {
           
            //Lista dos campos do formulário
            string nome = Request.Form["txtNome"];
            string descricao = Request.Form["txtDescricao"];
            string localizacao = Request.Form["txtEnderdeco"];
            string cidade = Request.Form["cbCidade"];          
            string estado = Request.Form["cbEstado"];

            return Json(new PontoTuristicoFacade().CadastrarPontoTuristico(nome, descricao, localizacao, cidade, estado));
        }

        [HttpGet]
        [Route("pontosTuristicos")]
        public IActionResult Get()
        {
            return Json(new PontoTuristicoFacade().Listar());
        }
    }
}
