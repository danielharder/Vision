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
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vision;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"; // Replace with your actual connection string

            services.AddDbContext<VisionDbContext>(options =>
                options.UseSqlServer(connectionString));

            var serviceProvider = services.BuildServiceProvider();
            _dbContext = serviceProvider.GetService<VisionDbContext>()!;
        }

        //[Fact]
        //public async Task TestAddEntity()
        //{
        //    // Arrange
        //    var testEntity = new Vision.Server.Models.Board
        //    {
        //        // Set properties as necessary
        //    };

        //    _dbContext.YourEntityModels.Add(testEntity);

        //    // Act
        //    await _dbContext.SaveChangesAsync();

        //    // Assert
        //    var entity = await _dbContext.YourEntityModels.FirstOrDefaultAsync(e => e.Id == testEntity.Id);
        //    Assert.NotNull(entity);
        //    // Additional assertions as necessary
        //}

        [Fact]
        public async System.Threading.Tasks.Task TestCreateUser()
        {
            // Arrange
            var newUser = new User
            {
                PK = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@example.com",
                Description = "A test user",
                CreationDate = DateTime.UtcNow,
                ArchiveDate = DateTime.MaxValue // or another appropriate value
            };

            // Act
            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();

            // Assert
            var createdUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.PK == newUser.PK);
            Assert.NotNull(createdUser);
            Assert.Equal("John", createdUser.FirstName);
            Assert.Equal("Doe", createdUser.LastName);
            // Additional assertions as necessary
        }

        // Add additional tests as needed
    }
}
