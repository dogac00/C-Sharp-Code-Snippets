using System;
using System.Windows.Forms;

namespace FormsTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "")
            {
                MessageBox.Show("Name is empty.");
                nameTextBox.Focus();
                return;
            }

            if (numberTextBox.Text == "")
            {
                MessageBox.Show("Number is empty.");
                numberTextBox.Focus();
                return;
            }

            int number;

            if (!int.TryParse(numberTextBox.Text, out number))
            {
                MessageBox.Show("Number entry is not a number.");
                numberTextBox.Focus();
                return;
            }

            Student student = new Student(nameTextBox.Text, number);

            MessageBox.Show($"Student: {student}");
        }
    }

    class Student
    {
        public string Name { get; }
        public int Number { get; }

        public Student(string name, int number)
        {
            Name = name;
            Number = number;
        }

        public override string ToString()
        {
            return $"Name : {this.Name}, Number : {this.Number}";
        }
    }
}
