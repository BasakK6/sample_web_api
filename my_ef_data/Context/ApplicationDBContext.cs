using System;
using Microsoft.EntityFrameworkCore;
using my_ef_data.Models;

namespace my_ef_data.Context
{
	public class ApplicationDbContext : DbContext //extends from EntityFramework DBContext, 
	{
        //constructors
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //when we sent the options to base it marks the IsConfigured as true
        {
        }

        public ApplicationDbContext() //no configuration given
        {
        }

        //configurations 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) //when there is no configuration (no param constructor is used)
            {
                //string connectionString = "Server=localhost;Database=TestEmployeesDB;User Id=SA;Password=reallyStrongPwd123;";
                string connectionString = "Data Source=localhost;Initial Catalog=EFCoreDB;Persist Security Info=True;User ID=SA;Password=reallyStrongPwd123;TrustServerCertificate=true";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        //Database Table
        public DbSet<Person> People { get; set; }


        //Object-DB Table mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            //DB Table settings
            modelBuilder.Entity<Person>(entity => {
                //Table name
                entity.ToTable("People");

                //Columns
                entity.Property(i => i.Id).HasColumnType("int").UseIdentityColumn().IsRequired();  //we can change the name with HasColumnName()
                entity.Property(i => i.Vorname).HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.Nachname).HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.Lieblingsfarbe).HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.Geburtsdatum);

            });

            base.OnModelCreating(modelBuilder);
        }

    }
}

