using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCandy
{
    internal class Tools
    {

        /// <summary>
        /// Funktion som skriver ut ordersumman av beställningen.
        /// </summary>
        public static decimal TotalPrice()
        {

            decimal CurrentPrice = 0;

            foreach ((string name, decimal price) in Stock.Total)
                 CurrentPrice += price;

            
            return CurrentPrice;
        }


        /// <summary>
        /// Method som skriver ut listan på varan och priset
        /// </summary>
        /// <param name="lista"></param>
        public static void IndexListItems(List<(string, decimal)> lista)
        {
            var items = lista.Select((namn, index) => $"{index + 1}. {namn.Item1.Trim('(', ')')} - {namn.Item2}");
            var strs = string.Join(Environment.NewLine, items);

            Console.WriteLine(strs);
            Console.WriteLine();

        }

        /// <summary>
        /// Metod för att skriva ut en fråga och om consolen skall clearas eller inte.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="clear"></param>
        public static void InputRequest(string title, bool clear = false)
        {
            if (clear) Console.Clear();

            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine();
            Console.Write("> ");
        }

        /// <summary>
        /// Method för att skriva ut en lista<string> med index som börjar på 1
        /// </summary>
        /// <param name="list"></param>
        public static void WriteMenu(IEnumerable<string> list)
        {
            var items = list.Select((n, i) => $"{i + 1}. {n}");
            var str = string.Join(Environment.NewLine, items);

            Console.WriteLine(str);
            Console.WriteLine();
            
        }

        /// <summary>
        /// Funktion för att läsa av ifall inmatningen analyserats som int eller inte.
        /// </summary>
        /// <returns></returns>
        public static int ReadMenuChoice()
        {
            var input = Console.ReadLine();

            if (!int.TryParse(input, out var i)) return -1;
            Console.Clear();
            return i;
        }

        /// <summary>
        /// Metod som skriver ut antal varor i korg och ordersumman.
        /// </summary>
        public static void InfoTracker()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Antal Varor i korgen {0}", Stock.Total.Count);
            Console.WriteLine("Slutsumma SEK {0}", TotalPrice());
            Console.ResetColor();
        }

        /// <summary>
        /// hanterar ett ogiltigt menyval
        /// </summary>
        public static void BadMenuChoice()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Dåligt menyval, försök igen.");
            Console.ResetColor();
        }



    }



}
