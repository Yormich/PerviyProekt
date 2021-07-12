using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PerviyProekt
{
    public class User
    {
        public string Login { get; set; }
        
        public string PassWord { get; set; }

        public string TypeOfUser { get; set; }

        public User()
        {

        }

        public User(string login, string passWord, string typeOfUser)
        {
            Login = login;
            PassWord = passWord;
            TypeOfUser = typeOfUser;
        }
       
    }
}
