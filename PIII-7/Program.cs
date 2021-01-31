using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Collections.Generic;

namespace zad7
{
    interface IPrintable
    {
        void Print();
    }
    class Something : ICloneable, IComparable<Something>, IPrintable
    {
        public static int Count;
        public int ID { get; set; }
        public string Text { get; set; }
        public int[] Numbers { get; set; }
        private static int inCount;
        public Something()
        {
            Count++;
            ID = Count;
            Text = RandomString();
            Numbers = new int[ID];
            for (int i = 0; i < ID; i++)
            {
                Numbers[i] = new Random().Next(10);
            }
        }
        private Something(int id)
        {
            ID = id;
            Text = RandomString();
            Numbers = new int[ID];
            for (int i = 0; i < ID; i++)
            {
                Numbers[i] = new Random().Next(10);
            }
        }
        private string RandomString()
        {
            var bbase = "qwertyuiopasdfghjklzxcvbnm";
            string tmp = "";
            for (int i = 0; i < ID; i++)
            {
                tmp += bbase[new Random().Next(bbase.Length)];
            }
            return tmp;
        }

        public int CompareTo([AllowNull] Something other)
        {
            return Text.CompareTo(other.Text);
        }

        public object Clone()
        {
            inCount++;
            var tmp = new Something(inCount)
            {
                Text = this.Text,
                Numbers = new int[ID]
            };
            for (int i = 0; i < tmp.ID; i++)
            {
                tmp.Numbers[i] = this.Numbers[i];
            }
            return tmp;
        }

        public void Print()
        {
            Console.Write(
                $"\nID      : {ID}" +
                $"\nText    : {Text}" +
                $"\nNumbers : "
                );
            Numbers.ToList().ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
        }
        public void ClearNumbers()
        {
            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = 0;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Something[] somethings = new Something[100];
            for (int i = 0; i < somethings.Length; i++)
            {
                somethings[i] = new Something();
            }
            var clones = new List<Something>();
            for (int i = 0; i < somethings.Length; i++)
            {
                clones.Add((Something)somethings[i].Clone());
            }
            Console.WriteLine();

            somethings.ToList().ForEach(x => x.ClearNumbers());

            somethings.ToList().ForEach(x => x.Print());
            clones.Sort();
            clones.ForEach(x => x.Print());

        }
    }
}