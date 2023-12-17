using Xunit;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Vision.Server.Models;

namespace Vision.test
{
    public class VisionDbContextIntegrationTests
    {
        private readonly VisionDbContext _dbContext;

        public VisionDbContextIntegrationTests()
        {
            var services = new ServiceCollection();
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vision;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            services.AddDbContext<VisionDbContext>(options =>
                options.UseSqlServer(connectionString));

            var serviceProvider = services.BuildServiceProvider();
            _dbContext = serviceProvider.GetService<VisionDbContext>()!;
        }

        [Fact]
        public async System.Threading.Tasks.Task TestCreateUser()
        {
            var newUser = new User
            {
                PK = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@example.com",
                Description = "A test user",
                CreationDate = DateTime.UtcNow,
                ArchiveDate = DateTime.MaxValue
            };

            // Act
            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();

            // Assert
            var createdUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.PK == newUser.PK);
            Assert.NotNull(createdUser);
            Assert.Equal("John", createdUser.FirstName);
            Assert.Equal("Doe", createdUser.LastName);
        }

    }
}
