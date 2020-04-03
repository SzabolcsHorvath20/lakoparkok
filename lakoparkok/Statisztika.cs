using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lakoparkok
{
    public partial class Statisztika : Form
    {
        List<string> statisztika;

        public Statisztika(List<string> statisztika)
        {
            InitializeComponent();
            this.statisztika = statisztika;
        }

        private void Statisztika_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < statisztika.Count; i++)
            {
                listBox1.Items.Add(statisztika[i]);
            }
        }
    }
}
