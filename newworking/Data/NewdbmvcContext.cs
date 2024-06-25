using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using newworking.Models;

namespace newworking.Data;

public partial class NewdbmvcContext : DbContext
{
    public NewdbmvcContext()
    {
    }

    public NewdbmvcContext(DbContextOptions<NewdbmvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=newdbmvc;User ID=sa;Password=aptech;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Bid).HasName("PK__Books__C6DE0CC1187DBADC");

            entity.Property(e => e.Bid).HasColumnName("BId");
            entity.Property(e => e.Bauthor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BAuthor");
            entity.Property(e => e.Bdesc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BDesc");
            entity.Property(e => e.Bimage)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BImage");
            entity.Property(e => e.Bprice).HasColumnName("BPrice");
            entity.Property(e => e.Btitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BTitle");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_Genres");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__Category__D830D4775E3D09A4");

            entity.ToTable("Category");

            entity.Property(e => e.CId).HasColumnName("cId");
            entity.Property(e => e.CName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cName");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CtId).HasName("PK__Customer__2B12A68716D44415");

            entity.ToTable("Customer");

            entity.Property(e => e.CtId).HasColumnName("ctId");
            entity.Property(e => e.CtAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ctAddress");
            entity.Property(e => e.CtContext)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ctContext");
            entity.Property(e => e.CtEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ctEmail");
            entity.Property(e => e.CtGender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ctGender");
            entity.Property(e => e.CtName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ctName");
            entity.Property(e => e.CtPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ctPassword");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GId).HasName("PK__Genre__DCD909204BE06220");

            entity.ToTable("Genre");

            entity.Property(e => e.GId).HasColumnName("gId");
            entity.Property(e => e.GName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
