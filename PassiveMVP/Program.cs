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
            
            ITextEditorModel textEditorModel = new TextEditorModel();
            IFilePathModel filePathModel = new FilePathModel();
            IFileLoadModel fileLoadModel = new FileLoadModel(textEditorModel, filePathModel);
            IFileSaveModel fileSaveModel = new FileSaveModel(textEditorModel, filePathModel);

            MainForm mainForm = new MainForm();

            new FileLoadPresenter(mainForm, fileLoadModel);
            new TextEditorPresenter(mainForm, textEditorModel);
            new FileSavePresenter(mainForm, fileSaveModel);
            new FilePathPresenter(mainForm, filePathModel);

            Application.Run(mainForm);
        }
    }
}
