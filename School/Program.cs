using Microsoft.EntityFrameworkCore;
using School;
using School.Model;
using School.Repo.Implement;
using School.Repo.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppContexts>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IGenericRepo<Student>, ImGenericRepo<Student>>();
builder.Services.AddScoped<IGenericRepo<Department>, ImGenericRepo<Department>>();
builder.Services.AddScoped<IGenericRepo<ClassRoom>, ImGenericRepo<ClassRoom>>();
builder.Services.AddScoped<ITeacher,ImTeacher >();
builder.Services.AddScoped<Istudent, ImStudent>();
builder.Services.AddScoped<ISubject, ImSubject>();
builder.Services.AddScoped<IClassRoom, ImClassRoom>();
builder.Services.AddScoped<IEnrollment, ImEnrollment>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();







var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
