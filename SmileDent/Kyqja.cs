using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SmileDent
{
    public partial class Kyqja : Form
    {
        public Kyqja()
        {
            InitializeComponent();
        }

        private void kyqjaregjistrohulink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var dritarjare = new Regjistrimi();
            dritarjare.Show();
        }

        private void kyqjakyqubtn_Click(object sender, EventArgs e)
        {
            
            if (!kyqjaemailbox.Text.Contains("@") || !kyqjaemailbox.Text.Contains("."))
            {
                MessageBox.Show("Email-i duhet të përmbajë '@' dhe '.'", "Kujdes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (kyqjaemailbox.Text.Trim().Length == 0 || kyqjafjalekalimibox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Fushat jane te zbrazura e lutem plotesoj ato!");
                return;
            }

            
            using (SqlConnection lidhjasql = new SqlConnection(@"Data Source=LH\SQLEXPRESS;Initial Catalog=smiledentdb;Integrated Security=True; Connect Timeout=60"))
            {
                lidhjasql.Open();
                SqlCommand cmd = new SqlCommand("SELECT Perdoruesi FROM [dbo].[Perdoruesit] WHERE Email=@email AND Fjalekalimi=@fjalekalimi", lidhjasql);
                cmd.Parameters.AddWithValue("@email", kyqjaemailbox.Text.Trim());
                cmd.Parameters.AddWithValue("@fjalekalimi", kyqjafjalekalimibox.Text.Trim());

                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    
                    Sesioni.EmriPërdoruesit = result.ToString();

                    MessageBox.Show("Urime, u kyqet me sukses!\nPo ju drejtojmë tek Ballina...");

                  
                    var dritarjare = new Ballina();
                    dritarjare.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Perdoruesi ose fjalekalimi jane gabim, ju lutem provoni perseri!");
                }
            }
        }
    }

    
    public static class Sesioni
    {
        public static string EmriPërdoruesit;
    }
}