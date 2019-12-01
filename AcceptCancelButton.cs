using System;
using System.Windows.Forms;

namespace FormsTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Button cancel = new Button();
            cancel.Click += (o, args) => this.Close();

            this.AcceptButton = submitButton;
            this.CancelButton = cancel;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked.");
        }
    }
}
