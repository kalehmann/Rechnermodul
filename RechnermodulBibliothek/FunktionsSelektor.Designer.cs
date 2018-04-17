namespace RechnermodulBibliothek
{
    partial class FunktionsSelektor
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
            this.funktionsPanel = new System.Windows.Forms.Panel();
            this.kontrollPanel = new System.Windows.Forms.Panel();
            this.btnBeenden = new System.Windows.Forms.Button();
            this.btnWeiter = new System.Windows.Forms.Button();
            this.kontrollPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // funktionsPanel
            // 
            this.funktionsPanel.Location = new System.Drawing.Point(7, 8);
            this.funktionsPanel.Name = "funktionsPanel";
            this.funktionsPanel.Size = new System.Drawing.Size(272, 10);
            this.funktionsPanel.TabIndex = 0;
            // 
            // kontrollPanel
            // 
            this.kontrollPanel.Controls.Add(this.btnWeiter);
            this.kontrollPanel.Controls.Add(this.btnBeenden);
            this.kontrollPanel.Location = new System.Drawing.Point(7, 35);
            this.kontrollPanel.Name = "kontrollPanel";
            this.kontrollPanel.Size = new System.Drawing.Size(271, 34);
            this.kontrollPanel.TabIndex = 1;
            // 
            // btnBeenden
            // 
            this.btnBeenden.Location = new System.Drawing.Point(3, 1);
            this.btnBeenden.Name = "btnBeenden";
            this.btnBeenden.Size = new System.Drawing.Size(115, 34);
            this.btnBeenden.TabIndex = 0;
            this.btnBeenden.Text = "Beenden";
            this.btnBeenden.UseVisualStyleBackColor = true;
            this.btnBeenden.Click += new System.EventHandler(this.btn_beenden_Click);
            // 
            // btnWeiter
            // 
            this.btnWeiter.Location = new System.Drawing.Point(139, 3);
            this.btnWeiter.Name = "btnWeiter";
            this.btnWeiter.Size = new System.Drawing.Size(122, 30);
            this.btnWeiter.TabIndex = 1;
            this.btnWeiter.Text = "Weiter";
            this.btnWeiter.UseVisualStyleBackColor = true;
            // 
            // FunktionsSelektor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 77);
            this.Controls.Add(this.kontrollPanel);
            this.Controls.Add(this.funktionsPanel);
            this.Name = "FunktionsSelektor";
            this.Text = "FunktionsSelektor";
            this.kontrollPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel funktionsPanel;
        private System.Windows.Forms.Panel kontrollPanel;
        private System.Windows.Forms.Button btnWeiter;
        private System.Windows.Forms.Button btnBeenden;
    }
}