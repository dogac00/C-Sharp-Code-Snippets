public partial class Form1 : Form
    {
        private Font _arial = new Font("Arial", 12);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                this.Controls.Add(new Label
                {
                    Location = new Point(0, i * 25),
                    Name = $"Label{i}",
                    Font = _arial,
                    Text = $"Label{i}"
                });
            }
        }
    }
