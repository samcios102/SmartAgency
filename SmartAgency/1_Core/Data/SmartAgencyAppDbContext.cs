using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using SmartAgency._1_Core.Data.Converters;
using SmartAgency._1_Core.Data.Entities.PropertyEntity;
using SmartAgency._1_Core.Data.Entities.UserEntity.ClientEntity;
using DateOnlyConverter = SmartAgency._1_Core.Data.Converters.DateOnlyConverter;

namespace SmartAgency._1_Core.Data;

public class SmartAgencyAppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
   
    public SmartAgencyAppDbContext(DbContextOptions<SmartAgencyAppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().OwnsOne(x => x.Email);
        modelBuilder.Entity<Client>().OwnsOne(x => x.FirstName);
        modelBuilder.Entity<Client>().OwnsOne(x => x.LastName);
        modelBuilder.Entity<Client>().Property(x => x.DateAdded).HasConversion<DateOnlyConverter, DateOnlyComparer>();

        base.OnModelCreating(modelBuilder);
    }
}