using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
