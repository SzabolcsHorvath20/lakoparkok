using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace lakoparkok
{
    public partial class Lakoparkok : Form
    {
        HappyLiving happyliving = new HappyLiving("lakoparkok.txt");
        int aktivlakopark;
        int maxutca = 0;
        int maxhaz = 0;
        int oldalméret;
        PictureBox[,] hazak;

        public Lakoparkok()
        {
            InitializeComponent();
        }

        private void Lakoparkok_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < happyliving.Lakoparkok.Count(); i++)
            {
                if (maxutca < happyliving.Lakoparkok[i].UtcakSzama)
                {
                    maxutca = happyliving.Lakoparkok[i].UtcakSzama;
                }
                if (maxhaz < happyliving.Lakoparkok[i].MaxHazSzam)
                {
                    maxhaz = happyliving.Lakoparkok[i].MaxHazSzam;
                }
            }
            oldalméret = 
                (int)Math.Min(Math.Floor((double)(panel1.Height / maxutca)), 
                              Math.Floor((double)(panel1.Width / maxhaz)));

            hazak = new PictureBox[maxutca,maxhaz];
            for (int ix = 0; ix < maxutca; ix++)
            {
                for (int iy = 0; iy < maxhaz; iy++)
                {
                    hazak[ix, iy] = new PictureBox();
                    hazak[ix, iy].Location = 
                        new System.Drawing.Point(iy * oldalméret, ix * oldalméret);
                    hazak[ix, iy].Size = 
                        new System.Drawing.Size(oldalméret-2, oldalméret-2);
                    hazak[ix, iy].SizeMode = PictureBoxSizeMode.StretchImage;
                    hazak[ix, iy].Visible = false;
                    hazak[ix, iy].Tag = ix.ToString() + ";" + iy.ToString();
                    hazak[ix, iy].Click += this.PictureClick;
                    panel1.Controls.Add(hazak[ix, iy]);
                }
            }

            aktivlakopark = 0;
            LakoparkKitesz();
        }

        private void PictureClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            string[] picture = pictureBox.Tag.ToString().Split(';');
            if (happyliving.Lakoparkok[aktivlakopark].Hazak[int.Parse(picture[0]), 
                int.Parse(picture[1])] == 3)
            {
                happyliving.Lakoparkok[aktivlakopark].Hazak[int.Parse(picture[0]), 
                    int.Parse(picture[1])] = 0;
            } else
            {
                happyliving.Lakoparkok[aktivlakopark].Hazak[int.Parse(picture[0]), 
                    int.Parse(picture[1])]++;
            }
            LakoparkKitesz();
        }

        private void LakoparkKitesz()
        {
            string picture;

            bLeft.Visible = (aktivlakopark > 0);
            bRight.Visible = (aktivlakopark < happyliving.Lakoparkok.Count()-1);
            pbNev.Image = 
                Image.FromFile(@"..\..\..\Kepek\"+ 
                               happyliving.Lakoparkok[aktivlakopark].Nev + ".jpg");
            this.Text = happyliving.Lakoparkok[aktivlakopark].Nev+" lakópark";
            for (int ix = 0; ix < maxutca; ix++)
            {
                for (int iy = 0; iy < maxhaz; iy++)
                {
                    if (happyliving.Lakoparkok[aktivlakopark].UtcakSzama > ix && 
                        happyliving.Lakoparkok[aktivlakopark].MaxHazSzam > iy)
                    {
                        switch (happyliving.Lakoparkok[aktivlakopark].Hazak[ix, iy])
                        {
                            case 0:
                                picture = "kereszt";
                                break;
                            default:
                                picture = 
                                    "Haz" + 
                                    happyliving.Lakoparkok[aktivlakopark].Hazak[ix, iy].ToString();
                                break;
                        }
                        picture = @"..\..\..\Kepek\"+ picture + ".jpg";
                        hazak[ix, iy].Image = Image.FromFile(picture);
                        hazak[ix, iy].Visible = true;
                    } else
                    {
                        hazak[ix, iy].Visible = false;
                    }
                }
            }
        }

        private void bRight_Click(object sender, EventArgs e)
        {
            if (aktivlakopark < happyliving.Lakoparkok.Count() - 1)
            {
                aktivlakopark++;
                LakoparkKitesz();
            }
        }

        private void bLeft_Click(object sender, EventArgs e)
        {
            if (aktivlakopark > 0)
            {
                aktivlakopark--;
                LakoparkKitesz();
            }
        }

        private void btnMentes_Click(object sender, EventArgs e)
        {
            try
            {
                string sourceFile = "lakoparkok.txt";
                string destFile = "lakoparkok_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".txt";
                System.IO.File.Copy(sourceFile, destFile, true);
                if (File.Exists(destFile))
                {
                    File.Delete(sourceFile);

                    using (StreamWriter sw = File.CreateText(sourceFile))
                    {
                        for (int i = 0; i < happyliving.Lakoparkok.Count; i++)
                        {
                            sw.WriteLine(happyliving.Lakoparkok[i].Nev);
                            sw.WriteLine(happyliving.Lakoparkok[i].UtcakSzama + ";" + happyliving.Lakoparkok[i].MaxHazSzam);
                            for (int x = 0; x < happyliving.Lakoparkok[i].UtcakSzama; x++)
                            {
                                for (int y = 0; y < happyliving.Lakoparkok[i].MaxHazSzam; y++)
                                {
                                    if (happyliving.Lakoparkok[i].Hazak[x, y] > 0)
                                    {
                                        sw.WriteLine((x + 1).ToString() + ";" +
                                                     (y + 1).ToString() + ";" +
                                                     happyliving.Lakoparkok[i].Hazak[x, y].ToString());
                                    }
                                }
                            }
                            sw.WriteLine("");
                        }
                    }

                    if (File.Exists(sourceFile))
                    {
                        MessageBox.Show("A mentés sikeres!",
                                        "",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        System.IO.File.Copy(destFile, sourceFile, true);
                        MessageBox.Show("A mentés sikertelen!",
                                        "",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("A mentés során hiba lépett fel!",
                                ex.Message,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnStatisztika_Click(object sender, EventArgs e)
        {
            List<String> stat = new List<String>();
            List<int> top = new List<int>();
            int first;

            happyliving.statisztika();

            stat.Add(
                "Az első lakópark, ahol van teljesen beépített utca: ");
            first = happyliving.firstFullStreet();
            if (first > -1)
            {
                stat.Add(
                    happyliving.Lakoparkok[first].Nev +
                    " (" + happyliving.Lakoparkok[first].Elso + ". utca)");
            }
            else
            {
                stat.Add(
                    "  Egyik lakóparkban sincs teljesen beépített utca.");
            }
            stat.Add(" ");

            stat.Add(
                "Arányaiban legjobban beépített lakópark(ok):");
            top = happyliving.topBuildUpDensity();
            for (int i = 0; i < top.Count; i++)
            {
                stat.Add(
                    "  " +
                    happyliving.Lakoparkok[(Int32)top[i]].Nev +
                    " (" + happyliving.Lakoparkok[(Int32)top[i]].Beepitettseg + "%)");
            }
            stat.Add(" ");

            stat.Add(
                "HappyLiving cég eddigi bevétele a lakóparkokból:");
            for (int i = 0; i < happyliving.Lakoparkok.Count; i++)
            {
                stat.Add(
                    "  " +
                    happyliving.Lakoparkok[i].Nev +
                    " (" + String.Format("{0,-14:C0}", (int)happyliving.Lakoparkok[i].Bevetel) + ")");
            }

            try
            {
                string destFile = "statisztika_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".txt";

                using (StreamWriter sw = File.CreateText(destFile))
                {
                    for (int i = 0; i < stat.Count; i++)
                    {
                        sw.WriteLine(stat[i]);
                    }
                }

            }
            catch (IOException ex)
            {
                MessageBox.Show("A statisztikai adatok mentése során hiba lépett fel!",
                                ex.Message,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            /* megjelenítjük */
            Statisztika statform = new Statisztika(stat);
            statform.ShowDialog(this);
        }
    }
}
