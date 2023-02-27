using Microsoft.EntityFrameworkCore;
using SmartAgency._1_Core.Data.Converters;
using SmartAgency._1_Core.Data.Entities.PropertyEntity;
using SmartAgency._1_Core.Data.Entities.UserEntity.ClientEntity;
using System.ComponentModel;
using DateOnlyConverter = SmartAgency._1_Core.Data.Converters.DateOnlyConverter;

namespace SmartAgency._1_Core.Data;

public class SmartAgencyAppDbContextInMemory : DbContext
{
    //public DbSet<Property> Properties => Set<Property>();
    public DbSet<Client> Clients => Set<Client>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        
        modelBuilder.Entity<Property>().OwnsOne(x => x.Localisation);
        modelBuilder.Entity<Client>().OwnsOne(x => x.Email);
        modelBuilder.Entity<Client>().OwnsOne(x => x.FirstName);
        modelBuilder.Entity<Client>().OwnsOne(x => x.LastName);

        //modelBuilder.Entity<Client>().Ignore(x => x.DateAdded);

        modelBuilder.Entity<Client>().Property(x => x.DateAdded).HasConversion<DateTime>();

        modelBuilder.Entity<Client>(builder =>
        {
            builder.Property(x => x.DateAdded)
                .HasConversion<DateOnlyConverter, DateOnlyComparer>();
        });

        base.OnModelCreating(modelBuilder);
    }
}