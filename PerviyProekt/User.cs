using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  

namespace PerviyProekt
{
   
    class User
    {
     
        private int ID { get; set; }
        public string Login { get; set; }
        
        public string PassWord { get; set; }

        public string TypeOfUser { get; set; }

        public User(string login, string passWord, string typeOfUser)
        {
            Login = login;
            PassWord = passWord;
            TypeOfUser = typeOfUser;
        }
       
    }
}
