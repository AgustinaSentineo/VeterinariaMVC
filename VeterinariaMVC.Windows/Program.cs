using System;
using System.Windows.Forms;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DI.Inicialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(DI.Create<frmMenuPrincipal>());
        }
    }
}
