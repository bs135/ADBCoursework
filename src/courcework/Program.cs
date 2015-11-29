using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace courcework

{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>v cvc z 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Nhapttsv());
        }
    }
}
