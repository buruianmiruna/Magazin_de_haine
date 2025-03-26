using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_de_haine
{
    public enum Culoare
    {
        Rosu,
        Albastru,
        Verde,
        Negru,
        Alb
    }

    public enum Marime
    {
        XS,
        S,
        M,
        L,
        XL
    }

    class CosCumparaturi
    {
        private List<Produs> produse;
        private int capacitate;

        public CosCumparaturi(int capacitate)
        {
            this.capacitate = capacitate;
            produse = new List<Produs>(capacitate);
        }

        public void AdaugaProdus(Produs produs)
        {
            if (produse.Count < capacitate)
            {
                produse.Add(produs);
                Console.WriteLine($"Produs adaugat: {produs.Info()}");
            }
            else
            {
                Console.WriteLine("Cosul este plin!");
            }
        }

        public void AfiseazaCos()
        {
            if (produse.Count == 0)
            {
                Console.WriteLine("Cosul este gol");
                return;
            }

            Console.WriteLine("\nCos:");
            for (int i = 0; i < produse.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {produse[i]}");
            }
        }

        public void CautaProdus(string numeCautat)
        {
            var produsGasit = produse.FirstOrDefault(a => a.Info().Contains(numeCautat));
            if (produsGasit != null)
            {
                Console.WriteLine($"Produsul '{numeCautat}' a fost gasit in cos: {produsGasit}");
            }
            else
            {
                Console.WriteLine($"Produsul '{numeCautat}' nu a fost gasit in cos.");
            }
        }
        /*
        // Atributele clasei
        private string[] produse; // vect pt numele produselor
        private int numarProduse; // cnt pt prod adaugate

        public CosCumparaturi(int capacitate)
        {
            produse = new string[capacitate]; 
            numarProduse = 0; //initializ
        }


        public void AdaugaProdus(string denumire)
        {
            if (numarProduse < produse.Length)
            {
                produse[numarProduse] = denumire;
                numarProduse++;
                Console.WriteLine($"produs adaugat: {denumire}");
            }
            else
            {
                Console.WriteLine("cosul este plin!");
            }


        }
        // Afișează conținutul coșului
        public void AfiseazaCos()
        {
            if (numarProduse == 0)
            {
                Console.WriteLine("cosul este gol");
                return;
            }

            Console.WriteLine("\ncos:");
            for (int i = 0; i < numarProduse; i++)
            {
                Console.WriteLine($"{i + 1}. {produse[i]}");
            }
        }
        public void CautaProdus(string numeCautat)
        {
            for (int i = 0; i < numarProduse; i++)
            {
                if (produse[i] == numeCautat) 
                {
                    Console.WriteLine($"produsul '{numeCautat}' a fost gasit în cos.");
                    return; // stop dupa  ce am gasit produsul
                }
            }

            Console.WriteLine($"produsul '{numeCautat}' nu a fost gasit în cos.");
        }

        */
    }
}
