using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineAccountingServer.Application.Services.AppServices;
using OnlineAccountingServer.Application.Services.CompanyServices;
using OnlineAccountingServer.Domain;
using OnlineAccountingServer.Domain.AppEntities.Identity;
using OnlineAccountingServer.Domain.Repositories.UCAFRepositories;
using OnlineAccountingServer.Persistence;
using OnlineAccountingServer.Persistence.Contexts;
using OnlineAccountingServer.Persistence.Repositories.UCAFRepositories;
using OnlineAccountingServer.Persistence.Services.AppServices;
using OnlineAccountingServer.Persistence.Services.CompanyServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
builder.Services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
builder.Services.AddScoped<IContextService, ContextService>();
builder.Services.AddScoped<IUCAFService, UCAFService>();

builder.Services.AddMediatR(
    cfg => cfg.RegisterServicesFromAssembly
    (typeof(OnlineAccountingServer.Application.AssemblyReference).Assembly));

builder.Services.AddAutoMapper(
    typeof(OnlineAccountingServer.Persistence.AssemblyReference).Assembly);

//We use the AssemblyReference class to specify that the controller presentation will be used from within.
builder.Services.AddControllers()
    .AddApplicationPart(typeof(OnlineAccountingServer.Presentation.AssemblyReference).Assembly);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    var jwtSecuritySheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
     {
         { jwtSecuritySheme, Array.Empty<string>() }
     });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OnlineAccountingServer.WebApi v1");
        options.RoutePrefix = "swagger";
        options.DisplayRequestDuration();
        options.EnablePersistAuthorization();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
