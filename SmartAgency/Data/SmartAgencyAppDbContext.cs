using Microsoft.EntityFrameworkCore;
using SmartAgency.Data.Entities.ContractEntity;
using SmartAgency.Data.Entities.PropertyEntity;
using SmartAgency.Data.Entities.UserEntity.AgentEntity;
using SmartAgency.Data.Entities.UserEntity.ClientEntity;
using System.Diagnostics.Contracts;
using SmartAgency.Data.Entities.ValueObjects;
using SmartAgency.Data.ValueConverters;

namespace SmartAgency.Data;

public class SmartAgencyAppDbContext : DbContext
{
    //public DbSet<Client> Clients => Set<Client>();
    //public DbSet<Agent> Agents => Set<Agent>();
    //public DbSet<SellContract> SellContracts => Set<SellContract>();
    public DbSet<Property> Properties => Set<Property>();
    public DbSet<Client> Clients => Set<Client>();
    //public DbSet<Localisation> Localisations => Set<Localisation>();


    /*public SmartAgencyAppDbContext(DbContextOptions<SmartAgencyAppDbContext> options)
        :base(options)
    {

    }*/

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //ta klasa nie dziedziczy po niczym, wie nie trzeba
    {
        //modelBuilder.Entity<Property>();


        /*foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var propertyInfo in entityType.ClrType.GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(Localisation))
                {
                    foreach (var property in propertyInfo.)
                    {
                        
                    }




                    entityType.AddProperty(propertyInfo)
                        .SetValueConverter(typeof(LocalisationConverter));
                }             
            }
        }*/


        /*modelBuilder.Entity<Property>().Property(x => x.Localisation).HasConversion(
            v => string.Join(", ", v),
            v => new Localisation(v.Split(',', StringSplitOptions.TrimEntries).ToArray())
            )*/


        /*modelBuilder
            .Entity<Property>()
            .Property(e => e.Localisation)
            .HasConversion(
                v => v.ToString(),
                v => 
                    (Localisation) new Localisation(v.Split(',', StringSplitOptions.TrimEntries).Select())
            )*/

        /// dziala jesli ten dolny sie usunie, bo jak sa dwa na raz to cos sie pierdoli, ale to naprawiaja podobno
        /*modelBuilder.Entity<Property>().OwnsOne(x => x.Localisation);*/

        modelBuilder.Entity<Property>().OwnsOne(x => x.Localisation);
        modelBuilder.Entity<Client>().OwnsOne(x => x.Email);
        modelBuilder.Entity<Client>().OwnsOne(x => x.FirstName);
        modelBuilder.Entity<Client>().OwnsOne(x => x.LastName);


        base.OnModelCreating(modelBuilder);
    }

    // nie jest potrzebne wraz z klasa localisation converter
/*    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {

        //configurationBuilder.Properties<Localisation>().HaveConversion<LocalisationConverter>();
               

        base.ConfigureConventions(configurationBuilder);
    }*/
}