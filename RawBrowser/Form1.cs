namespace RawBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {

                    HttpResponseMessage hrm = httpClient.GetAsync(textBox1.Text).Result;

                    textBox2.Text = "Headers:";
                    textBox2.AppendText(Environment.NewLine);

                    for (int i = 0; i < hrm.Headers.Count(); i++)
                    {
                        textBox2.AppendText(hrm.Headers.ElementAt(i).Key + " ");

                        for (int j = 0; j < hrm.Headers.ElementAt(i).Value.Count(); j++)
                            textBox2.AppendText(hrm.Headers.ElementAt(i).Value.ElementAt(j) + " ");

                        textBox2.AppendText(Environment.NewLine);
                    }

                    textBox2.AppendText(Environment.NewLine);
                    textBox2.AppendText(Environment.NewLine);
                    textBox2.AppendText("Content Headers:");
                    textBox2.AppendText(Environment.NewLine);

                    for (int i = 0; i < hrm.Content.Headers.Count(); i++)
                    {
                        textBox2.AppendText(hrm.Content.Headers.ElementAt(i).Key + " ");

                        for (int j = 0; j < hrm.Content.Headers.ElementAt(i).Value.Count(); j++)
                            textBox2.AppendText(hrm.Content.Headers.ElementAt(i).Value.ElementAt(j) + " ");

                        textBox2.AppendText(Environment.NewLine);
                    }

                    textBox2.AppendText(Environment.NewLine);
                    textBox2.AppendText(Environment.NewLine);
                    textBox2.AppendText("Content:");
                    textBox2.AppendText(Environment.NewLine);

                    textBox2.AppendText(Environment.NewLine);
                    textBox2.AppendText(Environment.NewLine);
                    textBox2.AppendText(hrm.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                button1_Click(sender, e);
            }
        }
    }
}