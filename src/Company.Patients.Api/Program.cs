using System.Reflection;
using System.Text.Json.Serialization;
using Company.Patients.Application.DependencyHelpers;
using Company.Patients.Application.Interfaces;
using Company.Patients.Domain.Entities;
using Company.Patients.Infrastructure.DbContext;
using Company.Patients.Infrastructure.DbSettings;
using Company.Patients.Infrastructure.Mappng;
using Company.Patients.Infrastructure.Repositories;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddSingleton<IMongoDatabase>(options => {
  var settings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDbSettings>();
  var client = new MongoClient(settings.ConnectionString);
  return client.GetDatabase(settings.DatabaseName);
});

builder.Services.AddTransient<IPatientsDbContext, PatientsDbContext>();
builder.Services.AddTransient<IRepository<PatientEntity>, PatientsRepository>();

builder.Services.AddApplication();
builder.Services.AddAutoMapper(config => config.AddProfile(new AppMappingProfile()));

builder.Services.AddControllers().AddJsonOptions(x =>
{
  x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
