using Microsoft.AspNetCore.Mvc;

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
    }
}
