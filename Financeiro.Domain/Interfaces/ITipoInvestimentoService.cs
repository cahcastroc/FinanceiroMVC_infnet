using Financeiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Domain.Interfaces
{
    public interface ITipoInvestimentoService
    {
        IList<TipoInvestimentos> GetAll();
        IList<TipoInvestimentos> GetAllSelected(List<int> selecionados);
    }
}
