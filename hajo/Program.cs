using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



/* 
 * 1. Hány hajó van?
 * 2.Melyik hajó(k) a legdrágábbak
 * 3.Névsorban a hajok.txt-be kell kiiratni a hajók nevét
 * 4. melyik hajótipusból van a legtöbb
 */
namespace hajo
{
    class Program
    {
        static List<Hajo> hajok = new List<Hajo>();
        static List<string> sorba = new List<string>();

        static void Beolvasas()
        {
            StreamReader sr = new StreamReader("hajo.csv");
            string b = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                hajok.Add(new Hajo(sr.ReadLine()));
            }
            sr.Close();

        }


        static void elso()
        {
            int ossze = 0;
            while (ossze < hajok.Count)
            {
                ossze++;
            }
            Console.WriteLine("Hajók száma {0}",ossze);
        }

        static void kettes()
        {
            int max = 0;
            foreach (var m in hajok)
            {
                if (m.Dij >= max)
                {
                    max = m.Dij;
                }
            }
            foreach (var n in hajok)
            {
                if (n.Dij == max)
                {
                    Console.WriteLine(n.Nev);
                }
            }
           
        }
        static void harmas()
        {
            StreamWriter sw = new StreamWriter("hajok.txt");

            for (int i = 0; i < hajok.Count; i++)
            {
                sorba.Add(hajok[i].Nev);
            }
            sorba.Sort();

            for (int i = 0; i < sorba.Count; i++)
            {
                sw.WriteLine(sorba[i]);
            }



            sw.Close();
        }
        static void Main(string[] args)
        {
            Beolvasas();
            //foreach (var b in hajok)
            //{
            //    Console.WriteLine(b.Regiszter +" "+ b.Nev + " "+ b.Tipus +" " + b.Utas + " "+ b.Dij);
            //}
            elso();
            kettes();
            harmas();



            Console.ReadKey();
        }
    }
}
