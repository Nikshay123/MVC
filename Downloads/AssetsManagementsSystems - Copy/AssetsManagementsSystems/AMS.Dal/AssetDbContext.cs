using Microsoft.EntityFrameworkCore;
using AssetsManagementsSystems.DAL;
using System.Collections.Generic;
using AssetsManagementSystems.Api.Books;
using AssetsManagementSystems.Api.Hardware;
using AssetsManagementsSystems.Api.Software;
using AMS.Dal.Models;

namespace AssetsManagementsSystems.DAL
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext(DbContextOptions<AssetDbContext> options) : base(options) { }//initialize a new instance
                                                                                             //of Dbcontext class

        public DbSet<Book> Books { get; set; }
        public DbSet<Hardware> Hardwares { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<AssignAsset> Assign { get; set; }
        public DbSet<UserModel>Users { get; set; }



    }
}
