using Coffe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<AppContextdb>(options =>
{
    options.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"], options =>
        {
            options.CommandTimeout(30);
            options.EnableRetryOnFailure(3);
        });
});

app.MapGet("/", () => "Hello World!");

app.Run();
