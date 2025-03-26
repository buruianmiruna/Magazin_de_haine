using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_de_haine
{
    //LABORATOR 1
    class Program
    {
        static void Main()
        {
            string numeFisierClienti = ConfigurationManager.AppSettings["NumeFisierClienti"];
            string numeFisierProduse = ConfigurationManager.AppSettings["NumeFisierProduse"];
            AdministrareClienti_FisierText adminClienti = new AdministrareClienti_FisierText(numeFisierClienti);
            AdministrareCosCumparaturi_FisierText adminProduse = new AdministrareCosCumparaturi_FisierText(numeFisierProduse);
            Client clientNou = new Client();
            int nrClienti = 0;
            string optiune;
            do
            {
                Console.WriteLine("C. Citire informatii client de la tastatura");
                Console.WriteLine("I. Afisarea informatiilor despre ultimului client introdus");
                Console.WriteLine("A. Afisare clienti din fisier");
                Console.WriteLine("S. Salvare client in fisier");
                Console.WriteLine("M. Meniu client");
                Console.WriteLine("X. Inchidere program");

                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        clientNou = new Client(++nrClienti,"nume", "prenume","0787878787",12,12,1212);
                        //clientNou = CitireClientTastatura();
                        break;
                    case "I":
                        AfisareClient(clientNou);
                        break;
                    case "A":
                        Client[] clienti = adminClienti.GetClienti(out nrClienti);
                        AfisareClienti(clienti, nrClienti);
                        break;
                    case "S":
                        int idClient = ++nrClienti;
                        clientNou.IdClient = idClient;
                        //adaugare client in fisier
                        adminClienti.AddClient(clientNou);
                        break;
                    case "M":
                        MeniuClient(clientNou);
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }

        public static Client CitireClientTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele");
            string prenume = Console.ReadLine();

            Console.WriteLine("Introduceti numarul de telefon");
            string nr_telefon = Console.ReadLine();

            int[] data_nasterii = new int[3];

            Console.WriteLine("Introduceti ziua de nastere");
            data_nasterii[0] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduceti luna de nastere");
            data_nasterii[1] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduceti anul de nastere");
            data_nasterii[2] = Convert.ToInt32(Console.ReadLine());

            Client client = new Client(0, nume, prenume, nr_telefon, data_nasterii[0], data_nasterii[1], data_nasterii[2]);

            return client;
        }

        public static void AfisareClient(Client client)
        {
            string dataNasterii = string.Join("/", client.GetData_nasterii());
            string infoClient = string.Format("Clientul cu id-ul #{0} are numele: {1} {2}, numar de telefon: {3}, data nasterii: {4}",
                    client.IdClient,
                    client.nume ?? " NECUNOSCUT ",
                    client.prenume ?? " NECUNOSCUT ",
                    client.nr_telefon ?? " NECUNOSCUT ",
                    dataNasterii);

            Console.WriteLine(infoClient);
        }

        public static void AfisareClienti(Client[] clienti, int nrClienti)
        {
            Console.WriteLine("Clientii sunt:");
            for (int contor = 0; contor < nrClienti; contor++)
            {
                string infoClient = clienti[contor].Info();
                Console.WriteLine(infoClient);
            }
        }

        public static void MeniuClient(Client client)
        {
            Client clientNou = new Client(client);
            CosCumparaturi cos = new CosCumparaturi(10);
            int idProdus = 0;
            string optiune;
            do
            {
                Console.WriteLine("MENIU CLIENT");
                Console.WriteLine("1. Adauga produs in cos");
                Console.WriteLine("2. Afiseaza cosul");
                Console.WriteLine("3. Cauta produs in cos");
                Console.WriteLine("4. Inapoi la meniul principal");

                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();

                switch (optiune)
                {
                    
                    case "1":
                        ++idProdus;
                        Console.WriteLine("Introduceti denumirea produsului");
                        string denumire = Console.ReadLine();

                        Console.WriteLine("Introduceti culoarea produsului");
                        string culoare = Console.ReadLine();

                        Console.WriteLine("Introduceti marimea produsului");
                        string marime = Console.ReadLine();

                        Console.WriteLine("Introduceti pretul produsului");
                        int pret = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Introduceti stocul produsului");
                        int stoc = Convert.ToInt32(Console.ReadLine());

                        Produs produs = new Produs(idProdus, denumire, culoare, marime, pret, stoc);
                        cos.AdaugaProdus(produs);
                        break;

                    case "2":
                        Console.WriteLine($"Cosul de cumparaturi al clientului: {clientNou.nume + " " + clientNou.prenume}");
                        cos.AfiseazaCos();
                        break;
                    case "3":
                        Console.WriteLine("Introduceti numele produsului de cautat");
                        string numeCautat = Console.ReadLine();
                        cos.CautaProdus(numeCautat);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune != "4");

        }
    }
}
