namespace Voice_Rocognition
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_aktif = new System.Windows.Forms.Button();
            this.btn_nonAktif = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(260, 208);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btn_aktif
            // 
            this.btn_aktif.Enabled = false;
            this.btn_aktif.Location = new System.Drawing.Point(12, 226);
            this.btn_aktif.Name = "btn_aktif";
            this.btn_aktif.Size = new System.Drawing.Size(75, 23);
            this.btn_aktif.TabIndex = 1;
            this.btn_aktif.Text = "Aktifkan";
            this.btn_aktif.UseVisualStyleBackColor = true;
            this.btn_aktif.Click += new System.EventHandler(this.btn_aktif_Click);
            // 
            // btn_nonAktif
            // 
            this.btn_nonAktif.Location = new System.Drawing.Point(183, 226);
            this.btn_nonAktif.Name = "btn_nonAktif";
            this.btn_nonAktif.Size = new System.Drawing.Size(89, 23);
            this.btn_nonAktif.TabIndex = 2;
            this.btn_nonAktif.Text = "Non-Aktifkan";
            this.btn_nonAktif.UseVisualStyleBackColor = true;
            this.btn_nonAktif.Click += new System.EventHandler(this.btn_nonAktif_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_nonAktif);
            this.Controls.Add(this.btn_aktif);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Opacity = 0.6D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voice Recognition";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_aktif;
        private System.Windows.Forms.Button btn_nonAktif;
    }
}

