using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PerviyProekt
{
    class DataRetriever 
    {
        private XmlDocument XDoc { get; set; }
        private Stream stream { get; set; }
        public DataRetriever(Stream stream)
        {
            this.stream = stream;
            XDoc.Load(stream);
        }

        public void Parse(string date,Storage bd)
        {
            XmlElement XRoot = XDoc.DocumentElement;
            foreach(XmlNode Node in XRoot)
            {
                int CurrencyCode = int.Parse(Node["CurrencyCode"].Value);
                string CurrencyCodeL = Node["CurrencyCodeL"].Value;
                int Units = int.Parse(Node["Units"].Value);
                double Amount = double.Parse(Node["Amount"].Value);
                Currency currency = new Currency(date, CurrencyCode, CurrencyCodeL, Units, Amount);
                bd.Currencies.Add(currency);
            }

        }
    }
}
