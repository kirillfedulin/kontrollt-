using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace kontrolltöö
{
    internal class StartPage
    {
        static void Main()
        {
            while (true)
            {
                    Console.WriteLine("Plaun sissestage mida te tahate: ");
                    Console.WriteLine("1. Logi pidamine");
                    Console.WriteLine("2. Sõnastik ja Otsing");
                    Console.WriteLine("3. Failist lugemine ja analüüs");
                    Console.WriteLine("4. Oma Klassi loomine");
                    Console.WriteLine("5.  Autopargi haldus");
                    Console.WriteLine("0.  EXIT");

                    string valik = Console.ReadLine();
                    if (valik == "1")
                    {
                        AndmeFunktsioonid.AndmeFunktsjonijiet();
                    }
                    else if (valik == "2")
                    {
                        AndmeFunktsioonid.RiigiOtsing();
                    }
                    else if (valik == "3")
                    {
                        AndmeFunktsioonid.LoeJaArvuta();
                    }
                    else if (valik == "4")
                    {
                        Console.WriteLine("Mis mudel teil on?");


                    }
                    else if (valik == "5")
                    {
                        AndmeFunktsioonid.AndmeFunktsioonidd();
                    }
                    else if (valik == "0")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Palun sisestage õiged numbrid!");
                    }
                }

            }
            
        }
    }
}
