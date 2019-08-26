using System;
using System.Windows.Forms;
using MVP.Views;

namespace PassiveMVP
{
    public partial class MainForm : Form, IFileLoadView
    {
        public event EventHandler FileNameChanged;
        public event EventHandler LoadFile;

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
            set => loadButton.Enabled = value;
        }

        private void FileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            FileNameChanged?.Invoke(this, EventArgs.Empty);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadFile?.Invoke(this, EventArgs.Empty);
        }
    }
}