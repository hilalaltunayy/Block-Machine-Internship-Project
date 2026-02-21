namespace denem2
{
    partial class Uyari
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Siemens Serif SC Semi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(894, 568);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 116);
            this.button1.TabIndex = 0;
            this.button1.Text = "OKUDUM KABUL EDİYORUM";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Siemens Serif SC Semi", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(516, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(983, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "ÇEVRÜKLER MAKİNA BİMS BLOK ÜRETİM YAZILIMI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Siemens Serif SC Semi", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(386, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1185, 41);
            this.label2.TabIndex = 2;
            this.label2.Text = "DİKKAT HİDROLİKLERİ KAPATMADAN MAKİNAYA MÜDAHALE ETMEYİN!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Siemens Serif SC Semi", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(246, 448);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1427, 41);
            this.label3.TabIndex = 3;
            this.label3.Text = "DİKKAT GEREKLİ EMNİYET TEDBİRLERİNİ ALMADAN MAKİNAYA  MÜDAHALE ETMEYİN!";
            // 
            // Uyari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Uyari";
            this.Text = "Uyarı";
            this.Load += new System.EventHandler(this.Uyari_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}