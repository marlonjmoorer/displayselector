using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisplaySelector
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew = true;
            using (Mutex mutex = new Mutex(true, "Display Selector App", out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    try
                    {
                        Application.Run(new MainForm());
                    }
                    catch (Exception)
                    {
                        Application.Exit();
                    }
                   
                    
                }
                else
                {
                    MessageBox.Show("The Application Is Already Running", "Display Selector App", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
