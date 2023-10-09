using Bisness_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            //modelBuilder.Entity<PartySession>()
            //    .HasMany(ps => ps.NotAprovedSongs)
            //    .WithMany()
            //    .HasForeignKey(s => s.PartySessionId);

            //modelBuilder.Entity<PartySession>()
            //    .HasMany(ps => ps.AcceptedSongs)
            //    .WithMany()
            //    .HasForeignKey(s => s.PartySessionId);
            //още не знам как да кажа на SQL сървъра, че двата листа Song са външни ключoве към една и съща таблица, но ще търся още🤔🤔
            base.OnModelCreating(modelBuilder);
        }
            
        public DbSet<Admin> Admins { get; set; }
        public DbSet <DJ> DJs { get; set; }
        public DbSet<PartySession> PartySessions { get; set; }
        public DbSet <Location> Locations { get; set; }
        public DbSet<Member>  Members{ get; set; }        
        public DbSet<Song> Songs { get; set; }
}
}