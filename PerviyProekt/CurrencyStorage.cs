using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PerviyProekt
{
    class CurrencyStorage
    {
        public const string path = "Currencies.xml";
        public string GetPath()
        {
            return path;
        }

        public void CreateXMLDocument(string filepath)
        {
            XmlTextWriter xtw = new XmlTextWriter(filepath, Encoding.UTF32);
            xtw.WriteStartDocument();
            xtw.WriteStartElement("Currencies");
            xtw.WriteEndDocument();
            xtw.Close();
        }

        public void AddToDocument(string filepath, Currency currency)
        {

            if (!File.Exists(path)) CreateXMLDocument(path);
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);

            XmlElement curr = xd.CreateElement("Currency");

            XmlElement StartDate = xd.CreateElement("StartDate");
            XmlElement CurrencyCode = xd.CreateElement("CurrencyCode");
            XmlElement CurrencyCodeL = xd.CreateElement("CurrencyCodeL");
            XmlElement Units = xd.CreateElement("Units");
            XmlElement Amount = xd.CreateElement("Amount");

            XmlText startdate = xd.CreateTextNode(currency.StartDate);
            XmlText currencyCode = xd.CreateTextNode(Convert.ToString(currency.CurrencyCode));
            XmlText currencyCodeL = xd.CreateTextNode(currency.CurrencyCodeL);
            XmlText units = xd.CreateTextNode(Convert.ToString(currency.Units));
            XmlText amount = xd.CreateTextNode(Convert.ToString(currency.Amount));

            StartDate.AppendChild(startdate);
            CurrencyCode.AppendChild(currencyCode);
            CurrencyCodeL.AppendChild(currencyCodeL);
            Units.AppendChild(units);
            Amount.AppendChild(amount);

            curr.AppendChild(StartDate);
            curr.AppendChild(CurrencyCode);
            curr.AppendChild(CurrencyCodeL);
            curr.AppendChild(Units);
            curr.AppendChild(Amount);

            xd.DocumentElement.AppendChild(curr);

            fs.Close();
            xd.Save(filepath);
        }

        public bool ReadDocument(string filepath, string Date)
        {
            string d;
            bool Check = false;
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);
            XmlNodeList list = xd.GetElementsByTagName("Currency");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement date = (XmlElement)xd.GetElementsByTagName("StartDate")[i];
                d = date.InnerText;
                if (Date==d)
                {
                    Check = true;
                }
            }
            fs.Close();
            return Check;
        }
    }
}

