using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SmileDent
{
    public partial class Regjistrimi : Form
    {
        public Regjistrimi()
        {
            InitializeComponent();
        }

     
        private void regjkthehubtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Kyqja();
            dritarjare.Show();
        }

        private void regjkyqulink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var dritarjare = new Kyqja();
            dritarjare.Show();
        }

        
        private void regjregjistrohubtn_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(regjidbox.Text))
            {
                MessageBox.Show("Ju lutem shkruani ID!");
                return;
            }

            if (string.IsNullOrWhiteSpace(regjperdoruesibox.Text))
            {
                MessageBox.Show("Ju lutem shkruani emrin e përdoruesit!");
                return;
            }

            if (string.IsNullOrWhiteSpace(regjemailbox.Text))
            {
                MessageBox.Show("Ju lutem shkruani email!");
                return;
            }

            if (!regjemailbox.Text.Contains("@") || !regjemailbox.Text.Contains("."))
            {
                MessageBox.Show("Email-i duhet të përmbajë '@' dhe '.'", "Kujdes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(regjfjalekalimibox.Text))
            {
                MessageBox.Show("Ju lutem shkruani fjalëkalimin!");
                return;
            }

            if (string.IsNullOrWhiteSpace(regjadresabox.Text))
            {
                MessageBox.Show("Ju lutem shkruani adresën!");
                return;
            }

            if (string.IsNullOrWhiteSpace(regjnrtelbox.Text))
            {
                MessageBox.Show("Ju lutem shkruani numrin e telefonit!");
                return;
            }

            
            SqlConnection lidhjasql = new SqlConnection(@"Data Source=LH\SQLEXPRESS;Initial Catalog=smiledentdb;Integrated Security=True");
            SqlCommand urdheri = new SqlCommand(@"INSERT INTO [dbo].[Perdoruesit]
               ([id],[perdoruesi],[email],[fjalekalimi],[adresa],[nrtel])
         VALUES
        ('" + regjidbox.Text + "','" + regjperdoruesibox.Text + "','" + regjemailbox.Text + "','" + regjfjalekalimibox.Text + "','" + regjadresabox.Text + "','" + regjnrtelbox.Text + "')", lidhjasql);

            lidhjasql.Open();
            urdheri.ExecuteNonQuery();
            urdheri.CommandTimeout = 60; 
            lidhjasql.Close();

            
            MessageBox.Show("Urime, ju u regjistruat me sukses!\nPo ju drejtojmë tek faqja Ballina...");

            this.Hide();
            var ballinaDritare = new Ballina();
            ballinaDritare.Show();
        }
    }
}