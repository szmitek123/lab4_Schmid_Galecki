#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab4_Schmid_Galecki.Models;

namespace lab4_Schmid_Galecki.Data
{
    public class lab4_Schmid_GaleckiContext : DbContext
    {
        public lab4_Schmid_GaleckiContext (DbContextOptions<lab4_Schmid_GaleckiContext> options)
            : base(options)
        {
        }

        public DbSet<lab4_Schmid_Galecki.Models.Game> Game { get; set; }
    }
}
