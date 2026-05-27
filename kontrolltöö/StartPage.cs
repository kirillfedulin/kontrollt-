using kontrolltöö;

namespace kontrolltöö;

class StartPage
{
    static void Main(string[] args)
    {
        AndmeFunktsioonid.KirjutaLogi("Programm käivitati");

        File.WriteAllText("arvud.txt", "10, 20, 5, 100, 4");

        bool jatka = true;

        while (jatka)
        {
            Console.WriteLine("1. Kirjuta logi");
            Console.WriteLine("2. Riigi otsing");
            Console.WriteLine("3. Loe arvud failist ja arvuta");
            Console.WriteLine("4. Halda autosid");
            Console.WriteLine("0. Välju");
            Console.Write("\nSinu valik: ");

            string valik = Console.ReadLine() ?? "";

            switch (valik)
            {
                case "1":
                    Console.Write("Sisesta logiteade: ");
                    string teade = Console.ReadLine() ?? "Kasutaja sisestas tühja teate";
                    AndmeFunktsioonid.KirjutaLogi(teade);
                    Console.WriteLine("Logi kirjutatud faili 'logi.txt'.");
                    break;

                case "2":
                    AndmeFunktsioonid.RiigiOtsing();
                    break;

                case "3":
                    Tuple<int, double> tulemus = AndmeFunktsioonid.LoeJaArvuta();
                    if (tulemus.Item1 != 0 || tulemus.Item2 != 0)
                    {
                        Console.WriteLine($"Summa: {tulemus.Item1}");
                        Console.WriteLine($"Keskmine: {tulemus.Item2:F2}");
                    }
                    break;

                case "4":
                    AndmeFunktsioonid.HaldaAutosid();
                    break;

                case "0":
                    AndmeFunktsioonid.KirjutaLogi("Programm lõpetati");
                    jatka = false;
                    Console.WriteLine("Head aega!");
                    break;

                default:
                    Console.WriteLine("Vigane valik. Proovi uuesti.");
                    break;
            }
        }
    }
}
