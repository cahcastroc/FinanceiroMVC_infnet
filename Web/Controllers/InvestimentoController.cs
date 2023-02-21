using Financeiro.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class InvestimentoController : Controller
    {

        private readonly ITipoInvestimentoService _service;
      
        public InvestimentoController(ITipoInvestimentoService service)
        {
            _service = service;
        }

        //Vai definir a sessão
        private void SetSession(List<int> selected) {

            var listaStringSelecionados = JsonConvert.SerializeObject(selected);
            HttpContext.Session.SetString("itensSelecionados",listaStringSelecionados);
        }

        private List<int> GetSelected()
        {
            var selecionadosSessao = HttpContext.Session.GetString("itensSelecionados");
            return JsonConvert.DeserializeObject<List<int>>(selecionadosSessao);
        }


        [Route("/investimento/listadeinvestimentos")]
        public IActionResult ListaDeInvestimentos()        {
           
            return View(_service.GetAll());
        }


        [HttpPost]
        [Route("/investimento/selecionar")]
        public IActionResult Selecionar(List<int>selected)
        {
            SetSession(selected);

            var listaInvestimentosSelecionados = _service.GetAllSelected(selected);

            return View(listaInvestimentosSelecionados);
        }
    }
}
