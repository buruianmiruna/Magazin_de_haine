using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_de_haine
{
    
    public class Produs
    {
        //constante folosite pentru scrierea in fisier
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';

        private const int ID = 0;
        private const int DENUMIRE= 1;
        private const int CULOARE= 2;
        private const int MARIME= 3;
        private const int PRET = 4;
        private const int STOC = 5;

        int IdProdus;
        string denumire;
        string culoare;
        string marime;
        int pret;
        int stoc;


        public Produs()
        {
            IdProdus = 0;
            denumire = string.Empty;
            culoare = string.Empty;
            marime = string.Empty;
            pret = 0;
            stoc = 0;
        }
        public Produs(int _IdProdus, string _denumire, string _culoare, string _marime, int _pret, int _stoc)
        {
            IdProdus = _IdProdus;
            denumire = _denumire;
            culoare = _culoare;
            marime = _marime;
            pret = _pret;
            stoc = _stoc;
        }
        public string Info()
        {
            return $"Id: {IdProdus}, Denumire: {denumire}, Culoare: {culoare}, Marime: {marime}, Pret: {pret}, Stoc: {stoc}";
        }
        public Produs(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()

            this.denumire = dateFisier[DENUMIRE];
            this.culoare = dateFisier[CULOARE];
            this.marime = dateFisier[MARIME];
            this.pret = Convert.ToInt32(dateFisier[PRET]);
            this.stoc = Convert.ToInt32(dateFisier[STOC]);
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectClientPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                IdProdus,
                (denumire ?? " NECUNOSCUT "),
                (culoare ?? " NECUNOSCUT "),
                (marime ?? " NECUNOSCUT "),
                pret,
                stoc);

            return obiectClientPentruFisier;
        }
        public override string ToString()
        {
            return Info();
        }
    }



    //LABORATOR 2
    /*public class Produs
    {
        //proprietati auto-implemented
        public string denumire { get; set; }
        public string culoare { get; set; }
        public string marime { get; set; }
        public int pret { get; set; }
        public int stoc { get; set; }

        public Produs()
        {
            denumire = culoare = marime = string.Empty;
            pret = stoc = 0;
        }

        public Produs(string denumire, string culoare, string marime, int pret, int stoc)
        {
            this.denumire = denumire;
            this.culoare = culoare;
            this.marime = marime;
            this.pret = pret;
            this.stoc = stoc;
        }
        public string Info()
        {
            string info = $"Denumire: {denumire ?? "NECUNOSCUT"}, Culoare: {culoare ?? "NECUNOSCUT"}, Marime: {marime ?? "NECUNOSCUT"}, Pret: {pret}, Cantitate: {stoc}";
            return info;
        }


    }*/

}   



    
