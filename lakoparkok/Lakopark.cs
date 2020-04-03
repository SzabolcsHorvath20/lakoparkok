using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lakoparkok
{
    class Lakopark
    {
        private int[,] hazak;
        private int maxHazSzam;
        private string nev;
        private int utcakSzama;
        private int elso;
        private double beepitettseg;
        private int bevetel;

        public Lakopark(string nev, int utcakSzama, int maxHazSzam, int[,] hazak)
        {
            this.nev = nev;
            this.utcakSzama = utcakSzama;
            this.maxHazSzam = maxHazSzam;
            this.hazak = hazak;
        }

        public int[,] Hazak
        {
            get
            {
                return hazak;
            }
         
        }

        public int MaxHazSzam
        {
            get
            {
                return maxHazSzam;
            }

        }

        public string Nev
        {
            get
            {
                return nev;
            }
        }
        
        public int UtcakSzama
        {
            get
            {
                return utcakSzama;
            }

        }
        public int Elso
        {
            get { return elso; }
            set { elso = value; }
        }

        public double Beepitettseg
        {
            get { return beepitettseg; }
            set { beepitettseg = value; }
        }

        public int Bevetel
        {
            get { return bevetel; }
            set { bevetel = value; }
        }
    }
}
