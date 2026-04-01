using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Formats.Tar;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;
using System.Xml.Schema;

namespace kontrolltöö
{
    internal class AndmeFunktsioonid
    {
        public static void KirjutaLogi()
        {
            string retseptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logi.txt");

            if (File.Exists(retseptPath))
            {

            }
        }

        public static void RiigiOtsing()
        {
            Dictionary<string, string> Riigid = new Dictionary<string, string>();
            Riigid.Add("EE", "Eesti");
            Riigid.Add("FI", "Soome");
            Console.WriteLine("Palun sissesta Riigikood: ");
            string riik = Console.ReadLine();
            foreach (KeyValuePair<string, string> paar in Riigid)
            {
                if(paar.Key == riik)
                {
                    Console.WriteLine("Riik on:" + paar.Value);
                    break;
                }
                foreach (KeyValuePair<string, string> paar2 in Riigid)
                {
                    if (paar2.Key != riik)
                    {
                        Console.WriteLine("Meil ei ole see riik!");
                        Console.WriteLine("Mis riik see on?: ");
                        string vastus = Console.ReadLine();
                        Riigid.Add(riik, vastus);
                    }
                }


                }
            }
        

        public class Auto()
        {
            public string Mudel { get; set; }
            public double KutuseKulu { get; set; }
            public double PaagisOnKutust { get; set; }

            public static double ArvutaSoiduulatus(double KutuseKulu, double PaagisOnKutust)
            {
                double vastus = (PaagisOnKutust / KutuseKulu * 100);
                return vastus;

            }

        }





       public static void LoeJaArvuta()
       {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "arvud.txt");
                StreamReader numbrid = new StreamReader(path);
                string laused = numbrid.ReadToEnd();
                laused.Split(",");
                numbrid.Close();
        }

        public static void AndmeFunktsioonidd()
        {

        }

        public static void AndmeFunktsjonijiet()
        {

        }

        }
    }
