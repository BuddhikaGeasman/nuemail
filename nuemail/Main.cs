using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace nuemail
{
    static class Main
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TemplateChooser());
        }
    }
}
