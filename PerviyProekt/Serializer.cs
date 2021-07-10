using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PerviyProekt
{
    class Serializer
    {
        public void Serialize(User user)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(User));

            using (FileStream fileStream = new FileStream("Users.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, user);
                fileStream.Close();
            }
        }

        public Serializer(Currency currency)
        {

        }

        public Serializer()
        {
        }
    }
}
