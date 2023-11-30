using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using SigriswilPay.Data;
using SigriswilPay.Data.Repositories;
using SigriswilPay.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(x =>
    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddCors();

builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("x-api-version"),
        new MediaTypeApiVersionReader("x-api-version"));
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "SigriswilPay API",
        Version = "v1",
        Description = string.Empty,
        Contact = new OpenApiContact()
        {
            Name = "SigriswilPay Project",
            Url = new Uri("https://github.com/othiagorsilva/Sigriswil")
        }
    });
});

builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.DocumentTitle = "SigriswilPay";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"SigriswilPay API - v1");
    c.RoutePrefix = string.Empty;
});

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();