using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmileDent
{
    public partial class Sherbimet : Form
    {
        public Sherbimet()
        {
            InitializeComponent();
        }

        private void sershkyqubtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Kyqja();
            dritarjare.Show();
        }

        private void serpanelibtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Ballina();
            dritarjare.Show();
        }

        private void serraportibtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Raporti();
            dritarjare.Show();
        }

        private void serrethneshbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Rreth_Nesh();
            dritarjare.Show();
        }

        private void serkontaktibtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Kontakti();
            dritarjare.Show();
        }

        private void serrezervobtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Ballina();
            dritarjare.Show();
        }

        private void Sherbimet_Load(object sender, EventArgs e)
        {
            seremrinavbar.Text = "Përshendetje, " + Sesioni.EmriPërdoruesit;
        }
    }
}
