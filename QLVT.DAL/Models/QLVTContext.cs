using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLVT.DAL.Models
{
    public partial class QLVTContext : DbContext
    {
        public QLVTContext()
        {
        }

        public QLVTContext(DbContextOptions<QLVTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ctdondh> Ctdondhs { get; set; }
        public virtual DbSet<Ctphieunhap> Ctphieunhaps { get; set; }
        public virtual DbSet<Ctphieuxuat> Ctphieuxuats { get; set; }
        public virtual DbSet<Dondh> Dondhs { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public virtual DbSet<Phieunhap> Phieunhaps { get; set; }
        public virtual DbSet<Phieuxuat> Phieuxuats { get; set; }
        public virtual DbSet<Tonkho> Tonkhos { get; set; }
        public virtual DbSet<Vattu> Vattus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CJ0VQ4M;Initial Catalog=QLVT;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ctdondh>(entity =>
            {
                entity.HasKey(e => new { e.Sodh, e.Mavtu })
                    .HasName("PK__ctdondh__32CC4A23A3137796");

                entity.ToTable("ctdondh");

                entity.Property(e => e.Sodh).HasColumnName("sodh");

                entity.Property(e => e.Mavtu).HasColumnName("mavtu");

                entity.Property(e => e.Sldat).HasColumnName("sldat");

                entity.HasOne(d => d.MavtuNavigation)
                    .WithMany(p => p.Ctdondhs)
                    .HasForeignKey(d => d.Mavtu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ctdondh__mavtu__2B3F6F97");

                entity.HasOne(d => d.SodhNavigation)
                    .WithMany(p => p.Ctdondhs)
                    .HasForeignKey(d => d.Sodh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ctdondh__sodh__2C3393D0");
            });

            modelBuilder.Entity<Ctphieunhap>(entity =>
            {
                entity.HasKey(e => new { e.Sopn, e.Mavtu })
                    .HasName("PK__ctphieun__32C5081CD296CF17");

                entity.ToTable("ctphieunhap");

                entity.Property(e => e.Sopn).HasColumnName("sopn");

                entity.Property(e => e.Mavtu).HasColumnName("mavtu");

                entity.Property(e => e.Dgnhap)
                    .HasColumnType("money")
                    .HasColumnName("dgnhap");

                entity.Property(e => e.Slnhap).HasColumnName("slnhap");

                entity.HasOne(d => d.MavtuNavigation)
                    .WithMany(p => p.Ctphieunhaps)
                    .HasForeignKey(d => d.Mavtu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ctphieunh__mavtu__31EC6D26");

                entity.HasOne(d => d.SopnNavigation)
                    .WithMany(p => p.Ctphieunhaps)
                    .HasForeignKey(d => d.Sopn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ctphieunha__sopn__32E0915F");
            });

            modelBuilder.Entity<Ctphieuxuat>(entity =>
            {
                entity.HasKey(e => new { e.Sopx, e.Mavtu })
                    .HasName("PK__ctphieux__32C5080AD965F9E0");

                entity.ToTable("ctphieuxuat");

                entity.Property(e => e.Sopx).HasColumnName("sopx");

                entity.Property(e => e.Mavtu).HasColumnName("mavtu");

                entity.Property(e => e.Dgxuat)
                    .HasColumnType("money")
                    .HasColumnName("dgxuat");

                entity.Property(e => e.Slxuat).HasColumnName("slxuat");

                entity.HasOne(d => d.MavtuNavigation)
                    .WithMany(p => p.Ctphieuxuats)
                    .HasForeignKey(d => d.Mavtu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ctphieuxu__mavtu__37A5467C");

                entity.HasOne(d => d.SopxNavigation)
                    .WithMany(p => p.Ctphieuxuats)
                    .HasForeignKey(d => d.Sopx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ctphieuxua__sopx__38996AB5");
            });

            modelBuilder.Entity<Dondh>(entity =>
            {
                entity.HasKey(e => e.Sodh)
                    .HasName("PK__dondh__331E8E3EDB37DE1E");

                entity.ToTable("dondh");

                entity.Property(e => e.Sodh)
                    .ValueGeneratedNever()
                    .HasColumnName("sodh");

                entity.Property(e => e.Manhacc).HasColumnName("manhacc");

                entity.Property(e => e.Ngaydh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaydh");

                entity.HasOne(d => d.ManhaccNavigation)
                    .WithMany(p => p.Dondhs)
                    .HasForeignKey(d => d.Manhacc)
                    .HasConstraintName("FK__dondh__manhacc__286302EC");
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.HasKey(e => e.Manhacc)
                    .HasName("PK__nhacungc__314131BC09A1147F");

                entity.ToTable("nhacungcap");

                entity.Property(e => e.Manhacc)
                    .ValueGeneratedNever()
                    .HasColumnName("manhacc");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(100)
                    .HasColumnName("diachi");

                entity.Property(e => e.Dienthoai)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dienthoai");

                entity.Property(e => e.Tennhacc)
                    .HasMaxLength(100)
                    .HasColumnName("tennhacc");
            });

            modelBuilder.Entity<Phieunhap>(entity =>
            {
                entity.HasKey(e => e.Sopn)
                    .HasName("PK__phieunha__3317CC01A906EB23");

                entity.ToTable("phieunhap");

                entity.Property(e => e.Sopn)
                    .ValueGeneratedNever()
                    .HasColumnName("sopn");

                entity.Property(e => e.Ngaynhap)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaynhap");

                entity.Property(e => e.Sodh).HasColumnName("sodh");

                entity.HasOne(d => d.SodhNavigation)
                    .WithMany(p => p.Phieunhaps)
                    .HasForeignKey(d => d.Sodh)
                    .HasConstraintName("FK__phieunhap__sodh__2F10007B");
            });

            modelBuilder.Entity<Phieuxuat>(entity =>
            {
                entity.HasKey(e => e.Sopx)
                    .HasName("PK__phieuxua__3317CC1720ECE635");

                entity.ToTable("phieuxuat");

                entity.Property(e => e.Sopx)
                    .ValueGeneratedNever()
                    .HasColumnName("sopx");

                entity.Property(e => e.Ngayxuat)
                    .HasColumnType("datetime")
                    .HasColumnName("ngayxuat");

                entity.Property(e => e.Tenkh)
                    .HasMaxLength(100)
                    .HasColumnName("tenkh");
            });

            modelBuilder.Entity<Tonkho>(entity =>
            {
                entity.HasKey(e => new { e.Maso, e.Mavtu })
                    .HasName("PK__tonkho__000ADB270313F834");

                entity.ToTable("tonkho");

                entity.Property(e => e.Maso).HasColumnName("maso");

                entity.Property(e => e.Mavtu).HasColumnName("mavtu");

                entity.Property(e => e.Slcuoi).HasColumnName("slcuoi");

                entity.Property(e => e.Sldau).HasColumnName("sldau");

                entity.Property(e => e.Tongsln).HasColumnName("tongsln");

                entity.Property(e => e.Tongslx).HasColumnName("tongslx");

                entity.Property(e => e.Ngaythang).HasColumnName("ngaythang");

                entity.HasOne(d => d.MavtuNavigation)
                    .WithMany(p => p.Tonkhos)
                    .HasForeignKey(d => d.Mavtu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tonkho__mavtu__3B75D760");
            });

            modelBuilder.Entity<Vattu>(entity =>
            {
                entity.HasKey(e => e.Mavtu)
                    .HasName("PK__vattu__1D2C41D118DDA2CD");

                entity.ToTable("vattu");

                entity.Property(e => e.Mavtu)
                    .ValueGeneratedNever()
                    .HasColumnName("mavtu");

                entity.Property(e => e.Dvtinh)
                    .HasMaxLength(10)
                    .HasColumnName("dvtinh");

                entity.Property(e => e.Phantram).HasColumnName("phantram");

                entity.Property(e => e.Tenvtu)
                    .HasMaxLength(100)
                    .HasColumnName("tenvtu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
