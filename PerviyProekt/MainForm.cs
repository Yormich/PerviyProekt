using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerviyProekt
{
    public partial class MainForm : Form
    {
        DataRetriever DR;
        public MainForm()
        {
            DateTime time = DateTime.Today;
            string date = time.ToShortDateString();
            Stream stream = null;
            WebResponse(date, stream);
            DR = new DataRetriever(stream);
            DR.Parse(date);
            InitializeComponent();
        }

        private void WebResponse(string date,Stream stream)
        {
            string URI = "https://bank.gov.ua/NBU_Exchange/exchange?date=" + date;
            WebRequest request = WebRequest.Create(URI);
            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();

            response.Close();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PropertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void DataAndCurrTypeButton_Click(object sender, EventArgs e)
        {
            
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GraphButton_Click(object sender, EventArgs e)
        {

        }
    }
}
