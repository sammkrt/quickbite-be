using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Data;
using QuickBiteBE.Helpers;
using QuickBiteBE.Services;
using saltagram.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<QuickBiteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuickBiteContext") ?? throw new InvalidOperationException("Connection string 'QuickBiteContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IBlobService, BlobService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddSwaggerGen();
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
// });
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.UseCors("AllowOrigin");
app.UseCors(options =>
    options.WithOrigins(new[] { "http://localhost:3000" }).AllowCredentials().AllowAnyHeader().AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();