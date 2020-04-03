using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace lakoparkok
{
    class HappyLiving
    {
        private List<Lakopark> lakoparkok = new List<Lakopark>();

        public List<Lakopark> Lakoparkok
        {
            get
            {
                return lakoparkok;
            }            
        }

        public HappyLiving(string filenev)
        {
            string[] split;

            StreamReader read = new StreamReader(filenev);
            while (!read.EndOfStream)
            {
                string nev = read.ReadLine();
                if (nev.Length > 0)
                {
                    string[] split2 = read.ReadLine().Split(';');
                    int utcaSzam = int.Parse(split2[0]);
                    int maxhazSzam  = int.Parse(split2[1]);
                    int[,] sor = new int[utcaSzam,maxhazSzam];
                    for (int s= 0; s < utcaSzam; s++)
                    {
                        for (int o = 0; o < maxhazSzam; o++)
                        {
                            sor[s, o] = 0;
                        }
                    }
                    do
                    {
                        split = read.ReadLine().Split(';');  
                        if (split[0] != "") {
                            sor[ int.Parse(split[0]) - 1 , int.Parse(split[1]) - 1] = 
                              int.Parse(split[2]);
                        }

                    } while (split[0] != "");

                    Lakopark LP = new Lakopark(nev, utcaSzam, maxhazSzam, sor);
                    lakoparkok.Add(LP);
                }
            }
            read.Close();
        }
        public void statisztika()
        {
            int hazakSzama;
            double percent;
            bool full;
            int price;
            int nm = 0;

            for (int i = 0; i < lakoparkok.Count; i++)
            {
                hazakSzama = 0;
                price = 0;

                lakoparkok[i].Elso = 0;
                lakoparkok[i].Beepitettseg = 0;
                for (int x = 0; x < lakoparkok[i].UtcakSzama; x++)
                {
                    full = true;
                    for (int y = 0; y < lakoparkok[i].MaxHazSzam; y++)
                    {
                        if (lakoparkok[i].Hazak[x, y] > 0)
                        {
                            hazakSzama++;
                            if (lakoparkok[i].Hazak[x, y] == 1)
                            {
                                nm = 80;
                            }
                            else if (lakoparkok[i].Hazak[x, y] == 1)
                            {
                                nm = 150;
                            }
                            else if (lakoparkok[i].Hazak[x, y] == 1)
                            {
                                nm = 200;
                            }
                            price += nm * 300000;
                        }
                        else
                        {
                            full = false;
                        }
                    }
                    if (full && lakoparkok[i].Elso == 0)
                    {
                        lakoparkok[i].Elso = x + 1;
                    }
                }
                percent =
                    (hazakSzama * 100) / (lakoparkok[i].UtcakSzama * lakoparkok[i].MaxHazSzam);
                lakoparkok[i].Beepitettseg = percent;
                lakoparkok[i].Bevetel = price;
            }
        }
        public int firstFullStreet()
        {
            int first = -1;
            int i = 0;
            while (i < lakoparkok.Count && first == -1)
            {
                if (lakoparkok[i].Elso > 0)
                {
                    first = i;
                }
                i++;
            }
            return first;
        }
        public List<int> topBuildUpDensity()
        {
            List<int> top = new List<int>();

            for (int i = 0; i < lakoparkok.Count; i++)
            {
                if (top.Count == 0)
                {
                    top.Add(i);
                }
                else
                {
                    if (lakoparkok[i].Beepitettseg == lakoparkok[(Int32)top[0]].Beepitettseg)
                    {
                        top.Add(i);
                    }
                    else if (lakoparkok[i].Beepitettseg > lakoparkok[(Int32)top[0]].Beepitettseg)
                    {
                        top.Clear();
                        top.Add(i);
                    }
                }
            }
            return top;
        }
    }

}
