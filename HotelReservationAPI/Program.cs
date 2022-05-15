using HotelReservation.Data;
using Microsoft.EntityFrameworkCore;
using HotelReservation.Data.Repositories;
using HotelReservation.Data.Repositories.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();

builder.Services.AddDbContext<HotelReservationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelReservation")));
builder.Services.AddScoped<HotelReservationDbInitializer>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(options =>
options.AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
);

app.MapControllers();

app.UseHttpsRedirection();
app.UseCors(options =>
options.AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
); 
app.Run();
