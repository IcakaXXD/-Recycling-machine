using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BusinessLayer;

namespace DataLayer
{
    public partial class RecyclingmachineDbContext : DbContext
    {
        string Sql_ConnectionLink = "Server=DESKTOP-J5Q5EQD;Database=RecyclingNew;Trusted_Connection=True;"; //connection link
        public RecyclingmachineDbContext()
        {
        }

        public RecyclingmachineDbContext(DbContextOptions contextOptions)
            : base(contextOptions)
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
            modelBuilder.Entity<User>();

            base.OnModelCreating(modelBuilder);






            

        }





        public virtual DbSet<Bottle> Bottles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
        

        
    

}
