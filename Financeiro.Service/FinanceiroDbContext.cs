using Financeiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Service
{
    public class FinanceiroDbContext : DbContext
    {
        //Definir as tabelas e datasets
        public FinanceiroDbContext(DbContextOptions contextOptions): base(contextOptions) { }
       
        public DbSet<TipoInvestimentos> tipoInvestimento { get; set; }
        
    }
}
