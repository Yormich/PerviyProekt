using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PerviyProekt
{
    class WorkWithCurrency
    {
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

        public List<Currency> Parse(XmlDocument xDoc, string date)
        {
            XmlElement xRoot = xDoc.DocumentElement;
            int it = 0;
            List<Currency> currencies = new List<Currency>();          
            foreach (XmlNode childNode in xRoot)
            {
                string StartDate = date;
                int CurrencyCode = Convert.ToInt32(xDoc.GetElementsByTagName("CurrencyCode")[it].InnerText);
                string CurrencyCodeL = xDoc.GetElementsByTagName("CurrencyCodeL")[it].InnerText;
                int Units = Convert.ToInt32(xDoc.GetElementsByTagName("Units")[it].InnerText);
                double Amount = Convert.ToDouble((xDoc.GetElementsByTagName("Amount")[it].InnerText).Replace(".", ","));
                Currency currency = new Currency(StartDate, CurrencyCode, CurrencyCodeL, Units, Amount);
                currencies.Add(currency);
                it++;
            }
            return currencies;
        }

        public double ParseForGraph(XmlDocument xDoc, string currencyCode)
        {
            XmlElement xRoot = xDoc.DocumentElement;
            int it = 0;
            double amount = 0;
            foreach (XmlNode childNode in xRoot)
            {
                if (currencyCode == xDoc.GetElementsByTagName("CurrencyCodeL")[it].InnerText)
                {
                    double am = Convert.ToDouble((xDoc.GetElementsByTagName("Amount")[it].InnerText).Replace(".", ","));
                    int Units = Convert.ToInt32(xDoc.GetElementsByTagName("Units")[it].InnerText);
                    amount = am / Units;
                }
                it++;
            }
            return amount;
        }
    }
}
