using System;
using System.Windows.Forms;

/// <summary>
/// Author: Kristopher Randle
/// Version: 0.1, 02-12-21
/// </summary>
namespace Main
{
    /// <summary>
    /// Program is the main entry point for the application.
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // CREATE a new Controller, call it controller:
            Controller controller = new Controller();
        }
    }
}
