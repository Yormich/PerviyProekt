using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PerviyProekt
{
    class NetResponse
    {
        private Stream stream;

        public void WebResponse(string date)
        {
            string URI = "https://bank.gov.ua/NBU_Exchange/exchange?date="+date;
            WebRequest request = WebRequest.Create(URI);
            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();

            response.Close();
        }
    }
}
