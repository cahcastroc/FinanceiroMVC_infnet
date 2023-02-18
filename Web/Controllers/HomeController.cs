using Financeiro.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITipoInvestimentoService _service;

        public HomeController(ILogger<HomeController> logger, ITipoInvestimentoService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            var investimentos = _service.GetAll();
            return View(investimentos);
        }

        //Usando QueryString - vamos tbm definir a estrutura da rota
        [Route("/home/data/{data}")]
        public IActionResult Data(string data)
        {
            //armazenar a data em uma sessão
            HttpContext.Session.SetString("DataAcesso", data);
            return View();
        }

        [Route("/home/resultado")]
        public IActionResult Resultado()
        {
            //Para recuperar o resultado da sessão

            var dataEmSession = HttpContext.Session.GetString("DataAcesso");
            return View("Resultado", dataEmSession);
        }
    }
}