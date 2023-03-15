using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCandy.FoodItems
{
    internal class Snack
    {
        /// <summary>
        /// Hanterar snacks i maskinen
        /// </summary>
        public static void Snacks()
        {

            while (true)

            {

                Console.WriteLine("Köp Snacks!");
                try
                {

                    Console.WriteLine();
                    Tools.InfoTracker();
                    Console.WriteLine();
                    Console.WriteLine();

                    Tools.IndexListItems(Stock.Snacks);
                    Console.WriteLine("Ange 0 för att gå tillbaka.");
                    Tools.InputRequest("Vilken snack vill du köpa?", false);

                    var z = Tools.ReadMenuChoice();

                    if (z > Stock.Snacks.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException(
                            string.Format("Fel inmatning, vänligen ange en siffra mellan 1 and {0}.", Stock.Snacks.Count));
                    }

                    if (z == 0)
                    {
                        Console.Clear();
                        break;
                    }


                    Console.Clear();
                    Stock.Total.Add(Stock.Snacks[z - 1]);
                }
                catch (Exception ex)
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine("Ange en siffra som motsvarar den snack du vill köpa.");
                    Console.ReadKey();
                    Console.ResetColor();
                    Console.Clear();


                }



            }

        }

    }
}
