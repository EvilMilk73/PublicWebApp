using WebApi;
using WebApi.Services.CustomerService;
using WebApi.Services.ManagerService;
using WebApi.Services.DriverService;
using WebApi.Services.WaypointService;
using WebApi.Services.CargoService;
using WebApi.Services.VehicleService;

using WebApi.Hubs;

using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews().AddJsonOptions(x=>
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IWaypointService, WaypointService>();
builder.Services.AddScoped<ICargoService, CargoService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

var app = builder.Build();
app.UseCors(x => x
         .AllowAnyMethod()
         .AllowAnyHeader()
         .SetIsOriginAllowed(origin => true) // allow any origin
         .AllowCredentials());
app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapHub<ChatHub>("/chatHub");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
