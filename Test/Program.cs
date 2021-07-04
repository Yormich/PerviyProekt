using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            String date = Console.ReadLine();
            string URI = "https://bank.gov.ua/NBU_Exchange/exchange?date=" + date;
            WebRequest request = WebRequest.Create(URI);
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            string responseFromServer;

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);

                responseFromServer = reader.ReadToEnd();

            }
            response.Close();
            XDocument document = XDocument.Parse(responseFromServer);

            XmlDocument xDoc = new XmlDocument();
            string Address = "E://CurrencyCourse.xml";
            xDoc.Load(Address);
            XmlElement XRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in XRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode Attribute = xnode.Attributes.GetNamedItem("ROW");

                }

                foreach (XmlNode child in xnode.ChildNodes)
                {
                    Console.WriteLine(child.SelectSingleNode("@StartDate").Value);
                    Console.WriteLine(child.SelectSingleNode("@CurrencyCode").Value);
                    Console.WriteLine(child.SelectSingleNode("@CurrencyCodeL").Value);
                    Console.WriteLine(child.SelectSingleNode("@Units").Value);
                    Console.WriteLine(child.SelectSingleNode("@Amount").Value);
                }
            }
        }
    }
}
