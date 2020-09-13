public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox();

            textBox.Location = Location;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.ForeColor = Color.Purple;
            textBox.BackColor = Color.AliceBlue;

            this.Controls.Add(textBox);
        }
    }
