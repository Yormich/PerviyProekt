using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace PerviyProekt
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(dataStream);
            XmlElement XRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in XRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode Attribute = xnode.Attributes.GetNamedItem("ROW");
                }

                foreach (XmlNode child in xnode.ChildNodes)
                {
                    Console.WriteLine(child.Name);
                }
            }
        }
        class Currency
        {
            public int CurrencyCode { get; private set; }
            public string CurrencyCodeL { get; private set; }
            public int Units { get; private set; }
            public double Amount { get; private set; }

            public Currency(int CurrencyCode, string CurrencyCodeL, int Units, double Amount)
            {
                this.CurrencyCode = CurrencyCode;
                this.CurrencyCodeL = CurrencyCodeL;
                this.Units = Units;
                this.Amount = Amount;
            }
        }

        class DataRetriever
        {
            public XmlDocument Doc;

            public DataRetriever(Stream stream)
            {
                Doc.Load(stream);
            }

            
        }
    }
}
