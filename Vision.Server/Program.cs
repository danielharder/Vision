using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Vision.Server.Controllers;
using Vision.Server.Interfaces;
using Vision.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// SQL Server Registration
builder.Services.AddDbContext<VisionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Add services to the container.
//builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
//builder.Services.AddScoped<UserController>();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<VisionDbContext>()
    .AddDefaultTokenProviders();


//Auth
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
//            ValidateIssuer = false,
//            ValidateAudience = false,
//            ClockSkew = TimeSpan.Zero // Optional: reduce timespan for token expiration validation
//        };
//    });

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
