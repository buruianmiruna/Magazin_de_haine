using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_de_haine
{
    class AdministrareCosCumparaturi_FisierText
    {
        private const int NR_MAX_PRODUSE= 50;
        private string numeFisierProduse;

        public AdministrareCosCumparaturi_FisierText(string numeFisierProduse)
        {
            this.numeFisierProduse = numeFisierProduse;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisierProduse, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AdaugaProdus(Produs produs)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierProduse, true))
            {
                streamWriterFisierText.WriteLine(produs.ConversieLaSir_PentruFisier());
            }
        }


        public Produs[] GetProduse(out int nr_produse)
        {
            Produs[] produse = new Produs[NR_MAX_PRODUSE];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisierProduse))
            {
                string linieFisier;
                nr_produse = 0;

                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    produse[nr_produse++] = new Produs(linieFisier);
                }
            }

            return produse;
        }
    }
}
