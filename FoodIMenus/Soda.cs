using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCandy.FoodItems
{
    internal class Soda
    {
        /// <summary>
        /// Hanterar drickan i maskinen
        /// </summary>
        public static void Sodas()
        {


            while (true)
            {

                Console.WriteLine("Köp Läsk");
                try
                {
                    Console.WriteLine();
                    Tools.InfoTracker();
                    Console.WriteLine();
                    Console.WriteLine();

                    Tools.IndexListItems(Stock.Sodas);
                    Console.WriteLine("Ange 0 för att gå tillbaka.");
                    Tools.InputRequest("Vilken läsk vill du köpa?", false);

                    var z = Tools.ReadMenuChoice();

                    if (z > Stock.Sodas.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException(
                            string.Format("Fel inmatning, vänligen ange en siffra mellan 1 and {0}.", Stock.Sodas.Count));
                    }

                    if (z == 0)
                    {
                        Console.Clear();
                        break;
                    }


                    Console.Clear();
                    Stock.Total.Add(Stock.Sodas[z - 1]);
                }
                catch (Exception ex)
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine("Ange en siffra som motsvarar den dricka du vill köpa.");
                    Console.ReadKey();
                    Console.ResetColor();
                    Console.Clear();



                }

            }

        }

    }
}
