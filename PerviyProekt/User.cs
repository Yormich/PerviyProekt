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
     
        public string Login { get; set; }
        
        public string PassWord { get; set; }

        public string TypeOfUser { get; set; }


       
    }
}
