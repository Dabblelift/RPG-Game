using Microsoft.EntityFrameworkCore;
using RPG_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=RPG-Game;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archer>();
            modelBuilder.Entity<Mage>();
            modelBuilder.Entity<Warrior>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
