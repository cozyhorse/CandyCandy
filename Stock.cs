using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCandy
{
    //Hanterar all data i maskinen
    // Inventarie och "Kvitto"
    internal class Stock
    {
 
        
        //Godis
        public static List<(string, decimal)> Candys = new List<(string, decimal)>()
        {
           ("KitKat", 10.20m),
           ("Snickers", 9.60m),
           ("Mars", 9.55m),
           ("Bounty", 8.80m),
           ("Twix", 9.30m),
           ("Skittles", 12.75m),
           ("Hi-Chew", 21),
           ("Gummi Bears", 14.10m),
           ("Hershey's" ,12.60m)

        };


        //Läsk
        public static List<(string, decimal)> Sodas = new List<(string, decimal)>()
        {
            ("Coca-Cola", 12),
            ("Coca-Cola Zero", 11.50m),
            ("Coca-Cola Vanilla", 15.30m),
            ("Pepsi", 12.55m),
            ("Pepsi Max", 11.30m),
            ("Pepsi White", 17),
            ("Fanta Grape", 19),
            ("Fanta Peach", 18)
        };

        //Snacks
        public static List<(string, decimal)> Snacks = new List<(string, decimal)>()
        {
            ("GrillChips", 9.80m),
            ("Lay's Barbecue", 11),
            ("Lay's Fried Chicken", 13.50m),
            ("Sour Cream and Onion Chips", 9.60m),
            ("Lay's Spicy Lobster ", 29)

        };

        //Mat
        public static List<(string, decimal)> Foods = new List<(string, decimal)>()
        {
            ("Cheese Pizza", 54),
            ("Tonkotsu Ramen", 45),
            ("Fried Chicken", 33),
            ("Garlic Fried Rice", 24),
            ("Veggies Delight Pizza", 29)

        };

        /// <summary>
        /// funktion som returnerar all innehåll i alla listor med varor.
        /// </summary>
        /// <returns></returns>
        public static List<(string, decimal)> AllInvent()
        {

            var items = new List<(string, decimal)>();

            items.AddRange(Stock.Candys);
            items.AddRange(Stock.Snacks);
            items.AddRange(Stock.Sodas);
            items.AddRange(Stock.Foods);

            return items;
        }



        //"Kundkorgen"
        public static List<(string, decimal)> Total = new List<(string, decimal)>();



    }


}





