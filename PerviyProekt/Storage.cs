﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace PerviyProekt
{
    class Storage : DbContext
    {
        public Storage()
        {
           
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Currency> Currencies { get; set; }
    }
}
