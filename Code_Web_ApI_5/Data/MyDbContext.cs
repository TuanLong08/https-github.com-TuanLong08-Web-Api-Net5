using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Code_Web_ApI_5.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            
        }
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<HangHoa> HangHoa { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=LAPTOP-L5UL9OG2\\SQLEXPRESS;Initial Catalog=Code-API-Net5;Integrated Security=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e => {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDh);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<DonHangChiTiet>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new { e.MaDh, e.MaHh });

                entity.HasOne(e => e.DonHang)
                     .WithMany(e => e.donHangChiTiets)
                     .HasForeignKey(e => e.MaDh)
                     .HasConstraintName("FK_DonHangCT_DonHang");

                entity.HasOne(e => e.HangHoa)
                     .WithMany(e => e.donHangChiTiets)
                     .HasForeignKey(e => e.MaHh)
                     .HasConstraintName("FK_HangHoaCT_HangHoa");

            });
        }
    }
}
