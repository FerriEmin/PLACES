using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace PlacesDB.Models
{
    public class Context : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }


        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = DBConnection.ConfigurationRoot.GetConnectionString(DBConnection.ThisConnection);
                if (string.IsNullOrEmpty(connectionString)) throw new Exception("Database Configuration File not Found!");
                optionsBuilder.UseSqlServer(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        // The Fluent API allows for more complex and conditional attribute settings (as opposed to the simpler data attributes)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            // Most settings are implicit thanks to the types, nullability and references (length and requirement still need guidance)
            // Foreign keys and constrains are implicitly generated if not stated otherwise

            modelBuilder.Entity<Token>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .UseIdentityColumn();

                entity.Property(e => e.Value)
                .HasMaxLength(255);

                entity.Property(e => e.Expires)
                .HasColumnType("datetime");

                entity.HasOne(e => e.User)
                .WithMany(e => e.Tokens);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .UseIdentityColumn();

                entity.Property(e => e.UserGroup)
                .IsRequired();

                entity.Property(e => e.FirstName)
                .HasMaxLength(32)
                .IsRequired();

                entity.Property(e => e.LastName)
                .HasMaxLength(32)
                .IsRequired();

                entity.Property(e => e.ProfileImage)
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsRequired();

                // Must be unique
                entity.Property(e => e.Username)
                .HasMaxLength(32)
                .IsRequired();

                // Salt is stored together with password
                entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsRequired();

                entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime");

                entity.Property(e => e.Created)
                .HasColumnType("datetime");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .UseIdentityColumn();

                entity.Property(e => e.Title)
                .HasMaxLength(32)
                .IsRequired();

                entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Created)
                .HasColumnType("datetime");

                entity.HasOne(e => e.User)
                .WithMany(e => e.Events);

                entity.HasOne(e => e.Category)
                .WithMany(e => e.Events);

                entity.HasOne(e => e.Location)
                .WithMany(e => e.Events);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .UseIdentityColumn();

                entity.Property(e => e.Like);

                entity.Property(e => e.Comment)
                .HasMaxLength(255);

                entity.Property(e => e.Created)
                .HasColumnType("datetime");

                entity.HasOne(e => e.Event)
                .WithMany(e => e.Reviews)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.User)
                .WithMany(e => e.Reviews)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .UseIdentityColumn();

                entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsRequired();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .UseIdentityColumn();

                entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsRequired();

                entity.Property(e => e.Address)
                .HasMaxLength(64)
                .IsRequired();

                entity.Property(e => e.Latitude)
                .HasColumnType("decimal(10, 8)")
                .IsRequired();

                entity.Property(e => e.Longitude)
                .HasColumnType("decimal(11, 8)")
                .IsRequired();

                entity.HasOne(e => e.Country)
                .WithMany(e => e.Locations);

                entity.HasOne(e => e.City)
                .WithMany(e => e.Locations);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .UseIdentityColumn();

                entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsRequired();

                // ISO 3166
                entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsRequired();
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .UseIdentityColumn();

                entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsRequired();

                entity.HasOne(e => e.Country)
                .WithMany(e => e.Cities)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            });
        }

    }
}
