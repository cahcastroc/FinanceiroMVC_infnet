using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class InvestimentoController : Controller
    {

        private readonly ITipoInvestimentoService _service;
        private readonly IMemoryCache _memoryCache;
      
        public InvestimentoController(ITipoInvestimentoService service,IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
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

            if (string.IsNullOrEmpty(selecionadosSessao)) {
                return new List<int>();
            }
            return JsonConvert.DeserializeObject<List<int>>(selecionadosSessao);
        }

        //Método que vai retornar a lista de investimentos adotando a estratégia de cache

        private IList<TipoInvestimentos> listaEmCache() {

           return _memoryCache.GetOrCreate<List<TipoInvestimentos>>("GetAllInvestimentos", options =>{
               options.SlidingExpiration= TimeSpan.FromSeconds(10);
               options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
               return _service.GetAll().ToList();

            });
            
        }


        [Route("/investimento/listadeinvestimentos")]
        public IActionResult ListaDeInvestimentos()        
        {
            var listaInvestimentos = listaEmCache();
            var selecionados = GetSelected();
            foreach(var tipoInvestimento in listaInvestimentos)
            {
                tipoInvestimento.Active = selecionados.Contains(tipoInvestimento.Id);
            }
            return View(listaInvestimentos);
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
