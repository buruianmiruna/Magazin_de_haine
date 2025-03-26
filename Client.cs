using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_de_haine
{
    //LABORATOR 1
    public class Client
    {
        //constante folosite pentru scrierea in fisier
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';

        private const int ID = 0;
        private const int NUME = 1;
        private const int PRENUME = 2;
        private const int NR_TELEFON = 3;

        //data membra privata
        int[] data_nasterii;

        //declararea campurilor pentru client
        //proprietati auto-implemented
        public int IdClient { get; set; } //identificator unic client
        public string nume { get; set; }
        public string prenume { get; set; }
        public string nume_complet { get; set; }
        public string nr_telefon { get; set; }

        public void SetData_nasterii(int[] _data_nasterii)
        {
            data_nasterii = new int[_data_nasterii.Length];
            _data_nasterii.CopyTo(_data_nasterii, 0);
        }

        public int[] GetData_nasterii()
        {
            // returneaza o copie a vectorului, astfel încât utilizatorii acestei 
            // clase să nu poata modifica în mod direct conținutul vectorului 
            return (int[])data_nasterii.Clone();
        }

        //constructor implicit
        public Client()
        {
            nume = prenume = nume_complet = nr_telefon = string.Empty;
            data_nasterii = new int[3];
        }

        public Client(Client client)
        {
            this.IdClient = client.IdClient;
            this.nume = client.nume;
            this.prenume = client.prenume;
            this.nume_complet = client.nume_complet;
            this.nr_telefon = client.nr_telefon;
            this.data_nasterii = new int[client.data_nasterii.Length];
            client.data_nasterii.CopyTo(this.data_nasterii, 0);
        }

        //constructor cu parametrii
        public Client(string nume_complet, string nr_telefon)
        {
            this.nume_complet = nume_complet;
            this.nr_telefon = nr_telefon;
            data_nasterii = new int[3];
        }

        public Client(int IdClient, string nume, string prenume, string nr_telefon, int zi, int luna, int an)
        {
            this.IdClient = IdClient;
            this.nume = nume;
            this.prenume = prenume;
            this.nume_complet = nume + prenume;
            this.nr_telefon = nr_telefon;
            data_nasterii = new int[] { zi, luna, an };
        }

        public string Info_Nume_Complet()
        {
            return $"Nume complet: {nume_complet}, Numar telefon: {nr_telefon}";
        }

        public string Info()
        {
            return $"Id:{IdClient} Nume complet: {nume} {prenume}, Numar telefon: {nr_telefon}, Data_n: {String.Join("/", data_nasterii)};";
        }

        //constructor cu un singur parametru de tip string care reprezinta o linie dintr-un fisier text
        public Client(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier
            IdClient = Convert.ToInt32(dateFisier[ID]);
            this.nume = dateFisier[NUME];
            this.prenume = dateFisier[PRENUME];
            this.nr_telefon = dateFisier[NR_TELEFON];

            // Preluare data nasterii
            if (!string.IsNullOrEmpty(dateFisier[4]))
            {
                string[] vData_nasterii = dateFisier[4].Split('/');
                data_nasterii = new int[vData_nasterii.Length];
                for (int i = 0; i < vData_nasterii.Length; i++)
                {
                    data_nasterii[i] = Convert.ToInt32(vData_nasterii[i]);
                }
            }
            else
            {
                data_nasterii = new int[0]; 
            }
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectClientPentruFisier = string.Format("{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                SEPARATOR_SECUNDAR_FISIER,
                IdClient,
                (nume ?? " NECUNOSCUT "), //Utilizarea ?? este pentru a verifica dacă un câmp este null și, dacă este, să afișeze "NECUNOSCUT".
                (prenume ?? " NECUNOSCUT "),
                nr_telefon,
                String.Join("/", data_nasterii));

            return obiectClientPentruFisier;
        }
        public override string ToString()
        {
            return Info();
        }
    }
  
}
