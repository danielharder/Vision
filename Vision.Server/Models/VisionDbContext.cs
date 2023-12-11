using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Vision.Server.Models
{
    public class VisionDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardMember> BoardMembers { get; set; }
        public DbSet<Lane> Lanes { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Log> Logs { get; set; }

        //public string DbPath { get; }

        //public VisionDbContext(string aConn)
        //{

        //}
        //string _configuration;
        //public VisionDbContext()
        //{
        //    _configuration = (string)AppContext.GetData("ConnectionString")!;

        //    //var folder = Environment.SpecialFolder.LocalApplicationData;
        //    //var path = Environment.GetFolderPath(folder);
        //    //DbPath = System.IO.Path.Join(path, "Vision.db");
        //}

        public VisionDbContext(DbContextOptions<VisionDbContext> conn): base (conn)
        {

        }

        //// The following configures EF to create a Sqlite database file in the
        //// special "local" folder for your platform.
        ////protected override void OnConfiguring(DbContextOptionsBuilder options)
        ////    => options.UseSqlite($"Data Source={_configuration}");
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer($"Data Source={_configuration}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(b => b.PK);
            modelBuilder.Entity<User>().Property(b => b.PK).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Board>().HasKey(b => b.PK);
            modelBuilder.Entity<Board>().Property(b => b.PK).ValueGeneratedOnAdd();
            modelBuilder.Entity<Board>().Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<BoardMember>().HasNoKey();

            modelBuilder.Entity<Lane>().HasKey(b => b.PK);
            modelBuilder.Entity<Lane>().Property(b => b.PK).ValueGeneratedOnAdd();
            modelBuilder.Entity<Lane>().Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Story>().HasKey(b => b.PK);
            modelBuilder.Entity<Story>().Property(b => b.PK).ValueGeneratedOnAdd();
            modelBuilder.Entity<Story>().Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Task>().HasKey(b => b.PK);
            modelBuilder.Entity<Task>().Property(b => b.PK).ValueGeneratedOnAdd();
            modelBuilder.Entity<Task>().Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Log>().HasKey(b => b.PK);
            modelBuilder.Entity<Log>().Property(b => b.PK).ValueGeneratedOnAdd();
        }

    }
}
