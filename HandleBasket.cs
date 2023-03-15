using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CandyCandy
{
    internal class HandleBasket
    {
        /// <summary>
        /// Hanterings av varukorgen.
        /// </summary>
        public static void basket()
        {
            while (true)
            {
                Tools.WriteMenu(new[]
                {
                    "Betala",
                    "Radera Vara",
                    "Tillbaka"
                });

                switch (Tools.ReadMenuChoice())
                {
                    case 1:
                        CheckOut();
                        break;

                    case 2:
                        EditBasket();
                        break;

                    case 3:
                        return;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Dåligt menyval, prova igen");
                        Console.ResetColor();
                        break;
                }

            }
        }

        /// <summary>
        /// Hanterar betalmenyn
        /// </summary>
        public static void CheckOut()
        {
            while (true)
            {


                if (Stock.Total.Count > 1)
                {


                    Console.Clear();
                    Tools.IndexListItems(Stock.Total);
                    Console.WriteLine();
                    Tools.InfoTracker();
                    Console.WriteLine("Betala och avsluta? Y/N");

                    string? fin = Console.ReadLine();

                    //Kollar om inmatningen stämmer med villkoret.
                    if (fin == "y" || fin == "Y")
                    {

                        Console.Clear();
                        Console.WriteLine("Tack för din beställning och välkommen åter!");
                        Stock.Total.Clear();
                        Console.ReadKey();
                        Console.Clear();
                        Program.MainMenu();

                    }
                    else
                    {
                        Console.Clear();
                        Program.MainMenu();

                    }



                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Här var det tomt!");
                    Console.WriteLine("Vänligen lägg till en vara");
                    Console.ReadKey();
                    Console.Clear();
                    Program.MainMenu();
                }





            }


        }

        /// <summary>
        /// Hanterar radering av vara
        /// </summary>
        public static void EditBasket()
        {
            while (true)
            {

                try
                {

                    if (Stock.Total.Count > 1)
                    {


                        Console.Clear();
                        Tools.IndexListItems(Stock.Total);
                        Console.WriteLine("Ange 0 för att gå tillbaka.");

                        Console.WriteLine();
                        Tools.InfoTracker();

                        Tools.InputRequest("Vilken vara vill du ta bort?", false);

                        var y = Tools.ReadMenuChoice();

                        //Fångar när någon försöker mata in en siffra som är större än listans storlek.
                        if (y > Stock.Total.Count)
                        {


                            throw new ArgumentException(
                                string.Format("Fel inmatning, vänligen ange en siffra mellan 1 and {0}.", Stock.Total.Count));

                        }


                        if (y == 0)
                        {
                            Console.Clear();
                            break;
                        }

                        Stock.Total.RemoveAt(y - 1);

                    }

                    //Kollar om det är varor i korgen.
                    if (Stock.Total.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Du måste minst ha en vara i korgen.");
                        Console.ReadKey();
                        Console.Clear();
                        Program.MainMenu();
                    }



                }
                //Fångar upp när inmatningen inte är en siffra.
                catch (FormatException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel inmatning");
                    Console.ResetColor();
                    Console.ReadKey();

                }

                catch (ArgumentException ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                    Console.ReadKey();
                }





            }


        }



    }



}
