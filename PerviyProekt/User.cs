using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerviyProekt
{
    class User
    {
        public string Login { get; private set; }
        public string PassWord { get; private set; }

        public User(string Login , string PassWord)
        {
            this.Login = Login;
            this.PassWord = PassWord;
        }

    }
}
