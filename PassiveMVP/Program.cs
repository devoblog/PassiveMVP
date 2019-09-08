using System;
using System.Windows.Forms;
using MVP.Models;
using MVP.Presenters;

namespace PassiveMVP
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

            IDataStore dataStore = new DataStore(new FileSystemWrapper());
            MainForm mainForm = new MainForm();
            new MainPresenter(mainForm, dataStore);

            Application.Run(mainForm);
        }
    }
}