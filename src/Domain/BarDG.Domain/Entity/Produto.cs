using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class Produto : Base.Entity, IEquatable<Produto>
    {
        public virtual string Descricao { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual int CompraMaxima { get; set; }

        public bool Equals([AllowNull] Produto other)
        {
            if (other == null)
                return false;

            return other.Id == this.Id;
        }
    }
}
