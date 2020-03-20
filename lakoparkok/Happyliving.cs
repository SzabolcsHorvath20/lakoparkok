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
    }
}
