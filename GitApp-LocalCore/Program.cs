using System;
using System.Windows.Forms;
using GitAppLocalCore.Forms;

namespace GitAppLocalCore
{
    static class Program
    {
        /// <summary>
        /// Credit to Ola Palholmen, Knowit SysDev
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GlobalSettingsForm());
            Application.Run(new MainForm());
        }
    }
}