namespace WinFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_about = new System.Windows.Forms.Button();
            this.btn_teams = new System.Windows.Forms.Button();
            this.btn_races = new System.Windows.Forms.Button();
            this.btn_champ = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MotoGP Display Bold", 47.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(168, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(906, 85);
            this.label1.TabIndex = 0;
            this.label1.Text = "DÜNYA DAYANIKLILIK ŞAMPİYONASI";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("MotoGP Display Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(71, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 177);
            this.button1.TabIndex = 9;
            this.button1.Text = "Sürücüler";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_about
            // 
            this.btn_about.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_about.BackgroundImage")));
            this.btn_about.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_about.Font = new System.Drawing.Font("MotoGP Display Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_about.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_about.Location = new System.Drawing.Point(940, 418);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(231, 177);
            this.btn_about.TabIndex = 10;
            this.btn_about.Text = "Hakkında";
            this.btn_about.UseVisualStyleBackColor = true;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // btn_teams
            // 
            this.btn_teams.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_teams.BackgroundImage")));
            this.btn_teams.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_teams.Font = new System.Drawing.Font("MotoGP Display Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_teams.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_teams.Location = new System.Drawing.Point(361, 179);
            this.btn_teams.Name = "btn_teams";
            this.btn_teams.Size = new System.Drawing.Size(231, 177);
            this.btn_teams.TabIndex = 11;
            this.btn_teams.Text = "Takımlar";
            this.btn_teams.UseVisualStyleBackColor = true;
            this.btn_teams.Click += new System.EventHandler(this.btn_teams_Click);
            // 
            // btn_races
            // 
            this.btn_races.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_races.BackgroundImage")));
            this.btn_races.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_races.Font = new System.Drawing.Font("MotoGP Display Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_races.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_races.Location = new System.Drawing.Point(653, 179);
            this.btn_races.Name = "btn_races";
            this.btn_races.Size = new System.Drawing.Size(231, 177);
            this.btn_races.TabIndex = 12;
            this.btn_races.Text = "Yarış Sonuçları";
            this.btn_races.UseVisualStyleBackColor = true;
            this.btn_races.Click += new System.EventHandler(this.btn_races_Click);
            // 
            // btn_champ
            // 
            this.btn_champ.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_champ.BackgroundImage")));
            this.btn_champ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_champ.Font = new System.Drawing.Font("MotoGP Display Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_champ.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_champ.Location = new System.Drawing.Point(940, 179);
            this.btn_champ.Name = "btn_champ";
            this.btn_champ.Size = new System.Drawing.Size(231, 177);
            this.btn_champ.TabIndex = 13;
            this.btn_champ.Text = "Sürücüler Puan Durumu";
            this.btn_champ.UseVisualStyleBackColor = true;
            this.btn_champ.Click += new System.EventHandler(this.btn_champ_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("MotoGP Display Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(71, 418);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(231, 177);
            this.button2.TabIndex = 14;
            this.button2.Text = "Geçmiş Şampiyonlar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("MotoGP Display Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(361, 418);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(231, 177);
            this.button3.TabIndex = 15;
            this.button3.Text = "Le Mans Galipleri";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Font = new System.Drawing.Font("MotoGP Display Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(653, 414);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(231, 177);
            this.button4.TabIndex = 16;
            this.button4.Text = "Üreticiler Puan Durumu";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1253, 705);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_champ);
            this.Controls.Add(this.btn_races);
            this.Controls.Add(this.btn_teams);
            this.Controls.Add(this.btn_about);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button1;
        private Button btn_about;
        private Button btn_teams;
        private Button btn_races;
        private Button btn_champ;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}