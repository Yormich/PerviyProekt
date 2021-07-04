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
    class DataRetriever 
    {
        private XmlDocument XDoc;
        public DataRetriever(Stream stream)
        {
            XDoc.Load(stream);
        }

       public void Parse()
        {
            XmlElement XRoot = XDoc.DocumentElement;
            foreach(XmlNode Node in XRoot)
            {
                int CurrencyCode = int.Parse(Node["CurrencyCode"].Value);
                string CurrencyCodeL = Node["CurrencyCodeL"].Value;
                int Units = int.Parse(Node["Units"].Value);
                double Amount = double.Parse(Node["Amount"].Value);
                new Currency(CurrencyCode, CurrencyCodeL, Units, Amount);
            }

        }
    }
}
