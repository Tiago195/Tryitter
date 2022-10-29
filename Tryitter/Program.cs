using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Tryitter.Repository;
using Tryitter.Contants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<ErrorMiddleware>();
builder.Services.AddControllers();
// var DbHost = Environment.GetEnvironmentVariable("DB_HOST");
// var DbName = Environment.GetEnvironmentVariable("DB_NAME");
// var DbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
// var connectionString = $"Data Source={DbHost};Initial Catalog={DbName};User ID=sa;Password={DbPassword}";
builder.Services.AddDbContext<ITryitterContext, TryitterContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITryitterContext, TryitterContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
  options.SaveToken = true;
  options.RequireHttpsMetadata = false;
  options.TokenValidationParameters = new TokenValidationParameters()
  {
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Token.secret))
  };
});

// builder.Services.AddAuthorization(options =>
// {
//   options.AddPolicy("Ids", policy => policy.RequireClaim("Id"));
// });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ErrorMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();

public partial class Program { }
