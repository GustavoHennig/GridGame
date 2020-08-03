using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GridGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Console.WriteLine(DateTime.Now.ToString("f"));
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
