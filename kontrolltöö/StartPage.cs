using System.Text;

namespace kontrolltöö
{
    internal class StartPage
    {
        static void Main(string[] args)
        {
            while (true)
            {
               
                Console.WriteLine("1. KirjutaLogi");
                Console.WriteLine("2. RiigiOtsing");
                Console.WriteLine("3. LoeJaArvuta");
                Console.WriteLine("4. HaldaAutosid");
                
                string valik = Console.ReadLine();
                switch (valik)
                {
                    case "1":
                        Console.WriteLine("sisesta oma nimi: ");
                        string kasutaja = Console.ReadLine();
                        AndmeFunktsioonid.KirjutaLogi($"{kasutaja} logis sisse");
                        break;

                    case "2":
                       
                        Dictionary<string, string> riigid = new Dictionary<string, string>()
                            {
                                { "EE", "Eesti" },
                                { "FI", "Soome" },
                                { "DE", "Saksamaa" },
                                { "UA", "Ukraine" }
                            };
                        AndmeFunktsioonid.RiigiOtsing(riigid);
                        break;

                    case "3":
                        string path = @"..\..\..\arvud.txt";

                        string[] data = new string[]
                            {
                            "1, 3, 7, 10, 15, 20",
                            };
                        File.WriteAllLines(path, data, Encoding.UTF8);
                        AndmeFunktsioonid.LoeJaArvuta();
                        break;

                    case "4":
                        Auto.HaldaAutosid();
                        break;
                           
                }
            }
        }
    }
}
