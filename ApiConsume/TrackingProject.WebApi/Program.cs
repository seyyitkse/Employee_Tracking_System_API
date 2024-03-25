using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.BusinessLayer.Concrete;
using TrackingProject.DataAccessLayer.Abstract;
using TrackingProject.DataAccessLayer.Concrete;
using TrackingProject.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementManager>();
builder.Services.AddScoped<IAnnouncementTypeDal, EfAnnouncementTypeDal>();
builder.Services.AddScoped<IAnnouncementTypeService, AnnouncementTypeManager>();

builder.Services.AddScoped<IDepartmentDal, EfDepartmentDal>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>();

builder.Services.AddScoped<IScheduleTypeDal, EfScheduleTypeDal>();
builder.Services.AddScoped<IScheduleTypeService, ScheduleTypeManager>();
builder.Services.AddScoped<IScheduleUserDal, EfScheduleUserDal>();
builder.Services.AddScoped<IScheduleUserService, ScheduleUserManager>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("TrackingApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("TrackingApiCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
