using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class Promocao : Base.Entity
    {
        public virtual IEnumerable<PromocaoItem> ItensAtivadores { get; set; }
        public virtual Produto ItemDesconto { get; set; }
        public virtual decimal Desconto { get; set; }
        public virtual bool DescontoMaximo { get; set; }
        public virtual bool RepetirPromocao { get; set; }

        public bool PromocaoValida(Comanda comanda)
        {
            var promoValida = true;
            foreach (var item in ItensAtivadores)
            {
                var itemComanda = comanda.Itens.FirstOrDefault(x => x.Produto == item.Item);
                if(itemComanda == null)
                {
                    promoValida = false;
                    break;
                }

                promoValida = itemComanda.Quantidade >= item.Quantidade;

            }

            return promoValida;
        }

        public int RepetirXVezes(Comanda comanda)
        {
            if (!RepetirPromocao)
            {
                AddNotification("RepetirXVezes(comanda)", "Promoção não deve ser repetida na mesma comanda");
                return 0;
            }

            var repetirPromo = 0;
            foreach (var item in ItensAtivadores)
            {
                var itemComanda = comanda.Itens.FirstOrDefault(x => x.Produto == item.Item);
                if (itemComanda == null)
                {
                    AddNotification("RepetirXVezes(comanda)", "Item ativador de preomoção não encontrado");
                    return 0;
                }

                var repetir = itemComanda.Quantidade / item.Quantidade;
                if ( repetirPromo == 0 || repetirPromo > repetir)
                    repetirPromo = repetir;
            }

            return repetirPromo;
        }

        public decimal ValorDesconto => DescontoMaximo ? ItemDesconto.Valor
                                                       : Desconto;
    }
}
