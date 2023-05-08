using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BusinessLayer;

namespace DataLayer
{
    public partial class RecyclingmachineDbContext : DbContext
    {
        string Sql_ConnectionLink = "dsasda"; //connection link
        public RecyclingmachineDbContext()
        {
        }

        public RecyclingmachineDbContext(DbContextOptions<RecyclingmachineDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Sql_ConnectionLink);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()

            base.OnModelCreating(modelBuilder);

        }
        public virtual DbSet<Bottle> Bottles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
        

        
    

}
