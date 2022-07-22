using Coffe.Data;
using Coffe.Repos;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppContextdb>(options =>
{
    options.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"], options =>
    {
        options.CommandTimeout(30);
        options.EnableRetryOnFailure(3);
    });
});

builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddFluentValidation(fv =>
                {
                   // fv.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
                    // fv.ImplicitlyValidateChildProperties = true;
                    fv.AutomaticValidationEnabled = true;
                    fv.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
                    fv.ImplicitlyValidateChildProperties = true;
                });
builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
//builder.Services
//    .AddFluentValidation(conf =>
//{
//    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
//    //conf.AutomaticValidationEnabled = false;
//});

builder.Services.AddScoped<IAcountRepo, AcountRepo>();
var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
