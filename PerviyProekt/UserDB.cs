﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace PerviyProekt
{
    class UserDB : DbContext
    {
        public UserDB() : base("DefaultConnection")
        {
           
        }
        public DbSet<User> Users { get; set; }

       
    }
}
