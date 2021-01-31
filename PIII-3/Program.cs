using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace PIII3
{
    class Program
    {
        static void Main()
        {
            FormatZdania();
            SumaTablic();
        }

        private static void FormatZdania()
        {
            /*Funkcja która formatuje poprawne zdanie. 
             * Przyjmuje tekst; pierwszą literę zmienia na dużą 
             * a na końcu dodaje kropkę, jeśli jeszcze nie została tam umieszczona.
             */

            string input = Console.ReadLine();
            input = input.Trim();
            string def = input[0].ToString().ToUpper();
            for (int i = 1; i < input.Length; i++)
            {
                def += input[i];
            }
            if (def[^1] != '.')
            {
                def = def.Insert(def.Length, ".");
            }
            Console.WriteLine(def);
        }
        private static void SumaTablic()
        {
            /*Funkcja obliczająca sumę liczb w dwuwymiarowej tablicy poszarpanej. 
             * Tablicę może wypełniać użytkownik lub może być wypełniana automatycznie.
             */
            int[][] tablica = UtworzNowaTablice();
            WypelnienieTablicy(tablica);
            WyswietlDaneiSume(tablica);
        }

        #region
        private static void WypelnienieTablicy(int[][] tablica)
        {
            bool zapelnionaTablica = false;
            WyswietlDaneiSume(tablica);
            while (!zapelnionaTablica)
            {
                Console.WriteLine("Czy chcesz zapelnic losowymi danymi? y/n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "y":
                        LosoweTablice(tablica);
                        zapelnionaTablica = true;
                        break;

                    case "n":
                        ReczneTablice(tablica);
                        zapelnionaTablica = true;
                        break;

                    default:
                        WyswietlDaneiSume(tablica);
                        Console.WriteLine("Nieprawidlowa wartosc, sprobuj ponownie");
                        break;
                }
            }
        }

        private static void WyswietlDaneiSume(int[][] tablica)
        {
            if (tablica != null)
            {
                int[] sumaTablicy = new int[tablica.Length];
                int sumaTablic = 0;

                Console.Clear();
                if (tablica.Length > 0)
                {
                    Console.WriteLine($"Liczba kolumn tablic: {tablica.Length}");
                    if (tablica != null)
                    {
                        for (int i = 0; i < tablica.Length; i++)
                        {
                            sumaTablicy[i] = 0;
                            if (tablica[i] != null)
                            {
                                Console.WriteLine($"\nTablica[{i}]");
                                for (int j = 0; j < tablica[i].Length; j++)
                                {
                                    Console.Write(tablica[i][j] + " | ");
                                    sumaTablicy[i] += tablica[i][j];
                                }
                                Console.WriteLine($"\nSuma tablicy wynosi {sumaTablicy[i]}");
                                sumaTablic += sumaTablicy[i];
                            }
                        }
                        Console.WriteLine($"\nSuma wszystkich tablic wynosi {sumaTablic}");
                    }
                }
            }
        }
        private static void ReczneTablice(int[][] tablica)
        {
            bool czyPrawidlowa;
            bool prawidlowyRozmiar = false;
            bool prawidlowaWartosc;
            WyswietlDaneiSume(tablica);
            for (int i = 0; i < tablica.Length; i++)
            {
            line:
                Console.WriteLine($"Podaj rozmiar {i + 1} tablicy: ");
                string input = Console.ReadLine();
                czyPrawidlowa = Int32.TryParse(input, out int rozmiar);
                if (czyPrawidlowa && rozmiar > 0)
                {
                    tablica[i] = new int[rozmiar];
                }
                else
                {
                    Console.WriteLine("Nieprawidlowa wartosc");
                    goto line;
                }
                do
                {
                    Console.WriteLine($"Podaj elementy {i + 1} tablicy rozdzielone przecinkiem ({rozmiar})");
                    input = Console.ReadLine();
                    string[] dane = input.Split(',');
                    if (!(rozmiar == dane.Length))
                    {
                        prawidlowyRozmiar = false;
                        Console.WriteLine("Nieprawidlowa liczba elementow, sprobuj ponownie: ");
                    }
                    else if (dane.Length == rozmiar)
                    {
                        for (int j = 0; j < rozmiar; j++)
                        {
                            czyPrawidlowa = Int32.TryParse(dane[j], out tablica[i][j]);
                            if (!czyPrawidlowa)
                            {
                                Console.WriteLine($"Nieprawidlowy element na {j + 1} pozycji");
                                do
                                {
                                    Console.WriteLine($"Podaj ponownie prawidlowa wartosc z {j + 1} pozycji");
                                    input = Console.ReadLine();
                                    prawidlowaWartosc = Int32.TryParse(input, out tablica[i][j]);
                                } while (!prawidlowaWartosc);
                            }
                        }
                        prawidlowyRozmiar = true;
                    }
                } while (!prawidlowyRozmiar);
            }
        }

        private static void LosoweTablice(int[][] tablica)
        {
            Random generator = new Random();
            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = new int[generator.Next(1, 21)];

                for (int j = 0; j < tablica[i].Length; j++)
                {
                    tablica[i][j] = generator.Next(100);

                }
            }
        }

        private static int[][] UtworzNowaTablice()
        {
            bool prawidlowaWartosc;
            do
            {
                Console.WriteLine("Podaj liczbe przechowywanych tablic: ");
                string input = Console.ReadLine();
                prawidlowaWartosc = Int32.TryParse(input, out int liczbaTablic);

                if (prawidlowaWartosc && liczbaTablic > 0)
                {
                    return new int[liczbaTablic][];
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Podano nieprawidlowa wartosc, sprobuj ponownie");
                    prawidlowaWartosc = false;
                }
            } while (!prawidlowaWartosc);
            return null;
        }
    }
    #endregion
}