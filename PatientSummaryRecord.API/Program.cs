using Microsoft.EntityFrameworkCore;
using PatientSummaryRecord.API.Middleware;
using PatientSummaryRecord.Application.Interfaces;
using PatientSummaryRecord.Application.Services;
using PatientSummaryRecord.Infrastructure.Data;
using PatientSummaryRecord.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<PatientDbContext>(options =>
options.UseSqlite("Data Source=patients.db"));
builder.Services.AddScoped<IPatientRepository, SqlitePatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PatientDbContext>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.UseHttpsRedirection();



app.Run();
