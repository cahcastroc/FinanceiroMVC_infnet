using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Service.Services
{
    public class TipoInvestimentoService : ITipoInvestimentoService
    {
        private readonly FinanceiroDbContext _dbContext;

        public TipoInvestimentoService(FinanceiroDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<TipoInvestimentos> GetAll()
        {
            return _dbContext.tipoInvestimento.ToList();
        }
    }
}
