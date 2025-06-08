using Microsoft.EntityFrameworkCore;
using VetClinic.Domain.Repositories;
using VetClinic.Infrastructure.Database;
using VetClinic.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ClinicDbContext>(options => options.UseSqlServer(connectionString,
        x => x.MigrationsHistoryTable("__EFMigrationHistory", "Clinic")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(CommonRepository<>));
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IVeterinarianRepository, VeterinarianRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

