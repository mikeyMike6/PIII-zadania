using System;
using System.Runtime.InteropServices.ComTypes;

namespace PIII2
{
    /*
     Napisz aplikację do obliczania miejsc zerowych (m.z.) funkcji kwadratowej.
Wczytaj od użytkownika liczby a b i c - zgodnie ze wzorem ax^2+bx+c.
Wyznacz i wypisz deltę.
Przygotuj enum dla możliwych wyników (2 m.z., 1 m.z., brak m.z.) i przypisz wartość zgodnie z wyliczoną deltą.
Za pomocą switcha wypisz w odpowiedni sposób wyniki (lub komunikat o braku wyników).
Zabezpiecz program przed podaniem przez użytkownika błędnych danych
    */
    class Program
    {
        enum MiejscaZerowe
        {
            DwaMiejscaZerowe,
            JednoMiejsceZerowe,
            BrakMiejscZerowych
        }
        static void Main(string[] args)
        {
            while (true)
            {
                var delta = WyznaczDelte(out double a, out double b, out double c);
                MiejscaZerowe miejscaZerowe;
                miejscaZerowe = IleMiejscZerowych(delta);
                WybierzWynik(a, b, c, delta, miejscaZerowe);
                Console.WriteLine("--------------------------------");
            }
        }

        private static void WybierzWynik(double a, double b, double c, double delta, MiejscaZerowe miejscaZerowe)
        {
            double x1, x2;
            switch (miejscaZerowe)
            {
                case MiejscaZerowe.DwaMiejscaZerowe:
                    ObliczDwaMiejscaZerowe(a, b, delta, out x1, out x2);
                    WyswietlWynik(a, b, c, x1, x2);
                    break;
                case MiejscaZerowe.JednoMiejsceZerowe:
                    ObliczJednoMiejsceZerowe(a, b, out x1);
                    WyswietlWynik(a, b, c, x1);
                    break;
                case MiejscaZerowe.BrakMiejscZerowych:
                    WyswietlWynik(a, b, c);
                    break;
                default:
                    break;
            }
        }

        private static MiejscaZerowe IleMiejscZerowych(double delta)
        {
            MiejscaZerowe miejscaZerowe;
            if (delta > 0)
            {
                miejscaZerowe = MiejscaZerowe.DwaMiejscaZerowe;
            }
            else if (delta == 0)
            {
                miejscaZerowe = MiejscaZerowe.JednoMiejsceZerowe;
            }
            else
            {
                miejscaZerowe = MiejscaZerowe.BrakMiejscZerowych;
            }

            return miejscaZerowe;
        }

        private static void WyswietlWynik(double a, double b, double c)
        {
            Console.WriteLine($"Funkcja kwadratowa f(x) = {a}x^2 + {b}x + {c}");
            Console.WriteLine("Nie ma miejsc zerowych");
        }

        private static void WyswietlWynik(double a, double b, double c, double x1)
        {
            Console.WriteLine($"Funkcja kwadratowa f(x) = {a}x^2 + {b}x + {c}");
            Console.WriteLine($"Ma miejsce zerowe w miejsu: x = {x1}");
        }

        private static void WyswietlWynik
            (double a, double b, double c, double x1, double x2)
        {
            Console.WriteLine($"Funkcja kwadratowa f(x) = {a}x^2 + {b}x + {c}");
            Console.WriteLine($"Ma miejsca zerowe w miejsach: x1 = {x1}, x2 = {x2}");
        }

        private static void ObliczJednoMiejsceZerowe
            (double a, double b, out double x1)
        {
            x1 = -b / (2 * a);
        }

        private static void ObliczDwaMiejscaZerowe
            (double a, double b, double delta, out double x1, out double x2)
        {
            x1 = (-b - Math.Sqrt(delta)) / (2 * a);
            x2 = (-b + Math.Sqrt(delta)) / (2 * a);
        }

        static double WyznaczDelte(out double a, out double b, out double c)
        {
            char[] abc = { 'a', 'b', 'c' };
            double[] zmienne = new double[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Podaj " + abc[i]);
                string odpowiedz = Console.ReadLine();
                Console.WriteLine($"Wpisales na miejsce {abc[i]} liczbe {odpowiedz}");
                try
                {
                    zmienne[i] = Convert.ToDouble(odpowiedz);
                }
                catch (Exception)
                {
                    Console.WriteLine("Nieprawidlowa liczba, sprobuj ponownie");
                    i--;
                }
            }
            a = zmienne[0];
            b = zmienne[1];
            c = zmienne[2];

            var delta = (b * b) - (4 * a * c);
            Console.WriteLine("Delta wynosi " + delta);
            return delta;
        }
    }
}