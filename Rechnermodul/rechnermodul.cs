using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Reflection;
using RechnermodulBibliothek;

namespace Rechnermodul
{
    public partial class rechnermodul : Form
    {
        private static string APP_PATH = Path.GetDirectoryName(Application.ExecutablePath);
        private RechnermodulBibliothek.AbstractModule[] modules;
        private static string MODULE_CONFIG_PATH = APP_PATH + "/../../MeineModule.txt";

        public rechnermodul()
        {
            InitializeComponent();
        }

        private string[] getModulPaths()
        {
            string[] paths = File.ReadAllLines(MODULE_CONFIG_PATH);

            for (int i=0; i<paths.Length; i++)
            {
                paths[i] = APP_PATH + "/" + paths[i];
            }

            return paths;
        }

        private RechnermodulBibliothek.AbstractModule[] loadModules(string[] modulePaths)
        {
            List<RechnermodulBibliothek.AbstractModule> modules = new List<RechnermodulBibliothek.AbstractModule>();

            foreach (string dllPath in modulePaths)
            {
                if (!File.Exists(dllPath))
                {
                    Console.Write("Could not load file " + dllPath);

                    continue;
                }

                var DLL = Assembly.LoadFile(dllPath);
                foreach (Type type in DLL.GetExportedTypes())
                {

                    RechnermodulBibliothek.AbstractModule modul = Activator.CreateInstance(type) as RechnermodulBibliothek.AbstractModule;

                    if (modul != null)
                    {
                        modules.Add(modul);
                    }
                }
            }

            modules.Add(new GrundrechenModul());

            return modules.ToArray<RechnermodulBibliothek.AbstractModule>();
        }

        private void rechnermodul_Load(object sender, EventArgs e)
        {
            int y = 0;

            Console.Write(APP_PATH + "\n");

            this.modules = this.loadModules(this.getModulPaths());

            foreach (AbstractModule modul in this.modules)
            {
                Button btn_m = new Button();
                btn_m.Text = modul.name;
                btn_m.Width = 100;
                btn_m.Top = y;
                btn_m.Show();
                btn_m.Click += (s, ea) => { modul.run(); };
                y += 30;

                panelModule.Controls.Add(btn_m);

            } 
        }
       
    }
}
