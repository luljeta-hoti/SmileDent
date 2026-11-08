using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace SmileDent
{
    public partial class Raporti : Form
    {
        public Raporti()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void rapshkyqubtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Kyqja();
            dritarjare.Show();
        }

        private void rappanelibtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Ballina();
            dritarjare.Show();
        }

        private void rapsherbimetbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Sherbimet();
            dritarjare.Show();
        }

        private void raprrethneshbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Rreth_Nesh();
            dritarjare.Show();
        }

        private void rapkontaktibtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarjare = new Kontakti();
            dritarjare.Show();
        }

        private void Raporti_Load(object sender, EventArgs e)
        {
            rapemrinavbar.Text = "Përshendetje, " + Sesioni.EmriPërdoruesit;
            rapdatagrid.AutoGenerateColumns = true; 

            rapsherbimetcombobox.Items.Add("Kontrollë dentare");
            rapsherbimetcombobox.Items.Add("Pastrim i dhëmbëve");
            rapsherbimetcombobox.Items.Add("Mbushje");
            rapsherbimetcombobox.Items.Add("Heqje dhëmbi");
            rapsherbimetcombobox.Items.Add("Ortodonci");
            rapsherbimetcombobox.Items.Add("Implant");

            rapsherbimetcombobox.DropDownStyle = ComboBoxStyle.DropDownList;

           
            raporacombobox.Items.Add("09:00");
            raporacombobox.Items.Add("09:30");
            raporacombobox.Items.Add("10:00");
            raporacombobox.Items.Add("10:30");
            raporacombobox.Items.Add("11:00");
            raporacombobox.Items.Add("11:30");
            raporacombobox.Items.Add("12:00");
            raporacombobox.Items.Add("12:30");
            raporacombobox.Items.Add("13:00");
            raporacombobox.Items.Add("13:30");
            raporacombobox.Items.Add("14:00");
            raporacombobox.Items.Add("14:30");
            raporacombobox.Items.Add("15:00");
            raporacombobox.Items.Add("15:30");
            raporacombobox.Items.Add("16:00");
            raporacombobox.Items.Add("16:30");
            raporacombobox.Items.Add("17:00");
            raporacombobox.Items.Add("17:30");
            raporacombobox.Items.Add("18:00");

            raporacombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadRezervimet();
        }

        private void LoadRezervimet()
        {
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["SmileDentDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Rezervimet ";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmriPerdoruesi", Sesioni.EmriPërdoruesit);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        rapdatagrid.DataSource = dt;
                        rapdatagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        rapdatagrid.ScrollBars = ScrollBars.Vertical;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabim gjatë ngarkimit të rezervimeve: " + ex.Message);
            }
        }

        private void rapdatagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = rapdatagrid.Rows[e.RowIndex];
                rapemribox.Text = row.Cells["emridhembiemri"].Value.ToString();
                rapnrtelmaskedbox.Text = row.Cells["numritelefonit"].Value.ToString();
                rapemailbox.Text = row.Cells["email"].Value.ToString();
                rapsherbimetcombobox.Text = row.Cells["sherbimi"].Value.ToString();

                string alergji = row.Cells["alergjite"].Value.ToString();
                rapalergjiteradio1.Checked = (alergji == "Po");
                rapalergjiteradio2.Checked = (alergji == "Jo");

                string prioritet = row.Cells["prioriteti"].Value.ToString();
                rapprioriteticheckbox.Checked = (prioritet == "Po");

              
                object dataValue = row.Cells["data"].Value;
                if (dataValue != DBNull.Value && !string.IsNullOrEmpty(dataValue.ToString()))
                {
                    rapdatatimepicker.Value = Convert.ToDateTime(dataValue);
                }
                else
                {
                    rapdatatimepicker.Value = DateTime.Now; 
                }

                object oraValue = row.Cells["ora"].Value;
                if (oraValue != DBNull.Value && !string.IsNullOrEmpty(oraValue.ToString()))
                {
                    raporacombobox.Text = oraValue.ToString();
                }
                else
                {
                    raporacombobox.SelectedIndex = -1; 
                }

               
                rapkomenterichbox.Text = row.Cells["komente"].Value.ToString();
            }
        }

        private bool ValidateForm()
        {
            List<string> gabimet = new List<string>();

            if (string.IsNullOrWhiteSpace(rapemribox.Text))
                gabimet.Add("Emri dhe mbiemri");

            if (string.IsNullOrWhiteSpace(rapnrtelmaskedbox.Text))
                gabimet.Add("Numri i telefonit");

            if (string.IsNullOrWhiteSpace(rapemailbox.Text))
                gabimet.Add("Emaili");
            else if (!rapemailbox.Text.Contains("@"))
                gabimet.Add("Emaili duhet të përmbajë '@'");

            if (string.IsNullOrWhiteSpace(rapsherbimetcombobox.Text))
                gabimet.Add("Shërbimi");

            if (!rapalergjiteradio1.Checked && !rapalergjiteradio2.Checked)
                gabimet.Add("Alergjitë (Po/Jo)");

            if (!rapprioriteticheckbox.Checked)
            {
                if (string.IsNullOrWhiteSpace(raporacombobox.Text))
                    gabimet.Add("Ora e rezervimit");

                if (rapdatatimepicker.Value == null)
                    gabimet.Add("Data e rezervimit");
            }

            if (gabimet.Count > 0)
            {
                string message = "Plotëso fushat e mëposhtme:\n- " + string.Join("\n- ", gabimet);
                MessageBox.Show(message, "Fusha të detyrueshme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void rapshtobtn_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["SmileDentDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Rezervimet 
                        (emridhembiemri, numritelefonit, email, sherbimi, alergjite, prioriteti, data, ora, komente)
                        VALUES (@emri, @nr, @email, @sherbimi, @alergjite, @prioriteti, @data, @ora, @komente)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@emri", rapemribox.Text);
                        cmd.Parameters.AddWithValue("@nr", rapnrtelmaskedbox.Text);
                        cmd.Parameters.AddWithValue("@email", rapemailbox.Text);
                        cmd.Parameters.AddWithValue("@sherbimi", rapsherbimetcombobox.Text);
                        cmd.Parameters.AddWithValue("@alergjite", rapalergjiteradio1.Checked ? "Po" : "Jo");
                        cmd.Parameters.AddWithValue("@prioriteti", rapprioriteticheckbox.Checked);
                        cmd.Parameters.AddWithValue("@data", rapdatatimepicker.Value.Date);
                        cmd.Parameters.AddWithValue("@ora", raporacombobox.Text);
                        cmd.Parameters.AddWithValue("@komente", rapkomenterichbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                }
                if (!ValidateForm()) return;

                LoadRezervimet();
                MessageBox.Show("Rezervimi u shtua me sukses!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabim gjatë shtimit: " + ex.Message);
            }
        }

        private void rapndryshobtn_Click(object sender, EventArgs e)
        {
            
            if (rapdatagrid.CurrentRow != null)
            {
                int id = Convert.ToInt32(rapdatagrid.CurrentRow.Cells["id"].Value);

                try
                {
                    string connString = ConfigurationManager.ConnectionStrings["SmileDentDB"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        string query = @"UPDATE Rezervimet SET 
                    emridhembiemri=@emri, numritelefonit=@nr, email=@email,
                    sherbimi=@sherbimi, alergjite=@alergjite, prioriteti=@prioriteti,
                    data=@data, ora=@ora, komente=@komente
                    WHERE id=@id";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@emri", rapemribox.Text);
                            cmd.Parameters.AddWithValue("@nr", rapnrtelmaskedbox.Text);
                            cmd.Parameters.AddWithValue("@email", rapemailbox.Text);
                            cmd.Parameters.AddWithValue("@sherbimi", rapsherbimetcombobox.Text);
                            cmd.Parameters.AddWithValue("@alergjite", rapalergjiteradio1.Checked ? "Po" : "Jo");
                            cmd.Parameters.AddWithValue("@prioriteti", rapprioriteticheckbox.Checked ? "Po" : "Jo");

                            
                            if (rapdatatimepicker.Value != null)
                                cmd.Parameters.AddWithValue("@data", rapdatatimepicker.Value.Date);
                            else
                                cmd.Parameters.AddWithValue("@data", DBNull.Value);

                            cmd.Parameters.AddWithValue("@ora", string.IsNullOrEmpty(raporacombobox.Text) ? DBNull.Value : (object)raporacombobox.Text);
                            cmd.Parameters.AddWithValue("@komente", rapkomenterichbox.Text);
                            cmd.Parameters.AddWithValue("@id", id);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    if (!ValidateForm()) return;
                    LoadRezervimet();
                    MessageBox.Show("Rezervimi u ndryshua me sukses!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gabim gjatë ndryshimit: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ju lutem zgjidhni një rresht nga tabela për të ndryshuar.");
            }
        }

        private void rapfshibtn_Click(object sender, EventArgs e)
        {
           
            if (rapdatagrid.CurrentRow != null)
            {
                
                int id = Convert.ToInt32(rapdatagrid.CurrentRow.Cells["id"].Value);

                
                var result = MessageBox.Show("A jeni i sigurt që doni të fshini këtë rezervim?",
                                             "Konfirmim Fshirjeje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return;

                try
                {
                    string connString = ConfigurationManager.ConnectionStrings["SmileDentDB"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Rezervimet WHERE id=@id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    LoadRezervimet(); 

                    
                    rapemribox.Clear();
                    rapnrtelmaskedbox.Clear();
                    rapemailbox.Clear();
                    rapsherbimetcombobox.SelectedIndex = -1;
                    rapalergjiteradio1.Checked = false;
                    rapalergjiteradio2.Checked = false;
                    rapprioriteticheckbox.Checked = false;
                    rapdatatimepicker.Value = DateTime.Now;
                    raporacombobox.SelectedIndex = -1;
                    rapkomenterichbox.Clear();

                    MessageBox.Show("Rezervimi u fshi me sukses!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gabim gjatë fshirjes: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ju lutem zgjidhni një rresht nga tabela.");
            }
        }

        private void rapprioriteticheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (rapprioriteticheckbox.Checked)
            {
                
                rapdatatimepicker.Enabled = false;
                raporacombobox.Enabled = false;
            }
            else
            {
                
                rapdatatimepicker.Enabled = true;
                raporacombobox.Enabled = true;
            }
        }

        private void rapkerkobtn_Click(object sender, EventArgs e)
        {

            string input = rapkerkobox.Text.Trim(); 

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Shkruaj ID për të kërkuar!", "Kujdes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connString = ConfigurationManager.ConnectionStrings["SmileDentDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Rezervimet WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", input);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            rapdatagrid.DataSource = dt; 
                        }
                        else
                        {
                            MessageBox.Show("Nuk u gjet asnjë rezervim me këtë ID.",
                                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadRezervimet(); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabim gjatë kërkimit: " + ex.Message);
            }
        }
    }
}
    

