using NewTest.Api;
using NewTest.Api.Configuration;
using NewTest.Context;
using NewTest.Context.Seeder;
using NewTest.Services.Settings;
using NewTest.Settings;

var logSettings = Settings.Load<LogSettings>("Log");

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger(logSettings);

var services = builder.Services;

services.AddHttpContextAccessor();

services.AddAppDbContext(builder.Configuration);

services.AddAppCors();

services.AddEndpointsApiExplorer();

services.AddSwaggerGen();

services.AddControllers();

services.RegisterServices();

services.AddAppAutoMappers();

services.AddAppValidator();

var app = builder.Build();

app.UseAppCors();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

DbInitializer.Execute(app.Services);

DbSeeder.Execute(app.Services);

app.Run();