using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Service
{
    public class FinanceiroDbContextFactory : IDesignTimeDbContextFactory<FinanceiroDbContext>
    {
        //Vai árametrizar, criar o DBcontext para as migrations
        public FinanceiroDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FinanceiroDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\xmorn\\Documents\\financeiro_mvc.mdf;Integrated Security=True;Connect Timeout=30") ;
            return new FinanceiroDbContext(optionsBuilder.Options);
   
        }
    }
}
