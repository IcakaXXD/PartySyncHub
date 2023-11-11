using Bisness_Layer;
using Business_Layer;
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
            modelBuilder.Entity<PartySession>()
                .HasMany(ps => ps.NotAprovedSongs)
                .WithMany(s => s.PartySessions)
                .UsingEntity<SongPartySession>(
                s=>s.HasOne<Song>(o=>o.Song).WithMany(o=>o.SongPartySessions),
                ps=>ps.HasOne<PartySession>(o=>o.PartySession).WithMany(o=>o.SongPartySessions)
                );

            modelBuilder.Entity<PartySession>()
                .HasMany(ps => ps.AcceptedSongs)
                .WithMany(s => s.PartySessions)
                .UsingEntity<SongPartySession>(
                s=>s.HasOne<Song>(o => o.Song).WithMany(o=>o.SongPartySessions),
                ps => ps.HasOne<PartySession>(o => o.PartySession).WithMany(o => o.SongPartySessions)
                );
              

            modelBuilder.Entity<PartySession>()
                .HasMany(ps => ps.Users)
                .WithMany(u=>u.PartySessions)
                .UsingEntity<UserPartySession>(
                u=> u.HasOne<User>(o=>o.User).WithMany(o=>o.UserPartySessions),
                ps=>ps.HasOne<PartySession>(o=>o.PartySession).WithMany(o=>o.UserPartySessions));
            //още не знам как да кажа на SQL сървъра, че двата листа Song са външни ключoве към една и съща таблица, но ще търся още🤔🤔
            base.OnModelCreating(modelBuilder);
        }
            
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }  
        public DbSet<PartySession> PartySessions { get; set; }
        public DbSet <Location> Locations { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<UserPartySession> UserPartySessions { get; set; }
        public DbSet<SongPartySession> SongPartySessions { get; set;}
}
}