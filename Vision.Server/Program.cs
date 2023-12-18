using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vision.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// SQL Server Registration
builder.Services.AddDbContext<VisionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// SQLLite reg
//builder.Services.AddDbContext<VisionDbContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Postgres reg
//builder.Services.AddDbContext<VisionDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//ConfigurationManager configuration = builder.Configuration;
//var conn = configuration.GetConnectionString("ConnectionString");

// Add services to the container.


//builder.Services.AddSqlServer<VisionDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Create scope and apply migration
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<VisionDbContext>();
        await dbContext.Database.MigrateAsync();
    }
    //var TestMigration = app.Services.GetRequiredService<VisionDbContext>();
    //await TestMigration.Database.EnsureCreatedAsync();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
