using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using VetClinic.Api.Mappings;
using VetClinic.Domain.Repositories;
using VetClinic.Infrastructure.Database;
using VetClinic.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy
          .WithOrigins("http://localhost:3000")
          .AllowAnyHeader()
          .AllowAnyMethod()
    );
});

builder.Services.AddAutoMapper(typeof(VetClinicProfile).Assembly);

builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ClinicDbContext>(options => options.UseSqlServer(connectionString,
        x => x.MigrationsHistoryTable("__EFMigrationHistory", "Clinic")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(CommonRepository<>));
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IVeterinarianRepository, VeterinarianRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IProcedureRepository, ProcedureRepository>();    

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ClinicDbContext>();
    var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
    DbInitializer.Initialize(context, config);
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();

