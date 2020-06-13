using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class Produto : Base.Entity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
