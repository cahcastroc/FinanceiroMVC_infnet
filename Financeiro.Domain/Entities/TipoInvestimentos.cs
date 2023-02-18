using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Domain.Entities
{
    public class TipoInvestimentos
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string? Descricao { get; set; }
        public string? DescricaoLonga { get; set; }
        public bool Active { get; set; }

    }
}
