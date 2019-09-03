using System;
using System.Windows.Forms;

namespace GestionFichiersEleves
{
    static class Program
    {
        public const char Separateur = ';';

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
