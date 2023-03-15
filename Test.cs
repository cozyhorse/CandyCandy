using CandyCandy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCandy
{
    internal class Test
    {
        public static void GetPerChoice()
        {
            var random = new Random();
            var items = new List<(string, decimal)>();
            var choices = new List<string>();

            while (true)

            {

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
                        items.AddRange(Stock.Snacks);
                        choices.Add("Snacks");
                        break;
                    case 3:
                        items.AddRange(Stock.Sodas);
                        choices.Add("Dricka");
                        break;
                    case 4:
                        items.AddRange(Stock.Foods);
                        choices.Add("Mat");
                        break;

                    case 5:

                        GetAmount();
                        break;

                    case 9:
                        return;

                    default:
                        Tools.BadMenuChoice();
                        break;



                }


                //Console.WriteLine("Varor som kommer slumpas");
                //Tools.WriteMenu(choices);
                //Console.WriteLine("Antal val gjorda {0}", choices.Count);
                //Console.WriteLine();

            }
            void GetAmount()
            {
                var randomItems = new List<(string, decimal)>();

                Console.WriteLine("Hur många varor vill du ha?");
                Console.Write("> ");
                int z = int.Parse(Console.ReadLine());
                for (var i = 0; i < z; i++)
                    randomItems.Add(items[random.Next(0, items.Count - 1)]);

                Stock.Total.AddRange(randomItems);
                Console.Clear();
                choices.Clear();
            }




        }

        public static void GetBudget()
        {
            Tools.InfoTracker();

            Tools.InputRequest("Budget?", false);
            var budget = Tools.ReadMenuChoice();
            var random = new Random();
            var total = 0m;
            var itemsR = new List<(string, decimal)>();
            
            while (total < budget)
            {
                var randomItem = Stock.AllInvent()[random.Next(0, Stock.AllInvent().Count - 1)];

                total += randomItem.Item2;

                itemsR.Add(randomItem);
            }
        
            Stock.Total.AddRange(itemsR);




        }




    }
}

