using Microsoft.EntityFrameworkCore;
using VehiclesApp.Api.Data;
using Ninject;
using Ninject.Web.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
//builder.Host.UseServiceProviderFactory(new NinjectServiceProviderFactory()); //Throws out "unhandled exception" errors

builder.Services.AddDbContext<VehiclesAppContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
