using Bisness_Layer;
using Microsoft.EntityFrameworkCore;
using System;
namespace Data_Layer
{
    public class PartySyncHubDBContext:DbContext
    {
        public PartySyncHubDBContext()
        {
                
        }
        public PartySyncHubDBContext(DbContextOptions contextOptions): base(contextOptions) 
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NA-ICO-KOMPA-I-\\SQLEXPRESS;Database=PartySyncHubDB;Trusted_Connection=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DJsLocations>().HasKey(dl => new { dl.DJId, dl.LocationId });
            base.OnModelCreating(modelBuilder);
        }
    }
}