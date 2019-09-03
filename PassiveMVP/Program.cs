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

            MainForm mainForm = new MainForm();
            ITextEditorModel textEditorModel = new TextEditorModel();
            IFileLoadModel fileLoadModel = new FileLoadModel(textEditorModel);
            new FileLoadPresenter(mainForm, fileLoadModel);
            new TextEditorPresenter(mainForm, textEditorModel);

            Application.Run(mainForm);
        }
    }
}
