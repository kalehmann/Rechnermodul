using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RechnermodulBibliothek
{
    public partial class FunktionsSelektor : Form
    {


        private AbstractFunction function;

        public FunktionsSelektor()
        {
            InitializeComponent();
        }

        public AbstractFunction selected_function
        {
            get { return this.function;  }
        }

        public void set_funktionen(AbstractModule modul)
        {
            int y = 0;

            foreach (AbstractFunction f in modul.functions)
            {
                Button btn_function = new Button();
                btn_function.Text = f.getName();
                btn_function.Width = 150;
                btn_function.Top = y;
                btn_function.Show();
                btn_function.Click += (s, e) =>
                {
                    this.function = f;
                    this.Close();
                };
                y += 20;

                funktionsPanel.Controls.Add(btn_function);
            }

            funktionsPanel.Height += y;
            kontrollPanel.Top += y;
            this.Height += y;
        }

        private void btn_beenden_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
