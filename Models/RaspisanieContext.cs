using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace laba1_Raspisanie_zanyatiy_.Models
{
    public class RaspisanieContext : DbContext
    {

        public DbSet<Lesson> Lessons { get; set; }
        public RaspisanieContext() : base("RaspisanieEntity")
        { }



    }
}