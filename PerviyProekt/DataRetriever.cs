﻿using System;
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
        private Stream stream;

        public void WebResponse(string date)
        {
            string URI = "https://bank.gov.ua/NBU_Exchange/exchange?date=" + date;
            WebRequest request = WebRequest.Create(URI);
            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();

            response.Close();
        }
        public DataRetriever(Stream stream)
        {
            this.stream = stream;
            XDoc.Load(this.stream);
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
