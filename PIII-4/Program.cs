using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Transactions;

namespace PIII4
{
    class Program
    {
        public class Lokalizacja
        {
            public int Regal { get; }
            public int Polka { get; }
            public int Miejsce { get; }

            public Lokalizacja(int regal, int polka, int miejsce)
            {
                Regal = regal + 1;
                Polka = polka + 1;
                Miejsce = miejsce + 1;
            }
            public string ZwrocLokalizacje()
            {
                return "[" + Regal + ", " + Polka + ", " + Miejsce + "]";
            }
        }
        public class Ksiazka
        {
            public Lokalizacja Lokalizacja { get; }
            public string Tytul { get; private set; }
            public string Autor { get; private set; }

            public Ksiazka(string tytul, string autor, Lokalizacja lokalizajca)
            {
                Tytul = tytul;
                Autor = autor;
                Lokalizacja = lokalizajca;
            }
            public void ZmienKsiazke()
            {
                Console.WriteLine("Podaj nowy tytul: ");
                Tytul = Console.ReadLine();
                Console.WriteLine("Podaj nowego autora: ");
                Autor = Console.ReadLine();
            }
            public string ZwrocDaneKsiazki()
            {
                return this.Tytul + ", " + this.Autor + this.Lokalizacja.ZwrocLokalizacje();
            }
        }

        public class Biblioteka
        {
            public Ksiazka[,,] biblioteka;
            public Biblioteka(int ileKsiazek)
            {
                int polki = ileKsiazek / 10;
                int regaly = polki / 6;
                Random random = new Random();
                string[] imie = new string[] { "Jan ", "Adam ", "Jozef ", "Marek ", "Olaf ", "Stefan ", "Juliusz ", "Bartosz ", "Ludwik ", "Arkadiusz ", "Bonifacy " };
                string[] nazwisko = new string[] { "Mickiewicz", "Slowacki", "Tokarczuk", "Kowalski", "Nowak", "Dorbasz", "Krecichwost", "Bajdusz", "Bambaryla" };
                string[] ptytul = new string[] { "Za ", "Pod ", "Nad ", "Przeminelo pod ", "Spotkanie za ", "Spotkanie na ", "Spotkanie pod " };
                string[] stytul = new string[] { "szarym ", "jesiennym ", "zapomnianym ", "zielonym ", "spoznionym ", "nieznanym ", "zatloczonym ", "opuszczonym ", "zimowym ", "letnim ", "wiosennym ", "spektakularnym ", "zjawiskowym " };
                string[] ttytul = new string[] { "Wzgorzem", "Potokiem", "Palacem", "Lodowcem", "Okretem" };
                Console.WriteLine($"Liczba regalow: {regaly}, liczba polek: {polki}");
                biblioteka = new Ksiazka[regaly, 6, 10];
                for (int i = 0; i < regaly; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            biblioteka[i, j, k] = new Ksiazka(ptytul[random.Next(ptytul.Length)] +
                                stytul[random.Next(0, stytul.Length)] + ttytul[random.Next(ttytul.Length)]
                                , imie[random.Next(imie.Length)] + nazwisko[random.Next(nazwisko.Length)], new Lokalizacja(i, j, k));
                        }
                    }
                }
            }
        }
        static void ZnajdzKsiazki(Biblioteka ksiegozbior)
        {
            bool znaleziono = false;
            List<Ksiazka> ksiazki = new List<Ksiazka>();
            List<Ksiazka> temp;
            foreach (var ksiazka in ksiegozbior.biblioteka)
            {
                ksiazki.Add(ksiazka);
            }
            temp = PrzeszukajListe(ksiazki);
            while (!znaleziono)
            {
                if (temp.Count == 1)
                {
                    znaleziono = true;
                }
                else
                {
                    temp = PrzeszukajListe(temp);
                }
            }
            foreach (var ksiazka in ksiegozbior.biblioteka)
            {
                if (temp[0].Lokalizacja == ksiazka.Lokalizacja)
                {
                    ksiazka.ZmienKsiazke();
                }
            }
        }
        static List<Ksiazka> PrzeszukajListe(List<Ksiazka> ksiazki)
        {
            int licznik = 0;
            List<Ksiazka> ksiazkas = new List<Ksiazka>();
            while (true)
            {
                Console.WriteLine("Podaj szukana fraze lub lokalizacje odzielona przecinkami: ");
                string tekst = Console.ReadLine(); ;
                Console.WriteLine();
                foreach (var ksiazka in ksiazki)
                {
                    if (ksiazka.Autor.ToLower().Contains(tekst.ToLower()) |
                        ksiazka.Tytul.ToLower().Contains(tekst.ToLower()) |
                        ksiazka.Lokalizacja.ZwrocLokalizacje().Contains(tekst))
                    {
                        ksiazkas.Add(ksiazka);
                        licznik++;
                        Console.WriteLine(ksiazka.ZwrocDaneKsiazki());
                    }
                }
                if (licznik > 0)
                {
                    return ksiazkas;
                }
                else if (licznik == 0)
                {
                    Console.WriteLine($"Nie znaleziono tytulow zawierajacych podana fraze w powyzszej liscie");
                }
            }
        }

        static void Main(string[] args)
        {
            bool znaleziono = false;
            Biblioteka ksiegozbior = new Biblioteka(90);
            while (!znaleziono)
            {
                foreach (var ksiazka in ksiegozbior.biblioteka)
                {
                    Console.WriteLine(ksiazka.ZwrocDaneKsiazki());
                }
                ZnajdzKsiazki(ksiegozbior);
                Console.WriteLine("Wcisnij 'y' jesli zakonczyc, cokolwiek aby kontynuowac");
                string input = Console.ReadLine();
                if (input == "y")
                {
                    znaleziono = true;
                }
            }
        }
    }
}