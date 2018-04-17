namespace Rechnermodul
{
    partial class rechnermodul
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_Ergebnis = new System.Windows.Forms.ListBox();
            this.panelModule = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lb_Ergebnis
            // 
            this.lb_Ergebnis.FormattingEnabled = true;
            this.lb_Ergebnis.Location = new System.Drawing.Point(141, 12);
            this.lb_Ergebnis.Name = "lb_Ergebnis";
            this.lb_Ergebnis.Size = new System.Drawing.Size(183, 264);
            this.lb_Ergebnis.TabIndex = 3;
            // 
            // panelModule
            // 
            this.panelModule.Location = new System.Drawing.Point(3, 9);
            this.panelModule.Name = "panelModule";
            this.panelModule.Size = new System.Drawing.Size(125, 266);
            this.panelModule.TabIndex = 4;
            // 
            // rechnermodul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 284);
            this.Controls.Add(this.panelModule);
            this.Controls.Add(this.lb_Ergebnis);
            this.Name = "rechnermodul";
            this.Text = "Startfenster";
            this.Load += new System.EventHandler(this.rechnermodul_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Module;
        private System.Windows.Forms.ListBox lb_Functions;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.ListBox lb_Ergebnis;
        private System.Windows.Forms.Panel panelModule;
    }
}

