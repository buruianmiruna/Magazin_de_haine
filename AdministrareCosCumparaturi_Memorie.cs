using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_de_haine
{
    class AdministrareCosCumparaturi_Memorie
    {
        private const int NR_MAX_PRODUSE= 50;

        private Produs[] produse;
        private int nr_produse;

        public AdministrareCosCumparaturi_Memorie()
        {
            produse = new Produs[NR_MAX_PRODUSE];
            nr_produse = 0;
        }

        public void AdaugaProdus(Produs produs)
        {
            produse[nr_produse] = produs;
            nr_produse++;
        }

        public Produs[] GetProduse(out int nr_produse)
        {
            nr_produse = this.nr_produse;
            return produse;
        }
    }
}
