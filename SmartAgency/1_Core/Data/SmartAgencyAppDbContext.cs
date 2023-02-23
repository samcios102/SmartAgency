using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using SmartAgency._1_Core.Data.Entities.PropertyEntity;
using SmartAgency._1_Core.Data.Entities.UserEntity.ClientEntity;
using DateOnlyConverter = SmartAgency._1_Core.Data.Converters.DateOnlyConverter;

namespace SmartAgency._1_Core.Data;

public class SmartAgencyAppDbContext : DbContext
{
    //public DbSet<UserBase> Clients => Set<UserBase>();
    //public DbSet<Agent> Agents => Set<Agent>();
    //public DbSet<SellContract> SellContracts => Set<SellContract>();
    public DbSet<Property> Properties => Set<Property>();
    //public DbSet<Client> Clients => Set<Client>();

    public DbSet<Client> Clients { get; set; }
    //public DbSet<Localisation> Localisations => Set<Localisation>();

    ///// public DbSet<Property> Properties { get; set; } /// ms sql


    /*public SmartAgencyAppDbContext(DbContextOptions<SmartAgencyAppDbContext> options)
        :base(options)
    {

    }*/

    //ms sql
    public SmartAgencyAppDbContext(DbContextOptions<SmartAgencyAppDbContext> options)
        : base(options)
    {
    }

    /*protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter, DateOnlyComparer>()
            .HaveColumnType("date");

    }*/



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // in memery db

        //base.OnConfiguring(optionsBuilder);
        //optionsBuilder.UseInMemoryDatabase("StorageAppDb");
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



        //modelBuilder
        //    .HasAnnotation("ProductVersion", "7.0.0")
        //    .HasAnnotation("Relational:MaxIdentifierLenght", 128);

        //SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

        modelBuilder.Entity("SmartAgency._1_Core.Data.Entities.UserEntity.ClientEntity.Client", x =>
        {
            x.Property<DateOnly>("DateAdded")
            .HasConversion<DateOnlyConverter>();
            //.HasColumnType("datetime2");

            x.ToTable("Clients");
        });
            //.Property(x => x.DateAdded);
            //.HasColumnType("date")
            //.HasColumnName("DateAddedd");
            //.HasAnnotation()
            //.HasConversion<DateOnlyConverter, DateOnlyComparer>()
            //.ValueGeneratedOnAddOrUpdate();
            
            
            


        modelBuilder.Entity<Property>().OwnsOne(x => x.Localisation);
        modelBuilder.Entity<Client>().OwnsOne(x => x.Email);
        modelBuilder.Entity<Client>().OwnsOne(x => x.FirstName);
        modelBuilder.Entity<Client>().OwnsOne(x => x.LastName);
        
        //modelBuilder.Entity<Client>().Property(x => x.DateAdded).HasConversion<DateTime>();
        //modelBuilder.Entity<Client>().Ignore(x => x.DateAdded);


        base.OnModelCreating(modelBuilder);
    }

    // nie jest potrzebne wraz z klasa localisation converter
    /*    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

            //configurationBuilder.Properties<Localisation>().HaveConversion<LocalisationConverter>();


            base.ConfigureConventions(configurationBuilder);
        }*/

    //// MS SQL
    /*public SmartAgencyAppDbContext(DbContextOptions<SmartAgencyAppDbContext> options)
        :base(options)
    {

    }*/

 

}