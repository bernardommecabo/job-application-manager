using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectApplication.Repos;
using ProjectApplication.Services;
using ProjectInfrastructure.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();

builder.Services.AddScoped<IResumeRepository, ResumeRepository>();
builder.Services.AddScoped<IResumeService, ResumeService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProjectInfrastructure.Data.AppDbContext>(options =>
    options.UseNpgsql
        (builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("ProjectInfrastructure")
    )
);


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
