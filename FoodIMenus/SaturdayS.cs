using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCandy.FoodIMenus
{
    /// <summary>
    /// Överraskningsmenyn
    /// </summary>
    internal class SaturdayS
    {
        private static readonly Random Random = new Random();

        /// <summary>
        /// Metod för Överraskningsmenyn
        /// </summary>
        public static void SurpriseMenu()
        {
            while (true)
            {
                Tools.InfoTracker();
                Console.WriteLine();

                Tools.WriteMenu(new[]
                {
                    "Överraskning!",
                    "Slumpa från vald kategori",
                    "Ange en budget",
                    "Tillbaka"

                });

                switch (Tools.ReadMenuChoice())
                {
                    case 1:
                        Tools.InputRequest("Hur många varor vill du ha?", true);
                        //GetRandom 
                        GetRandom(Tools.ReadMenuChoice());
                        break;

                    case 2:
                        GetPerChoice();
                        break;
                    case 3:
                        GetBudget();
                        break;

                    case 4:
                        return;
                    default:
                        Tools.BadMenuChoice();
                        break;
                }


            }





        }


        /// <summary>
        /// Metod för att hämta saker slumpmässigt från inventariet baserat på input.
        /// </summary>

        public static void GetRandom(int amount)
        {
            
            Stock.AllInvent();

            var randomItems = new List<(string, decimal)>();

            //Kör for loopen efter angiven siffra("amount") 
            for (var i = 0; i < amount; i++)
                randomItems.Add(Stock.AllInvent()[Random.Next(0, Stock.AllInvent().Count - 1)]);

            Stock.Total.AddRange(randomItems);
            Console.Clear();


        }


        /// <summary>
        /// Metod för att välja vilka varor som skall slumpas. 
        /// </summary>
        public static void GetPerChoice()
        {
            
            var items = new List<(string, decimal)>();
            var choices = new List<string>();

            while (true)


            {
                Console.WriteLine("Varor som kommer slumpas");
                Tools.WriteMenu(choices);
                Console.WriteLine("Antal val gjorda {0}", choices.Count);
                Console.WriteLine();

                Tools.InfoTracker();
                Console.WriteLine();

                Console.WriteLine("Möjliga val");
                Tools.WriteMenu(new[] {
                    "Godis",
                    "Dricka",
                    "Snack",
                    "Mat"
                });
                Console.WriteLine("Ange 5 för att slumpa fram.");
                Console.WriteLine("Ange 9 för att gå tillbaka.");



                Tools.InputRequest("Vad vill du lägga till i slumpen?", false);


                switch (Tools.ReadMenuChoice())
                {

                    case 1:
                        items.AddRange(Stock.Candys);
                        choices.Add("Godis");
                        break;
                    case 2:
                        items.AddRange(Stock.Sodas);
                        choices.Add("Dricka");
                        break;
                    case 3:
                        items.AddRange(Stock.Snacks);
                        choices.Add("Snacks");
                        break;
                    case 4:
                        items.AddRange(Stock.Foods);
                        choices.Add("Mat");
                        break;

                    case 5:
                        Tools.InputRequest("Hur många varor vill du ha?", true);
                        GetAmount(Tools.ReadMenuChoice());
                        break;

                    case 9:
                        choices.Clear();
                        return;

                    default:
                        Tools.BadMenuChoice();
                        break;



                }



            }

            void GetAmount(int z)
            {
                var randomItems = new List<(string, decimal)>();

                for (var i = 0; i < z; i++)
                    randomItems.Add(items[Random.Next(0, items.Count - 1)]);

                Stock.Total.AddRange(randomItems);
                Console.Clear();
                choices.Clear();
            }


        }



        /// <summary>
        /// Metod för att hämta varor slumpmässigt baserat på budget.
        /// </summary>
        public static void GetBudget()
        {
            Tools.InfoTracker();

            Tools.InputRequest("Budget?", false);
            var budget = Tools.ReadMenuChoice();
            
            var total = 0m;
            var itemsR = new List<(string, decimal)>();

            while (total < budget)
            {
                //Väljer saker slumpmässigt från hela inventariet (Stock.AllInvent())
                var randomItem = Stock.AllInvent()[Random.Next(0, Stock.AllInvent().Count - 1)];

                total += randomItem.Item2;

                itemsR.Add(randomItem);
            }

            Stock.Total.AddRange(itemsR);




        }


    }
}
