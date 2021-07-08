using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace PerviyProekt
{
    class Storage : DbContext
    {
        public Storage() : base("DefaultConnection")
        {
           
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Currency> Currencies { get; set; }
    }
}
