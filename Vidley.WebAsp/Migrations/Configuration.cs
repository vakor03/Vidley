
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Vidley.WebAsp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Vidley.WebAsp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}