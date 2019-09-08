using System;
using System.Drawing;
using System.Windows.Forms;
using MVP.Views;

namespace PassiveMVP
{
    public partial class MainForm : Form, IMainView
    {
        public event EventHandler FileNameChanged;
        public event EventHandler EditorTextChanged;
        public event EventHandler LoadRequested;
        public event EventHandler SaveRequested;

        public MainForm()
        {
            InitializeComponent();
        }

        public string FileName
        {
            get => fileNameTextBox.Text;
            set => fileNameTextBox.Text = value;
        }

        public bool FileNameIsValid
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
            LoadRequested?.Invoke(this, EventArgs.Empty);
        }

        public string EditorText
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveRequested?.Invoke(this, EventArgs.Empty);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            EditorTextChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}