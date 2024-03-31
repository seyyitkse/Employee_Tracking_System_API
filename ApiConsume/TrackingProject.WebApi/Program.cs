using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.BusinessLayer.Concrete;
using TrackingProject.DataAccessLayer.Abstract;
using TrackingProject.DataAccessLayer.Concrete;
using TrackingProject.DataAccessLayer.EntityFramework;
using TrackingProject.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Set up database connections
builder.Services.AddDbContext<Context>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
});


builder.Services.AddDbContext<PanelUserContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
});

// Add scoped services
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

builder.Services.AddScoped<IPanelUserDal, EfPanelUserDal>();
builder.Services.AddScoped<IPanelUserService, PanelUserManager>();


builder.Services.AddAutoMapper(typeof(Program));

// Configure CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("TrackingApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Add FluentValidation for validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddControllers();

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PanelUserContext>(); 
builder.Services.AddIdentity<PanelUser, PanelUserRoles>().AddEntityFrameworkStores<PanelUserContext>();


builder.Services.AddControllersWithViews();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("TrackingApiCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
