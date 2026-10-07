using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using School;
using School.Model;
using School.Repo.Implement;
using School.Repo.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
builder.Services.AddScoped<IUser, ImUser>();

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Key"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization    ();
app.UseHttpsRedirection();

app.MapControllers();


app.Run();
//app.UseAuthorization();
//app.Use(async (context, next) =>
//{
//    context.Response.WriteAsync("First\n");
//    await next(context);
//    context.Response.WriteAsync("First response\n");

//});

//app.Use(async (context, next) =>
//{
//    context.Response.WriteAsync("Second\n");
//    await next(context);
//    context.Response.WriteAsync("Second response\n");

//});

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Third\n");
//});
