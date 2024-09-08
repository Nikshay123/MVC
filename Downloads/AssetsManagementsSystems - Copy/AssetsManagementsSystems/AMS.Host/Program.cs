using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using AMS.Dal;
using AMS.Logic.BookService;
using AMS.Logic.HardwareService;
using AMS.Logic.SoftwareService;
using AMS.Logic;
using AssetsManagementsSystems.DAL;
using AssetsManagementsSystems.Repositary;
using LogIntoFile;
using Week6Assignment.Repository;
using AMS.Host;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add database context
builder.Services.AddDbContext<AssetDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IAssetService<>), typeof(AssetService<>));
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IHardwareService, HardwareService>();
builder.Services.AddScoped<ISoftwareService, SoftwareService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, 
            ValidateAudience = true,//audience matches the expected audience and Valid the reciever of token
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,//token should be validated using issuer signing key
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))//using the symetric key for validating user and utf is encoding algo.
        };
    });

builder.Services.AddLogging(builder =>
{
    builder.AddProvider(new FileLoggerProvider("D:\\logs.txt"));
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nikshay API", Version = "N1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme//this line is responsible for security defination for jwt authorizaton
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement 
    {//Add security for jwt authorization
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
//70 it required parameter
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
}

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<GlobalExceptionHandlerExtensions>();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
