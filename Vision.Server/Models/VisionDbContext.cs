using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Vision.Server.Models
{
    public class VisionDbContext : DbContext
    {
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<BoardDTO> Boards { get; set; }
        public DbSet<BoardMember> BoardMembers { get; set; }
        public DbSet<LaneDTO> Lanes { get; set; }
        public DbSet<StoryDTO> Stories { get; set; }
        public DbSet<TaskDTO> Tasks { get; set; }
        public DbSet<Log> Logs { get; set; }

        public VisionDbContext(DbContextOptions<VisionDbContext> conn): base (conn)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDTO>().HasKey(b => b.PK);
            modelBuilder.Entity<UserDTO>().Property(b => b.PK).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserDTO>().Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<BoardDTO>().HasKey(b => b.PK);
            modelBuilder.Entity<BoardDTO>().Property(b => b.PK).ValueGeneratedOnAdd();
            modelBuilder.Entity<BoardDTO>().Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<BoardMember>().HasNoKey();

            modelBuilder.Entity<LaneDTO>().HasKey(b => b.PK);
            modelBuilder.Entity<LaneDTO>().Property(b => b.PK).ValueGeneratedOnAdd();
            modelBuilder.Entity<LaneDTO>().Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<StoryDTO>().HasKey(b => b.PK);
            modelBuilder.Entity<StoryDTO>().Property(b => b.PK).ValueGeneratedOnAdd();
            modelBuilder.Entity<StoryDTO>().Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<TaskDTO>().HasKey(b => b.PK);
            modelBuilder.Entity<TaskDTO>().Property(b => b.PK).ValueGeneratedOnAdd();
            modelBuilder.Entity<TaskDTO>().Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Log>().HasKey(b => b.PK);
            modelBuilder.Entity<Log>().Property(b => b.PK).ValueGeneratedOnAdd();
        }

    }
}
