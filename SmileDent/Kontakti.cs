using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmileDent
{
    public partial class Kontakti : Form
    {
        public Kontakti()
        {
            InitializeComponent();
        }

        private void konshkyqubtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Kyqja();
            dritarjare.Show();
        }

        private void konpanelibtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Ballina();
            dritarjare.Show();
        }

        private void konraportibtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Kontakti();
            dritarjare.Show();
        }

        private void konsherbimetbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Sherbimet();
            dritarjare.Show();
        }

        private void konrrethneshbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Rreth_Nesh();
            dritarjare.Show();
        }

        private void kondergobtn_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(konemribox.Text) ||
                string.IsNullOrWhiteSpace(konmbiemribox.Text) ||
                string.IsNullOrWhiteSpace(konnrtelmaskedbox.Text) ||
                string.IsNullOrWhiteSpace(konemailbox.Text) ||
                string.IsNullOrWhiteSpace(konmesazhirichbox.Text))
            {
                MessageBox.Show("Ju lutem plotësoni të gjitha fushat!", "Kujdes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (!konemailbox.Text.Contains("@") || !konemailbox.Text.Contains("."))
            {
                MessageBox.Show("Email-i duhet të përmbajë '@' dhe '.'", "Kujdes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                
                string connectionString = @"Data Source=LH\SQLEXPRESS;Initial Catalog=SmileDentDB;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    
                    string query = "INSERT INTO Mesazhet (Emri, Mbiemri, NrTel, Email, Mesazhi) " +
                                   "VALUES (@Emri, @Mbiemri, @NrTel, @Email, @Mesazhi)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Emri", konemribox.Text);
                        cmd.Parameters.AddWithValue("@Mbiemri", konmbiemribox.Text);
                        cmd.Parameters.AddWithValue("@NrTel", konnrtelmaskedbox.Text);
                        cmd.Parameters.AddWithValue("@Email", konemailbox.Text);
                        cmd.Parameters.AddWithValue("@Mesazhi", konmesazhirichbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Mesazhi u dërgua me sukses!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                konemribox.Clear();
                konmbiemribox.Clear();
                konnrtelmaskedbox.Clear();
                konemailbox.Clear();
                konmesazhirichbox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabim gjatë dërgimit: " + ex.Message, "Gabim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Kontakti_Load(object sender, EventArgs e)
        {
            konemrinavbar.Text = "Përshendetje, " + Sesioni.EmriPërdoruesit;
        }
    }
}
