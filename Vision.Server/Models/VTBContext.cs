using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Vision.Server.Models
{
    public class VisionDbContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardMember> BoardMembers { get; set; }
        public DbSet<Lane> Lanes { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public string DbPath { get; }

        //public VisionDbContext(string aConn)
        //{

        //}
        string _configuration;
        public VisionDbContext(string aConn)
        {
            _configuration = (string)AppContext.GetData("ConnectionString");

            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            //DbPath = System.IO.Path.Join(path, "Vision.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={_configuration}");

    }
}
