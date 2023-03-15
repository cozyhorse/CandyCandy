using System.ComponentModel;
using System.Linq.Expressions;
using CandyCandy.FoodIMenus;
using CandyCandy.FoodItems;

namespace CandyCandy
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MainMenu();

        }

        /// <summary>
        /// Hanterar Huvudmenyn
        /// </summary>
        public static void MainMenu()
        {

            while (true)
            {
                
                Console.WriteLine("Välkommen till LördagsMaskinen");
                Console.WriteLine();

                Tools.InfoTracker();

                Console.WriteLine();
                Tools.WriteMenu(new[]
                {   "Köpa Godis",
                    "Köpa Dricka",
                    "Köpa Snacks",
                    "Köpa Mat",
                    "Lördagsöverraskning",
                    "Hantera beställnig/Betala",
                    "Avsluta",
                });
                Console.Write("> ");



                switch (Tools.ReadMenuChoice())
                {
                    case 1:
                        Candy.BuyCandy();
                        continue;

                    case 2:
                        Soda.Sodas();
                        continue;

                    case 3:
                        Snack.Snacks();
                        continue;

                    case 4:
                        Food.Foods();
                        continue;

                    case 5:
                        SaturdayS.SurpriseMenu();
                        continue;

                    case 6:
                        HandleBasket.basket();
                        continue;

                    case 7:
                        Console.WriteLine("Tack för idag!");
                        Console.WriteLine("Tryck på valfri knapp för att avsluta..");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                        break;
                    case 8:
                        break;



                    default:
                        Tools.BadMenuChoice();
                        break;

                }
            }
        }






    }
}