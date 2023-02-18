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

        public IActionResult Privacy()
        {
            return View();
        }       
    }
}