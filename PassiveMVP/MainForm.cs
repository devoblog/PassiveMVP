using System;
using System.Drawing;
using System.Windows.Forms;
using MVP.Views;

namespace PassiveMVP
{
    public partial class MainForm : Form, IFileLoadView, ITextEditorView, IFileSaveView, IFilePathView
    {
        public event EventHandler FileNameChanged;
        public event EventHandler LoadFile;

        public event EventHandler SaveFile;

        public MainForm()
        {
            InitializeComponent();
        }

        public string FileName
        {
            get => fileNameTextBox.Text;
            set => fileNameTextBox.Text = value;
        }

        public bool IsValid
        {
            set
            {
                loadButton.Enabled = value;
                fileNameTextBox.ForeColor = value ? Color.Black : Color.Red;
            }
        }

        private void FileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            FileNameChanged?.Invoke(this, EventArgs.Empty);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadFile?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler FileTextChanged;

        public string FileText
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFile?.Invoke(this, EventArgs.Empty);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            FileTextChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}