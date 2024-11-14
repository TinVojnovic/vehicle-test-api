using AutoMapper;
using CoachingApp.Api.Endpoints;
using Microsoft.EntityFrameworkCore;
using Ninject;
using Ninject.Web.AspNetCore;
using VehiclesApp.Api.Data;

var builder = WebApplication.CreateBuilder(args);

//builder.Host.UseServiceProviderFactory(new NinjectServiceProviderFactory()); //Throws out "unhandled exception" errors

builder.Services.AddDbContext<VehiclesAppContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<VehicleMakeService>();
builder.Services.AddScoped(typeof(GeneralService<>));

builder.Services.AddControllers();

var app = builder.Build();

app.MapVehicleMakesEndpoints();

app.Run();
