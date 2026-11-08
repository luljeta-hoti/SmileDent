namespace SmileDent
{
    partial class Kyqja
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kyqja));
            kyqjallogo = new PictureBox();
            kyqjaemail = new Label();
            kyqjafjalekalimi = new Label();
            kyqjaemailbox = new TextBox();
            kyqjafjalekalimibox = new TextBox();
            kyqjakyqubtn = new Button();
            label3 = new Label();
            kyqjaregjistrohulink = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)kyqjallogo).BeginInit();
            SuspendLayout();
            // 
            // kyqjallogo
            // 
            kyqjallogo.BackColor = Color.Transparent;
            kyqjallogo.Image = (Image)resources.GetObject("kyqjallogo.Image");
            kyqjallogo.Location = new Point(471, 205);
            kyqjallogo.Name = "kyqjallogo";
            kyqjallogo.Size = new Size(310, 107);
            kyqjallogo.SizeMode = PictureBoxSizeMode.Zoom;
            kyqjallogo.TabIndex = 0;
            kyqjallogo.TabStop = false;
            // 
            // kyqjaemail
            // 
            kyqjaemail.AutoSize = true;
            kyqjaemail.BackColor = Color.Transparent;
            kyqjaemail.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kyqjaemail.Location = new Point(471, 339);
            kyqjaemail.Name = "kyqjaemail";
            kyqjaemail.Size = new Size(79, 31);
            kyqjaemail.TabIndex = 1;
            kyqjaemail.Text = "Email:";
            // 
            // kyqjafjalekalimi
            // 
            kyqjafjalekalimi.AutoSize = true;
            kyqjafjalekalimi.BackColor = Color.Transparent;
            kyqjafjalekalimi.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kyqjafjalekalimi.Location = new Point(471, 389);
            kyqjafjalekalimi.Name = "kyqjafjalekalimi";
            kyqjafjalekalimi.Size = new Size(137, 31);
            kyqjafjalekalimi.TabIndex = 2;
            kyqjafjalekalimi.Text = "Fjalëkalimi:";
            // 
            // kyqjaemailbox
            // 
            kyqjaemailbox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kyqjaemailbox.Location = new Point(634, 336);
            kyqjaemailbox.Name = "kyqjaemailbox";
            kyqjaemailbox.Size = new Size(145, 38);
            kyqjaemailbox.TabIndex = 3;
            // 
            // kyqjafjalekalimibox
            // 
            kyqjafjalekalimibox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kyqjafjalekalimibox.Location = new Point(634, 386);
            kyqjafjalekalimibox.Name = "kyqjafjalekalimibox";
            kyqjafjalekalimibox.Size = new Size(145, 38);
            kyqjafjalekalimibox.TabIndex = 4;
            kyqjafjalekalimibox.UseSystemPasswordChar = true;
            // 
            // kyqjakyqubtn
            // 
            kyqjakyqubtn.BackColor = Color.FromArgb(35, 66, 130);
            kyqjakyqubtn.FlatAppearance.BorderSize = 0;
            kyqjakyqubtn.FlatStyle = FlatStyle.Flat;
            kyqjakyqubtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kyqjakyqubtn.ForeColor = Color.White;
            kyqjakyqubtn.Location = new Point(479, 455);
            kyqjakyqubtn.Name = "kyqjakyqubtn";
            kyqjakyqubtn.Size = new Size(300, 40);
            kyqjakyqubtn.TabIndex = 5;
            kyqjakyqubtn.Text = "Kyçu";
            kyqjakyqubtn.UseVisualStyleBackColor = false;
            kyqjakyqubtn.Click += kyqjakyqubtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(479, 498);
            label3.Name = "label3";
            label3.Size = new Size(125, 23);
            label3.TabIndex = 6;
            label3.Text = "Nuk ke llogari?";
            // 
            // kyqjaregjistrohulink
            // 
            kyqjaregjistrohulink.AutoSize = true;
            kyqjaregjistrohulink.BackColor = Color.Transparent;
            kyqjaregjistrohulink.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            kyqjaregjistrohulink.LinkBehavior = LinkBehavior.NeverUnderline;
            kyqjaregjistrohulink.LinkColor = Color.FromArgb(35, 66, 130);
            kyqjaregjistrohulink.Location = new Point(601, 498);
            kyqjaregjistrohulink.Name = "kyqjaregjistrohulink";
            kyqjaregjistrohulink.Size = new Size(139, 23);
            kyqjaregjistrohulink.TabIndex = 7;
            kyqjaregjistrohulink.TabStop = true;
            kyqjaregjistrohulink.Text = "Regjistrohu Tani";
            kyqjaregjistrohulink.LinkClicked += kyqjaregjistrohulink_LinkClicked;
            // 
            // Kyqja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1248, 719);
            Controls.Add(kyqjaregjistrohulink);
            Controls.Add(label3);
            Controls.Add(kyqjakyqubtn);
            Controls.Add(kyqjafjalekalimibox);
            Controls.Add(kyqjaemailbox);
            Controls.Add(kyqjafjalekalimi);
            Controls.Add(kyqjaemail);
            Controls.Add(kyqjallogo);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Kyqja";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SmileDent - Kyçja";
            ((System.ComponentModel.ISupportInitialize)kyqjallogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox kyqjallogo;
        private Label kyqjaemail;
        private Label kyqjafjalekalimi;
        private TextBox kyqjaemailbox;
        private TextBox kyqjafjalekalimibox;
        private Button kyqjakyqubtn;
        private Label label3;
        private LinkLabel kyqjaregjistrohulink;
    }
}
