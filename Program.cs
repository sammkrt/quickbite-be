using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Data;
using QuickBiteBE.Services;
using QuickBiteBE.Services.Interfaces;
using saltagram.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<QuickBiteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuickBiteContext") ??
                         throw new InvalidOperationException("Connection string 'QuickBiteContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IBlobService, BlobService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();