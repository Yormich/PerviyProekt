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
        CurrencyStorage CS = new CurrencyStorage();
        WorkWithCurrency WWC = new WorkWithCurrency();
        public MainForm()
        {
            if (!File.Exists(CS.GetPath()))
            {
                CS.CreateXMLDocument(CS.GetPath());
            }
            InitializeComponent();
            DateTime today = DateTime.Today;
            string date = today.ToShortDateString();
            DateTextBox.Text = date;
            if(CS.ReadDocument(CS.GetPath(),date))
            {
                
                XmlDocument doc = new XmlDocument();
                doc.Load("Currencies.xml");
                List<Currency> currencies = WWC.Parse(doc, date);
                foreach (Currency c in currencies)
                {
                    
                    CurrencyList.Items.Add(c);
                }
            }
            else
            {
               string response =  WWC.WebResponse(date);
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(response);

                List<Currency> currencies = WWC.Parse(xDoc, date);
                foreach(Currency c in currencies)
                {
                    CS.AddToDocument(CS.GetPath(), c);
                    CurrencyList.Items.Add(c);
                }
            }
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
            if (!File.Exists(CS.GetPath()))
            {
                CS.CreateXMLDocument(CS.GetPath());
            }
        }

        private void PropertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void DataAndCurrTypeButton_Click(object sender, EventArgs e)
        {

            if (Convert.ToDateTime(DateTextBox.Text) > DateTime.Today)
            {
                MessageBox.Show("Введённая дата превышает сегодняшнюю дату.");
            }
            else if (Convert.ToDateTime(DateTextBox.Text) < DateTime.Today.AddYears(-26))
            {
                MessageBox.Show("Введённая вами дата слишком ранняя для отображения курса.");
            }    
            else
            {
                CurrencyList.Items.Clear();
                string date = DateTextBox.Text;
                if (CS.ReadDocument(CS.GetPath(), date))
                {

                    XmlDocument doc = new XmlDocument();
                    doc.Load("Currencies.xml");
                    List<Currency> currencies = WWC.Parse(doc, date);
                    foreach (Currency c in currencies)
                    {
                       
                        CurrencyList.Items.Add(c);
                    }
                }
                else
                {
                    string response = WWC.WebResponse(date);
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.LoadXml(response);

                    List<Currency> currencies = WWC.Parse(xDoc, date);
                    foreach (Currency c in currencies)
                    {
                        CS.AddToDocument(CS.GetPath(), c);
                        CurrencyList.Items.Add(c);
                    }
                }
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
            else if(Convert.ToDateTime(textBox2.Text)>= Convert.ToDateTime(textBox1.Text))
            {
                MessageBox.Show("Неправильный диапазон для графика.");
            }
            else
            {
                DateTime FinDate = Convert.ToDateTime(textBox1.Text);
                DateTime startDate = Convert.ToDateTime(textBox2.Text);
                string CurrencyCode = GraphTextBox.Text;
                SeriesCollection series = new SeriesCollection();
                ChartValues<double> currencies = new ChartValues<double>();
                List<string> dates = new List<string>();
                double max=0;
                double min = 1000;
                while(startDate <= FinDate)
                {
                    string Date = startDate.ToShortDateString();
                    double amount = 0;
                    if (CS.ReadDocument(CS.GetPath(), Date))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load("Currencies.xml");
                        if(amount!=WWC.ParseForGraph(doc,CurrencyCode))
                        {
                            amount = WWC.ParseForGraph(doc, CurrencyCode);
                            currencies.Add(amount);
                            dates.Add(Date);
                            startDate = startDate.AddDays(1);
                        }
                        else
                        {
                            MessageBox.Show("Ввёдённая вами валюта некорректна.");
                            break;
                        }
                    }
                    else
                    {
                        string response = WWC.WebResponse(Date);
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.LoadXml(response);

                        if (amount != WWC.ParseForGraph(xDoc, CurrencyCode))
                        {
                            amount = WWC.ParseForGraph(xDoc, CurrencyCode);
                            currencies.Add(amount);
                            dates.Add(Date);
                            startDate = startDate.AddDays(1);
                        }
                        else
                        {
                            MessageBox.Show("Ввёдённая вами валюта некорректна.");
                            break;
                        }
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
