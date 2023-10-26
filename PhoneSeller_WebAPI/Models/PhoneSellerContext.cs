using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PhoneSeller_WebAPI.Models
{
    public partial class PhoneSellerContext : DbContext
    {
        public PhoneSellerContext()
        {
        }

        public PhoneSellerContext(DbContextOptions<PhoneSellerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<ModelVersion> ModelVersions { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserPermission> UserPermissions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.ModelName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Models__BrandID__3B75D760");
            });

            modelBuilder.Entity<ModelVersion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.ModelVersions)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK__Versions__ModelI__48CFD27E");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__3E52440B");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PermissionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK__UserPermi__Permi__45F365D3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserPermi__UserI__44FF419A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
