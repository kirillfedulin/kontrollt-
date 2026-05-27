namespace kontrolltöö;

public static class AndmeFunktsioonid
{
    public static void KirjutaLogi(string teade)
    {
        using StreamWriter writer = new StreamWriter("logi.txt", append: true);
        writer.WriteLine($"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] - {teade}");
    }

    public static void RiigiOtsing()
    {
        Dictionary<string, string> riigid = new Dictionary<string, string>
        {
            { "EE", "Eesti" },
            { "FI", "Soome" },
            { "DE", "Saksamaa" },
            { "FR", "Prantsusmaa" },
            { "LV", "Läti" }
        };
            
        Console.Write("Sisesta riigi kood: ");
        string kood = Console.ReadLine()?.ToUpper() ?? "";

        if (riigid.ContainsKey(kood))
        {
            Console.WriteLine($"Riik: {riigid[kood]}");
        }
        else
        {
            Console.Write($"Koodi '{kood}' ei leitud. Mis riik see on? ");
            string uusRiik = Console.ReadLine() ?? "";
            riigid[kood] = uusRiik;
            Console.WriteLine($"Lisatud: {kood} -> {uusRiik}");
        }

        Console.WriteLine("\nKõik riigid sõnastikus:");
        foreach (KeyValuePair<string, string> paar in riigid)
        {
            Console.WriteLine($"  {paar.Key}: {paar.Value}");
        }
    }

    public static Tuple<int, double> LoeJaArvuta()
    {
        try
        {
            string sisu = File.ReadAllText("arvud.txt");
            string[] osad = sisu.Split(',');

            int summa = 0;
            int count = 0;

            foreach (string osa in osad)
            {
                string trimmed = osa.Trim();
                if (!string.IsNullOrEmpty(trimmed))
                {
                    summa += int.Parse(trimmed);
                    count++;
                }
            }

            double keskmine = count > 0 ? (double)summa / count : 0;
            return new Tuple<int, double>(summa, keskmine);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Viga: Faili 'arvud.txt' ei leitud.");
            return new Tuple<int, double>(0, 0);
        }
        catch (FormatException)
        {
            Console.WriteLine("Viga: Failis on vigane number.");
            return new Tuple<int, double>(0, 0);
        }
    }

    public static void HaldaAutosid()
    {
        List<Auto> autod = new List<Auto>
        {
            new Auto("Toyota", 5.5, 40),
            new Auto("BMW", 8.0, 15),
            new Auto("Ford", 6.2, 55),
            new Auto("Audi", 7.1, 8),
            new Auto("Honda", 4.8, 30)
        };

        Auto suurimSoiduulatusega = autod[0];
        foreach (Auto auto in autod)
        {
            if (auto.ArvutaSoiduulatus() > suurimSoiduulatusega.ArvutaSoiduulatus())
            {
                suurimSoiduulatusega = auto;
            }
        }

        Console.WriteLine($"\nSuurima sõiduulatusega auto: {suurimSoiduulatusega.Mudel}");
        Console.WriteLine($"  Sõiduulatus: {suurimSoiduulatusega.ArvutaSoiduulatus():F1} km");

        Console.WriteLine("\nAutod, mis vajavad kohe tankimist (alla 10L):");
        List<Auto> tankimistVajavad = new List<Auto>();
        foreach (Auto auto in autod)
        {
            if (auto.PaagisOnKutust < 10)
            {
                tankimistVajavad.Add(auto);
                Console.WriteLine($"  {auto.Mudel} ({auto.PaagisOnKutust}L)");
            }
        }

        if (tankimistVajavad.Count == 0)
        {
            Console.WriteLine("  Kõigil autodele piisab kütust.");
        }

        SalvestaAutostatistika(autod);
    }

    private static void SalvestaAutostatistika(List<Auto> autod)
    {
        using StreamWriter writer = new StreamWriter("autopark.txt", append: false);
        writer.WriteLine($"=== Autopargi statistika ({DateTime.Now:dd.MM.yyyy HH:mm:ss}) ===");
        writer.WriteLine();

        double kogusoiduulatus = 0;
        foreach (Auto auto in autod)
        {
            double soiduulatus = auto.ArvutaSoiduulatus();
            kogusoiduulatus += soiduulatus;
            writer.WriteLine($"Mudel: {auto.Mudel,-10} | Kütus: {auto.PaagisOnKutust,5:F1}L | Kulu: {auto.KutuseKulu,4:F1}L/100km | Ulatus: {soiduulatus,7:F1}km");
        }

        writer.WriteLine();
        writer.WriteLine($"Keskmine sõiduulatus: {kogusoiduulatus / autod.Count:F1} km");
        writer.WriteLine($"Autode arv kokku: {autod.Count}");

        Console.WriteLine("\nAutopargi statistika salvestatud faili 'autopark.txt'.");
    }
}
