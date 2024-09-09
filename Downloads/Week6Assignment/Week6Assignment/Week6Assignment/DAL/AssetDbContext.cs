using Microsoft.EntityFrameworkCore;
using Week6Assignment.DAL;
using Microsoft.EntityFrameworkCore;
namespace Week6Assignment.DAL
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext(DbContextOptions<AssetDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Hardware> Hardwares { get; set; }
        public DbSet<Software> Softwares { get; set; }

        public DbSet<AssignAsset> Assign { get; set; }



    }
}
