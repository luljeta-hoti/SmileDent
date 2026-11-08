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
    public partial class Ballina : Form
    {
        public Ballina()
        {
            InitializeComponent();
        }

        private void ballshkyqubtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Kyqja();
            dritarjare.Show();
        }

        private void ballraportibtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Raporti();
            dritarjare.Show();
        }

        private void ballsherbimetbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Sherbimet();
            dritarjare.Show();
        }

        private void ballrrethneshbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Rreth_Nesh();
            dritarjare.Show();
        }

        private void ballkontaktibtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Kontakti();
            dritarjare.Show();
        }

        private void ballrezervobtn_Click(object sender, EventArgs e)
        {
  
            if (string.IsNullOrWhiteSpace(ballemribox.Text))
            {
                MessageBox.Show("Ju lutem shkruani emrin dhe mbiemrin!");
                return;
            }

            if (string.IsNullOrWhiteSpace(ballnrtelmaskedbox.Text))
            {
                MessageBox.Show("Ju lutem shkruani numrin e telefonit!");
                return;
            }

            if (string.IsNullOrWhiteSpace(ballemailbox.Text))
            {
                MessageBox.Show("Ju lutem shkruani email!");
                return;
            }

            if (!ballemailbox.Text.Contains("@") || !ballemailbox.Text.Contains("."))
            {
                MessageBox.Show("Email-i duhet të përmbajë '@' dhe '.'", "Kujdes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ballsherbimetcombobox.SelectedIndex == -1)
            {
                MessageBox.Show("Ju lutem zgjedhni shërbimin!");
                return;
            }

         
            string alergjia = ballalergjiteradio1.Checked ? "Po" :
                              ballalergjiteradio2.Checked ? "Jo" : "";

            if (string.IsNullOrEmpty(alergjia))
            {
                MessageBox.Show("Ju lutem zgjidhni alergjitë!");
                return;
            }

           
            string prioriteti = ballprioriteticheckbox.Checked ? "Po" : "Jo";

            
            if (!ballprioriteticheckbox.Checked && ballorabox.SelectedIndex == -1)
            {
                MessageBox.Show("Ju lutem zgjedhni orën!");
                return;
            }

            
            using (SqlConnection lidhjasql = new SqlConnection(@"Data Source=LH\SQLEXPRESS;Initial Catalog=smiledentdb;Integrated Security=True"))
            {
                lidhjasql.Open();

                
                if (!ballprioriteticheckbox.Checked)
                {
                    SqlCommand kontrollo = new SqlCommand("SELECT COUNT(*) FROM Rezervimet WHERE data=@data AND ora=@ora", lidhjasql);
                    kontrollo.Parameters.AddWithValue("@data", balldatatimepicker.Value.Date);
                    kontrollo.Parameters.AddWithValue("@ora", ballorabox.Text);

                    int ekziston = (int)kontrollo.ExecuteScalar();
                    if (ekziston > 0)
                    {
                        MessageBox.Show("Ky termin është i zënë, ju lutem zgjidhni një orar tjetër!");
                        return;
                    }
                }

               
                SqlCommand urdheri = new SqlCommand(@"INSERT INTO Rezervimet
            (emridhembiemri, numritelefonit, email, sherbimi, alergjite, prioriteti, data, ora, komente)
            VALUES
            (@emri, @tel, @email, @sherbimi, @alergjia, @prioriteti, @data, @ora, @komente)", lidhjasql);

                urdheri.Parameters.AddWithValue("@emri", ballemribox.Text);
                urdheri.Parameters.AddWithValue("@tel", ballnrtelmaskedbox.Text);
                urdheri.Parameters.AddWithValue("@email", ballemailbox.Text);
                urdheri.Parameters.AddWithValue("@sherbimi", ballsherbimetcombobox.Text);
                urdheri.Parameters.AddWithValue("@alergjia", alergjia);
                urdheri.Parameters.AddWithValue("@prioriteti", prioriteti);

                
                if (ballprioriteticheckbox.Checked)
                {
                    urdheri.Parameters.AddWithValue("@data", DBNull.Value);
                    urdheri.Parameters.AddWithValue("@ora", DBNull.Value);
                }
                else
                {
                    urdheri.Parameters.AddWithValue("@data", balldatatimepicker.Value.Date);
                    urdheri.Parameters.AddWithValue("@ora", ballorabox.Text);
                }

                urdheri.Parameters.AddWithValue("@komente", string.IsNullOrWhiteSpace(ballkomenterichbox.Text) ? DBNull.Value : (object)ballkomenterichbox.Text);

                urdheri.ExecuteNonQuery();
            }

            
            MessageBox.Show("Rezervimi u krye me sukses! ✅\nPër më shumë mund t'i shikoni të gjitha terminet tuaja tek faqja Raporti.");

            
            ballemribox.Clear();
            ballnrtelmaskedbox.Clear();
            ballemailbox.Clear();
            ballsherbimetcombobox.SelectedIndex = -1;
            ballalergjiteradio1.Checked = false;
            ballalergjiteradio2.Checked = false;
            ballprioriteticheckbox.Checked = false;
            ballorabox.SelectedIndex = -1;
            ballkomenterichbox.Clear();
        }

        private void ballshikoterminetlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var dritarjare = new Raporti();
            dritarjare.Show();
        }

        private void ballprioriteticheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ballprioriteticheckbox.Checked)
            {
                balldatatimepicker.Enabled = false;
                ballorabox.Enabled = false;
            }
            else
            {
                balldatatimepicker.Enabled = true;
                ballorabox.Enabled = true;
            }
        }

        private void Ballina_Load(object sender, EventArgs e)
        {
            ballemrinavbar.Text = "Përshendetje, " + Sesioni.EmriPërdoruesit;

            
            ballsherbimetcombobox.Items.Add("Kontrollë dentare");
            ballsherbimetcombobox.Items.Add("Pastrim i dhëmbëve");
            ballsherbimetcombobox.Items.Add("Mbushje");
            ballsherbimetcombobox.Items.Add("Heqje dhëmbi");
            ballsherbimetcombobox.Items.Add("Ortodonci");
            ballsherbimetcombobox.Items.Add("Implant");

            ballsherbimetcombobox.DropDownStyle = ComboBoxStyle.DropDownList;

            ballorabox.Items.Add("09:00");
            ballorabox.Items.Add("09:30");
            ballorabox.Items.Add("10:00");
            ballorabox.Items.Add("10:30");
            ballorabox.Items.Add("11:00");
            ballorabox.Items.Add("11:30");
            ballorabox.Items.Add("12:00");
            ballorabox.Items.Add("12:30");
            ballorabox.Items.Add("13:00");
            ballorabox.Items.Add("13:30");
            ballorabox.Items.Add("14:00");
            ballorabox.Items.Add("14:30");
            ballorabox.Items.Add("15:00");
            ballorabox.Items.Add("15:30");
            ballorabox.Items.Add("16:00");
            ballorabox.Items.Add("16:30");
            ballorabox.Items.Add("17:00");
            ballorabox.Items.Add("17:30");
            ballorabox.Items.Add("18:00");

            
            ballorabox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
    }
