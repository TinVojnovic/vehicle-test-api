using AutoMapper;
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

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
