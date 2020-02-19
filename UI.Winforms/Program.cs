using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic.MVP.Models;
using Logic.MVP.Presenters;

namespace UI.Winforms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainTerminal = new Forms.MainTerminal();
            /* Create new presenter to handle logic */
            _ = new SerialPresenter(mainTerminal, new SerialModel());
            Application.Run(mainTerminal);
        }
    }
}
