using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace kontrolltöö
{
    public class Auto
    {
        public string Mudel { get; set; }
        public double KutuseKulu { get; set; }
        public double PaagisOnKutust { get; set; }

        public Auto(string mudel, double kutuseKulu, double paagisOnKutust)
        {
            Mudel = mudel;
            KutuseKulu = kutuseKulu;
            PaagisOnKutust = paagisOnKutust;
        }
        public double ArvutaSoiduulatus()
        {
            double kogus = (PaagisOnKutust / KutuseKulu) * 100;
            Console.WriteLine("Soiduulatus: " + kogus);
            return kogus;
        }

        public static void HaldaAutosid()
        {
            List<Auto> auto = new List<Auto>()
        {
            new Auto("Toyota", 5.5, 40),
            new Auto("BMW", 8.0, 15),
            new Auto("Audi", 6.5, 8)
        };
            Auto parim = auto.OrderByDescending(a => a.ArvutaSoiduulatus()).First();
            Console.WriteLine("Suurima sõiduulatusega auto: " + parim.Mudel);

            var vajaTankida = auto.Where(a => a.PaagisOnKutust < 10);
            Console.WriteLine("Vajavad tankimist:");
            foreach (var a in vajaTankida)
            {
                Console.WriteLine(a.Mudel);
            }

  
            using (StreamWriter sw = new StreamWriter("autod.txt"))
            {
                foreach (var a in auto)
                {
                    sw.WriteLine($"{a.Mudel},{a.KutuseKulu},{a.PaagisOnKutust}");
                }
            }


        }
    }
    public class AndmeFunktsioonid
    {
        public static void KirjutaLogi(string kasutaja)
        {
            string path = @"..\..\..\logi.txt";
            string date = DateTime.Now.ToString();

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{date} - {kasutaja}");
            }
        }
        public static void RiigiOtsing(Dictionary<string, string> riigid)
        {
            Console.Write("sisesta riik:  ");
            string riik = Console.ReadLine().ToUpper();

            if (riigid.ContainsKey(riik))
            {
                Console.WriteLine("Riik: " + riigid[riik]);
            }
            else
            {
                Console.Write("Riiki ei leitud. Sisesta riigi nimi: ");

            }

        }

        public static Tuple<int, double> LoeJaArvuta()
        {
            try
            {
                string text = File.ReadAllText("arvud.txt");
                string[] osad = text.Split(',');

                int summa = 0;
                foreach (string s in osad)
                {
                    summa += int.Parse(s);
                }

                double keskmine = summa / osad.Length;
                Console.WriteLine($"summa: {summa}; keakmine: {Math.Round(keskmine), 2}");
                return new Tuple<int, double>(summa, keskmine);

            }
            catch (Exception e)
            {
                Console.WriteLine("Viga: " + e);
                return new Tuple<int, double>(0, 0);
            }
        }
       



    }

    
}
    
