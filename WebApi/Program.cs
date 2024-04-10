using Microsoft.EntityFrameworkCore;
using Services;
using Services.Extensions;
using Shared.Helper;
using Shared.Helpers;
using Shared.Models;
using SharedServices;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.ConfigureAuthentication();

//QA with next two lines adding connection string and way to communicate with DB
//and create migrations
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserCassetteService, UserCassetteService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICassetteService, CassetteService>();
builder.Services.AddSingleton<JwtManager>();
builder.Services.AddScoped<UserPrincipal>();
builder.Services.ConfigureRepositories(connectionString);


//QA jako bitno!!!!! bez ovog ispod ne radi mapper za service
builder.Services.Configure<AppSettingsConfig>(builder.Configuration.GetSection("AppSettings"));
var assemblies = AppDomain.CurrentDomain.GetAssemblies();
builder.Services.AddAutoMapper(assemblies);

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //QA for cors call from Fe to work
    app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
                    .AllowCredentials()); // allow credentials
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
