<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
=======
﻿using Microsoft.EntityFrameworkCore;
>>>>>>> parent of 2f1c67b (Sprint 2 complete!)
using System.Diagnostics;

namespace Vision.Server.Models
{
    public class VisionDbContext : IdentityDbContext<User>
    {
        //public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardMember> BoardMembers { get; set; }
        public DbSet<Lane> Lanes { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<Log> Logs { get; set; }

        public VisionDbContext(DbContextOptions<VisionDbContext> conn): base (conn)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(b => b.PK);
            modelBuilder.Entity<User>().Property(b => b.PK).ValueGeneratedOnAdd();
<<<<<<< HEAD
            //modelBuilder.Entity<User>().Property(b => b.Id).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

=======
            modelBuilder.Entity<User>().Property(b => b.Id).ValueGeneratedOnAdd();
>>>>>>> parent of 2f1c67b (Sprint 2 complete!)

            modelBuilder.Entity<Board>().HasKey(b => b.PK);
            //modelBuilder.Entity<Board>().Property(b => b.PK).ValueGeneratedOnAdd();

            // Generates a new GUID on the client side
            modelBuilder.Entity<Board>().Property(b => b.PK)
                .HasDefaultValueSql("newid()")
                .ValueGeneratedOnAdd();


<<<<<<< HEAD
            //modelBuilder.Entity<Board>().Property(b => b.Id).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
=======
>>>>>>> parent of 2f1c67b (Sprint 2 complete!)

            modelBuilder.Entity<Board>().Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<BoardMember>().HasNoKey();

            modelBuilder.Entity<Lane>().HasKey(b => b.PK);
            modelBuilder.Entity<Lane>().Property(b => b.PK).ValueGeneratedOnAdd();
<<<<<<< HEAD
            //modelBuilder.Entity<Lane>().Property(b => b.Id).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Story>().HasKey(b => b.PK);
            modelBuilder.Entity<Story>().Property(b => b.PK).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Story>().Property(b => b.Id).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<TaskEntity>().HasKey(b => b.PK);
            modelBuilder.Entity<TaskEntity>().Property(b => b.PK).ValueGeneratedOnAdd();
            //modelBuilder.Entity<TaskEntity>().Property(b => b.Id).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
=======
            modelBuilder.Entity<Lane>().Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Story>().HasKey(b => b.PK);
            modelBuilder.Entity<Story>().Property(b => b.PK).ValueGeneratedOnAdd();
            modelBuilder.Entity<Story>().Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<TaskEntity>().HasKey(b => b.PK);
            modelBuilder.Entity<TaskEntity>().Property(b => b.PK).ValueGeneratedOnAdd();
            modelBuilder.Entity<TaskEntity>().Property(b => b.Id).ValueGeneratedOnAdd();
>>>>>>> parent of 2f1c67b (Sprint 2 complete!)

            modelBuilder.Entity<Log>().HasKey(b => b.PK);
            modelBuilder.Entity<Log>().Property(b => b.PK).ValueGeneratedOnAdd();
        }

    }
}
