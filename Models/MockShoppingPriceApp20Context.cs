using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MockShoppingPriceComparisonApp2._0.Models
{
    public partial class MockShoppingPriceApp20Context : DbContext
    {
        public MockShoppingPriceApp20Context()
        {

        }
        public MockShoppingPriceApp20Context(DbContextOptions<MockShoppingPriceApp20Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comparison> Comparison { get; set; }
        public virtual DbSet<ComparisonFeedback> ComparisonFeedback { get; set; }
        public virtual DbSet<ProductFeedback> ProductFeedback { get; set; }
        public virtual DbSet<ProductSpecifications> ProductSpecifications { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Specifications> Specifications { get; set; }
        public virtual DbSet<SpecificationsCategoryRelation> SpecificationsCategoryRelation { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VWavailableproducts> VWavailableproducts { get; set; }
        public virtual DbSet<VWnotavailableproducts> VWnotavailableproducts { get; set; }
        public virtual DbSet<VWupcomingproducts> VWupcomingproducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=MockShoppingPriceApp2.0;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("Brands_pk");

                entity.Property(e => e.BrandName).IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName).IsUnicode(false);
            });

            modelBuilder.Entity<Comparison>(entity =>
            {
                entity.HasOne(d => d.ProductId1Navigation)
                    .WithMany(p => p.ComparisonProductId1Navigation)
                    .HasForeignKey(d => d.ProductId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Comaprison_Products_1");

                entity.HasOne(d => d.ProductId2Navigation)
                    .WithMany(p => p.ComparisonProductId2Navigation)
                    .HasForeignKey(d => d.ProductId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Comaprison_Products_2");

                entity.HasOne(d => d.ProductId3Navigation)
                    .WithMany(p => p.ComparisonProductId3Navigation)
                    .HasForeignKey(d => d.ProductId3)
                    .HasConstraintName("Comaprison_Products_3");

                entity.HasOne(d => d.ProductId4Navigation)
                    .WithMany(p => p.ComparisonProductId4Navigation)
                    .HasForeignKey(d => d.ProductId4)
                    .HasConstraintName("Comaprison_Products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comparison)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Comaprison_Users");
            });

            modelBuilder.Entity<ComparisonFeedback>(entity =>
            {
                entity.Property(e => e.ComaprisonFeedback).IsUnicode(false);

                entity.HasOne(d => d.Comparison)
                    .WithMany(p => p.ComparisonFeedback)
                    .HasForeignKey(d => d.ComparisonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Comparison_feedback_Comaprison");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ComparisonFeedback)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Comparison_feedback_Users");
            });

            modelBuilder.Entity<ProductFeedback>(entity =>
            {
                entity.Property(e => e.ProductFeedback1).IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductFeedback)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_Feedback_Products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProductFeedback)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_Feedback_Users");
            });

            modelBuilder.Entity<ProductSpecifications>(entity =>
            {
                entity.HasKey(e => e.ProductSpecId)
                    .HasName("product_specifications_pk");

                entity.Property(e => e.SpecificationValue).IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSpecifications)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_specifications_Products");

                entity.HasOne(d => d.SpecCat)
                    .WithMany(p => p.ProductSpecifications)
                    .HasForeignKey(d => d.SpecCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_specifications_Specifications_Category_Relation");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("Products_pk");

                entity.Property(e => e.ProductAvailability).IsUnicode(false);

                entity.Property(e => e.ProductImage).IsUnicode(false);

                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_brands");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_category");
            });

            modelBuilder.Entity<Specifications>(entity =>
            {
                entity.HasKey(e => e.SpecificationId)
                    .HasName("Specifications_pk");

                entity.Property(e => e.SpecificationName).IsUnicode(false);
            });

            modelBuilder.Entity<SpecificationsCategoryRelation>(entity =>
            {
                entity.HasKey(e => e.SpecCatRelId)
                    .HasName("Specifications_Category_Relation_pk");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SpecificationsCategoryRelation)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Specifications_Category_Relation_Category");

                entity.HasOne(d => d.Specification)
                    .WithMany(p => p.SpecificationsCategoryRelation)
                    .HasForeignKey(d => d.SpecificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Specifications_Category_Relation_Specifications");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("Users_pk");

                entity.Property(e => e.UserAddress).IsUnicode(false);

                entity.Property(e => e.UserEmail).IsUnicode(false);

                entity.Property(e => e.UserGender)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserGivenName).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.Property(e => e.UserPassword).IsUnicode(false);

                entity.Property(e => e.UserRole).IsUnicode(false);
            });

            modelBuilder.Entity<VWavailableproducts>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWavailableproducts");

                entity.Property(e => e.Brand).IsUnicode(false);

                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<VWnotavailableproducts>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWnotavailableproducts");

                entity.Property(e => e.Brand).IsUnicode(false);

                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<VWupcomingproducts>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWupcomingproducts");

                entity.Property(e => e.Brand).IsUnicode(false);

                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
