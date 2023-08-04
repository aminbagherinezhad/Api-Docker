using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nik.Api.Models;

public partial class NikDbContext : DbContext
{
    public NikDbContext()
    {
    }

    public NikDbContext(DbContextOptions<NikDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<CardBanner> CardBanners { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryImage> CategoryImages { get; set; }

    public virtual DbSet<CompanyLogo> CompanyLogos { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactU> ContactUs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Slider> Sliders { get; set; }

    public virtual DbSet<Social> Socials { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
      //  => optionsBuilder.UseSqlServer("Server=.;Database=NikDb;Trusted_Connection=True;TrustServerCertificate=True");
        => optionsBuilder.UseSqlServer("Server=193.141.65.167,2019;Database=ProductApi;User Id=aminbvb;password=0Gz*92s4bbbbbbb;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.ToTable("Achievement");

            entity.Property(e => e.AchievementId).HasColumnName("AchievementID");
            entity.Property(e => e.Icon).HasMaxLength(150);
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__Blog__54379E3063E75C0B");

            entity.ToTable("Blog");

            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(450);
            entity.Property(e => e.ImageName).HasMaxLength(50);
            entity.Property(e => e.Tags).HasMaxLength(150);
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<CardBanner>(entity =>
        {
            entity.HasKey(e => e.CardBannerId).HasName("PK__CardBann__4280811206489A5F");

            entity.ToTable("CardBanner");

            entity.Property(e => e.Icon).HasMaxLength(150);
            entity.Property(e => e.Text).HasMaxLength(450);
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__CATEGORY__19093A0B7F012C6F");

            entity.ToTable("Category");

            entity.Property(e => e.Title).HasMaxLength(150);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Category_Category");
        });

        modelBuilder.Entity<CategoryImage>(entity =>
        {
            entity.HasKey(e => e.CategoryImageId).HasName("PK__Category__7CA506C3375F8F92");

            entity.ToTable("CategoryImage");

            entity.Property(e => e.ImageName).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.CategoryImages)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CategoryI__Categ__2E1BDC42");
        });

        modelBuilder.Entity<CompanyLogo>(entity =>
        {
            entity.HasKey(e => e.CompanyLogosId).HasName("PK__CompanyL__9EF28081A35C6520");

            entity.Property(e => e.ImageUrl).HasMaxLength(50);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contact");

            entity.Property(e => e.Email).HasMaxLength(80);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Subject).HasMaxLength(250);
            entity.Property(e => e.Text).HasMaxLength(450);
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.HasKey(e => e.ContactUsId);

            entity.Property(e => e.Address).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(450);
            entity.Property(e => e.ImageName).HasMaxLength(150);
            entity.Property(e => e.Tags).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<Slider>(entity =>
        {
            entity.HasKey(e => e.SliderId).HasName("PK__Slider__24BC96F07D3D905B");

            entity.ToTable("Slider");

            entity.Property(e => e.FinalTitle).HasMaxLength(450);
            entity.Property(e => e.FirstTitle).HasMaxLength(150);
            entity.Property(e => e.ImageName).HasMaxLength(150);
            entity.Property(e => e.MiddleTitle).HasMaxLength(450);
        });

        modelBuilder.Entity<Social>(entity =>
        {
            entity.ToTable("Social");

            entity.Property(e => e.Icon).HasMaxLength(150);
            entity.Property(e => e.Url).HasMaxLength(150);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(70);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
