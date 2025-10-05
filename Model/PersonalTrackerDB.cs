using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Trackeer.Model
{
    class PersonalTrackerDB : DbContext
    {
        public PersonalTrackerDB() { }
        public PersonalTrackerDB(DbContextOptions<PersonalTrackerDB> options) : base(options) { }
        
        public DbSet<Users> Users { get; set; }
        public DbSet <Visa> Visa { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2008HFE\\SQLEXPRESS;Initial Catalog=PersonalTrackerDB;Integrated Security=True;Trust Server Certificate=True");
            }
        }
            
    }
}
