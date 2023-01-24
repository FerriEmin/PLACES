﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PlacesDB.Models
{
    public class Context : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }


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

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.UserGroup)
                .IsRequired();

                entity.Property(e => e.FirstName)
                .HasMaxLength(32)
                .IsRequired();

                entity.Property(e => e.LastName)
                .HasMaxLength(32)
                .IsRequired();

                // Must be unique
                entity.Property(e => e.Username)
                .HasMaxLength(32)
                .IsRequired();

                // Salt is stored together with password
                entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsRequired();

                entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .IsRequired();
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title)
                .HasMaxLength(32)
                .IsRequired();

                entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.ImgPath)
                .HasMaxLength(32)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .IsRequired();

                entity.HasOne(e => e.User)
                .WithMany(e => e.Posts)
                .IsRequired();

                entity.HasOne(e => e.Category)
                .WithMany(e => e.Posts)
                .IsRequired();

                entity.HasOne(e => e.Location)
                .WithMany(e => e.Posts)
                .IsRequired();
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Rating)
                .IsRequired();

                entity.Property(e => e.Comment)
                .HasMaxLength(255);

                entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .IsRequired();

                entity.HasOne(e => e.Post)
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

                entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsRequired();

                entity.Property(e => e.ImgPath)
                .HasMaxLength(32)
                .IsRequired()
                .IsUnicode(false);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id);

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
                .WithMany(e => e.Locations)
                .IsRequired();
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsRequired();

                // ISO 3166
                entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsRequired();
            });
        }

    }
}