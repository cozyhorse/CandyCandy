using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCandy.FoodItems
{
    internal class Candy
    {
        /// <summary>
        /// Hanterar Godiset i maskinen
        /// </summary>
        public static void BuyCandy()
        {


            while (true)
            {


                Console.WriteLine("Köp godis!");
                try
                {

                    Console.WriteLine();
                    Tools.InfoTracker();
                    Console.WriteLine();
                    Console.WriteLine();

                    Tools.IndexListItems(Stock.Candys);
                    Console.WriteLine("Ange 0 för att gå tillbaka.");
                    Tools.InputRequest("Vilken godis vill du köpa?", false);



                    var z = Tools.ReadMenuChoice();

                    if (z > Stock.Candys.Count)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException(


                            string.Format("Fel inmatning, vänligen ange en siffra mellan 1 and {0}.", Stock.Candys.Count));

                    }


                    if (z == 0)
                    {
                        Console.Clear();
                        break;
                    }


                    Console.Clear();
                    Stock.Total.Add(Stock.Candys[z - 1]);



                }
                catch (Exception ex)
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine("Ange en siffra som motsvarar den godis du vill köpa.");
                    Console.ReadKey();
                    Console.ResetColor();
                    Console.Clear();

                }






            }

        }

    }

}
