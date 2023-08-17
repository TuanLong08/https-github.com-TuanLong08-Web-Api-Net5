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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=LAPTOP-L5UL9OG2\\SQLEXPRESS;Initial Catalog=Code-API-Net5;Integrated Security=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
