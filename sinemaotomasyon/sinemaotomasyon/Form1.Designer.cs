namespace sinemaotomasyon
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.filmcombo = new System.Windows.Forms.ComboBox();
            this.saloncombo = new System.Windows.Forms.ComboBox();
            this.seanscombo = new System.Windows.Forms.ComboBox();
            this.rezervebtn = new System.Windows.Forms.Button();
            this.duzenle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Cıkısbutton = new System.Windows.Forms.Button();
            this.kullanici_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // filmcombo
            // 
            this.filmcombo.FormattingEnabled = true;
            this.filmcombo.Location = new System.Drawing.Point(237, 51);
            this.filmcombo.Name = "filmcombo";
            this.filmcombo.Size = new System.Drawing.Size(178, 21);
            this.filmcombo.TabIndex = 0;
            this.filmcombo.Click += new System.EventHandler(this.filmcombo_Click);
            // 
            // saloncombo
            // 
            this.saloncombo.FormattingEnabled = true;
            this.saloncombo.Location = new System.Drawing.Point(237, 90);
            this.saloncombo.Name = "saloncombo";
            this.saloncombo.Size = new System.Drawing.Size(178, 21);
            this.saloncombo.TabIndex = 1;
            this.saloncombo.Click += new System.EventHandler(this.saloncombo_Click);
            // 
            // seanscombo
            // 
            this.seanscombo.FormattingEnabled = true;
            this.seanscombo.Location = new System.Drawing.Point(237, 127);
            this.seanscombo.Name = "seanscombo";
            this.seanscombo.Size = new System.Drawing.Size(178, 21);
            this.seanscombo.TabIndex = 2;
            this.seanscombo.Click += new System.EventHandler(this.seanscombo_Click);
            // 
            // rezervebtn
            // 
            this.rezervebtn.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rezervebtn.Location = new System.Drawing.Point(240, 180);
            this.rezervebtn.Name = "rezervebtn";
            this.rezervebtn.Size = new System.Drawing.Size(175, 30);
            this.rezervebtn.TabIndex = 3;
            this.rezervebtn.Text = "rezerve et";
            this.rezervebtn.UseVisualStyleBackColor = true;
            this.rezervebtn.Click += new System.EventHandler(this.rezervebtn_Click);
            // 
            // duzenle
            // 
            this.duzenle.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duzenle.Location = new System.Drawing.Point(240, 216);
            this.duzenle.Name = "duzenle";
            this.duzenle.Size = new System.Drawing.Size(175, 35);
            this.duzenle.TabIndex = 4;
            this.duzenle.Text = "düzenle";
            this.duzenle.UseVisualStyleBackColor = true;
            this.duzenle.Click += new System.EventHandler(this.duzenle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Film seçin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Salon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(157, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Seans";
            // 
            // Cıkısbutton
            // 
            this.Cıkısbutton.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cıkısbutton.Location = new System.Drawing.Point(552, 303);
            this.Cıkısbutton.Name = "Cıkısbutton";
            this.Cıkısbutton.Size = new System.Drawing.Size(75, 28);
            this.Cıkısbutton.TabIndex = 8;
            this.Cıkısbutton.Text = "çıkış";
            this.Cıkısbutton.UseVisualStyleBackColor = true;
            this.Cıkısbutton.Click += new System.EventHandler(this.Cıkısbutton_Click);
            // 
            // kullanici_label
            // 
            this.kullanici_label.AutoSize = true;
            this.kullanici_label.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kullanici_label.ForeColor = System.Drawing.Color.Red;
            this.kullanici_label.Location = new System.Drawing.Point(113, 13);
            this.kullanici_label.Name = "kullanici_label";
            this.kullanici_label.Size = new System.Drawing.Size(81, 19);
            this.kullanici_label.TabIndex = 9;
            this.kullanici_label.Text = "kullanıcı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hoşgeldin:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(699, 343);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.kullanici_label);
            this.Controls.Add(this.Cıkısbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.duzenle);
            this.Controls.Add(this.rezervebtn);
            this.Controls.Add(this.seanscombo);
            this.Controls.Add(this.saloncombo);
            this.Controls.Add(this.filmcombo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox filmcombo;
        private System.Windows.Forms.ComboBox saloncombo;
        private System.Windows.Forms.ComboBox seanscombo;
        private System.Windows.Forms.Button rezervebtn;
        private System.Windows.Forms.Button duzenle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Cıkısbutton;
        private System.Windows.Forms.Label kullanici_label;
        private System.Windows.Forms.Label label4;
    }
}

