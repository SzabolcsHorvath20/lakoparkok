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
            string[] L;

            StreamReader R = new StreamReader(filenev);
            while (! R.EndOfStream)
            {
                string nev = R.ReadLine();
                if (nev.Length > 0)
                {
                    string[] T = R.ReadLine().Split(';');
                    int utcaSzam = int.Parse(T[0]);
                    int maxhazSzam  = int.Parse(T[1]);
                    int[,] TH = new int[utcaSzam,maxhazSzam];
                    for (int s= 0; s < utcaSzam; s++)
                    {
                        for (int o = 0; o < maxhazSzam; o++)
                        {
                            TH[s, o] = 0;
                        }
                    }
                    do
                    {
                        L = R.ReadLine().Split(';');  
                        if (L[0] != "") {
                            TH[ int.Parse(L[0]) - 1 , int.Parse(L[1]) - 1] = 
                              int.Parse(L[2]);
                        }

                    } while (L[0] != "");

                    Lakopark LP = new Lakopark(nev, utcaSzam, maxhazSzam, TH);
                    lakoparkok.Add(LP);
                }
            }
            R.Close();
        }
    }
}
