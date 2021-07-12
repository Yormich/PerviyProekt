using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PerviyProekt
{
    class UserStorage
    {
        public const string path = "Users.xml";
        public string GetPath()
        {
            return path;
        }
        public void CreateXMLDocument(string filepath)
        {
            XmlTextWriter xtw = new XmlTextWriter(filepath, Encoding.UTF32);
            xtw.WriteStartDocument();
            xtw.WriteStartElement("Users");
            xtw.WriteEndDocument();
            xtw.Close();
        }

        public void AddToDocument(string filepath,User us)
        {
            
            if (!File.Exists(path)) CreateXMLDocument(path);
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);

            XmlElement user = xd.CreateElement("user");

            XmlElement login = xd.CreateElement("login");
            XmlElement pass = xd.CreateElement("password");
            XmlElement typeofuser = xd.CreateElement("typeofuser");

            XmlText tLogin = xd.CreateTextNode(us.Login);
            XmlText tPassword = xd.CreateTextNode(us.PassWord);
            XmlText tTypeOfUser = xd.CreateTextNode(us.TypeOfUser);

            login.AppendChild(tLogin);
            pass.AppendChild(tPassword);
            typeofuser.AppendChild(tTypeOfUser);

            user.AppendChild(login);
            user.AppendChild(pass);
            user.AppendChild(typeofuser);

            xd.DocumentElement.AppendChild(user);

            fs.Close();
            xd.Save(filepath);
        }
        public bool ReadDocument(string filepath, string Login , string Password)
        {
            string login, password;
            bool Check = false;
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);
            XmlNodeList list = xd.GetElementsByTagName("user");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement user = (XmlElement)xd.GetElementsByTagName("login")[i];
                XmlElement pass = (XmlElement)xd.GetElementsByTagName("password")[i];
                login = user.InnerText;
                password = pass.InnerText;
                if ((Login == login) && (Password == password))
                {
                    Check = true;
                }
            }
            fs.Close();
            return Check;
        }
    }
}
