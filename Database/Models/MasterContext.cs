﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Database.Models
{
    public partial class MasterContext : DbContext
    {
        public MasterContext()
        {
        }

        public MasterContext(DbContextOptions<MasterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<PriceSubscriber> PriceSubscribers { get; set; }
        public virtual DbSet<StockSubscriber> StockSubscribers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Brands_pk")
                    .IsClustered(false);

                entity.ToTable("Brands", "PhoneShop");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Slug)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("slug");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Comments_pk")
                    .IsClustered(false);

                entity.ToTable("Comments", "PhoneShop");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment1)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.PhoneSlug)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("phoneSlug");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Phones_pk")
                    .IsClustered(false);

                entity.ToTable("Phones", "PhoneShop");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandSlug)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("brandSlug");

                entity.Property(e => e.Dimension)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("dimension");

                entity.Property(e => e.Hided).HasColumnName("hided");

                entity.Property(e => e.Images)
                    .IsUnicode(false)
                    .HasColumnName("images");

                entity.Property(e => e.Os)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("os");

                entity.Property(e => e.PhoneName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("phoneName");

                entity.Property(e => e.PhoneSlug)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("phoneSlug");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ReleaseDate)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("release_date");

                entity.Property(e => e.Specifications)
                    .IsUnicode(false)
                    .HasColumnName("specifications");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.Storage)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("storage");

                entity.Property(e => e.Thumbnail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("thumbnail");
            });

            modelBuilder.Entity<PriceSubscriber>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PriceSubscribers_pk")
                    .IsClustered(false);

                entity.ToTable("PriceSubscribers", "PhoneShop");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandSlug)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("brandSlug");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.PhoneSlug)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("phoneSlug");
            });

            modelBuilder.Entity<StockSubscriber>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("StockSubscribers_pk")
                    .IsClustered(false);

                entity.ToTable("StockSubscribers", "PhoneShop");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandSlug)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("brandSlug");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.PhoneSlug)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("phoneSlug");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Users_pk")
                    .IsClustered(false);

                entity.ToTable("Users", "PhoneShop");

                entity.HasIndex(e => e.Email, "Users_email_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}