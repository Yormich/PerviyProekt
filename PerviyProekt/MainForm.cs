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
using System.Xml;
using LiveCharts.Wpf;
using LiveCharts;

namespace PerviyProekt
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DateTime today = DateTime.Today;
            string date = today.ToShortDateString();
            DateTextBox.Text = date;
            string response = WebResponse(date);
            LoadCurrencies(date,response);
        }

        public string WebResponse(string date)
        {
            string URI = "https://bank.gov.ua/NBU_Exchange/exchange?date=" + date;
            WebRequest request = WebRequest.Create(URI);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string responseFromServer = reader.ReadToEnd();           
            response.Close();
            return responseFromServer;
        }

        public void LoadCurrencies(string date, string response)
        {
                  
            XmlDocument xDoc= new XmlDocument();
            xDoc.LoadXml(response);
            Parse(xDoc, date);
        }

        public void Parse(XmlDocument xDoc,string date)
        {
            XmlElement xRoot = xDoc.DocumentElement;
            int it = 0;
            foreach(XmlNode childNode in xRoot)
            {
                string StartDate = date;
                int CurrencyCode = Convert.ToInt32(xDoc.GetElementsByTagName("CurrencyCode")[it].InnerText);
                string CurrencyCodeL = xDoc.GetElementsByTagName("CurrencyCodeL")[it].InnerText;
                int Units = Convert.ToInt32(xDoc.GetElementsByTagName("Units")[it].InnerText);
                double Amount =Convert.ToDouble((xDoc.GetElementsByTagName("Amount")[it].InnerText).Replace(".",","));
                Currency currency = new Currency(StartDate,CurrencyCode, CurrencyCodeL, Units, Amount);
                CurrencyList.Items.Add(currency);
                it++;
            }    
        }

        public double ParseForGraph(XmlDocument xDoc,string currencyCode)
        {
            XmlElement xRoot = xDoc.DocumentElement;
            int it = 0;
            double amount=0;
            foreach (XmlNode childNode in xRoot)
            {
                if(currencyCode == xDoc.GetElementsByTagName("CurrencyCodeL")[it].InnerText)
                {
                    double am = Convert.ToDouble((xDoc.GetElementsByTagName("Amount")[it].InnerText).Replace(".", ","));
                    int Units = Convert.ToInt32(xDoc.GetElementsByTagName("Units")[it].InnerText);
                    amount = am / Units;
                }              
                it++;
            }            
            return amount;
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
            if(Convert.ToDateTime(DateTextBox.Text)>DateTime.Today)
            {
                MessageBox.Show("Введённая дата превышает сегодняшнюю дату.");
            }
            else
            {
                string response = WebResponse(DateTextBox.Text);
                CurrencyList.Items.Clear();
                LoadCurrencies(DateTextBox.Text,response);
            }
            
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GraphButton_Click(object sender, EventArgs e)
        {
            if (GraphTextBox.TextLength > 3 || GraphTextBox.TextLength < 3)
            {
                MessageBox.Show("Неправильная длина наименования валюты.");
            }
            else
            {
                DateTime FinDate = DateTime.Today;
                DateTime startDate = FinDate.AddYears(-10);
                string CurrencyCode = GraphTextBox.Text;
                SeriesCollection series = new SeriesCollection();
                ChartValues<double> currencies = new ChartValues<double>();
                List<string> dates = new List<string>();
                double max=0;
                double min = 1000;
                while(startDate <= FinDate)
                {
                    string Date = startDate.ToShortDateString();
                    string response = WebResponse(Date);
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.LoadXml(response);
                    double amount=0;
                    if(amount != ParseForGraph(xDoc,CurrencyCode))
                    {
                        amount = ParseForGraph(xDoc, CurrencyCode);
                        currencies.Add(amount);
                        dates.Add(Date);
                       startDate = startDate.AddYears(1);
                    }
                    else
                    {
                        MessageBox.Show("Ввёдённая вами валюта некорректна.");
                        break;
                    }
                }
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisX.Add(new Axis()
                {
                    Title = "Даты",
                    Labels = dates
                });
                LineSeries line = new LineSeries();
                line.Title = GraphTextBox.Text;
                line.Values = currencies;
                series.Add(line);
                cartesianChart1.Series = series;
                cartesianChart1.LegendLocation = LegendLocation.Bottom;
                foreach(double x in currencies)
                {
                    if(x>max)
                    {
                        max = x;
                    }    
                    else if(x<min)
                    {
                        min = x;
                    }
                }    
                label3.Text = "Минимум: " + Convert.ToString(Math.Round(min,3));
                label4.Text ="Максимум: " + Convert.ToString(Math.Round(max,3));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CurrencyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CurrencyList.SelectedIndex!=-1)
            {
                propertyGrid1.SelectedObject = CurrencyList.SelectedItem;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
