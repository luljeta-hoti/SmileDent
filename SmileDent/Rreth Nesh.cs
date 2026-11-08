using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmileDent
{
    public partial class Rreth_Nesh : Form
    {
        public Rreth_Nesh()
        {
            InitializeComponent();
        }

        private void rrethshkyqubtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Kyqja();
            dritarjare.Show();
        }

        private void rrehtpanelibtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Ballina();
            dritarjare.Show();
        }

        private void rrethraportibtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Raporti();
            dritarjare.Show();
        }

        private void rrethsherbimetbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Sherbimet();
            dritarjare.Show();
        }

        private void rrethkontaktibtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Kontakti();
            dritarjare.Show();
        }

        private void Rreth_Nesh_Load(object sender, EventArgs e)
        {
            rrethemrinavbar.Text = "Përshendetje, " + Sesioni.EmriPërdoruesit;

        }
    }
}
