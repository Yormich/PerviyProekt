using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            string URI = "https://bank.gov.ua/NBU_Exchange/exchange?date=01.07.2021";
            WebRequest request = WebRequest.Create(URI);
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            string responseFromServer

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);

                responseFromServer = reader.ReadToEnd();

            }
            response.Close();
            XDocument document = XDocument.Parse(responseFromServer);
            Console.WriteLine(document);
        }    
    }
}
