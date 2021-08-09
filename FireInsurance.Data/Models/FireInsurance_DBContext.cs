using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class FireInsurance_DBContext : DbContext
    {
        public FireInsurance_DBContext()
        {
        }

        public FireInsurance_DBContext(DbContextOptions<FireInsurance_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=.; initial catalog=FireInsurance_DB;User Id=sa;Password=12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1256_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreationDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.NationalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
