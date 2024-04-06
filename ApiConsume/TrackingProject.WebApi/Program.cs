using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
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

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 5;
}).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();


builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = "ahmetseyyit",
        ValidIssuer = "ahmetseyyit",
        RequireExpirationTime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is the key use in encryption")),
    };
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

builder.Services.AddScoped<IEmployeeDal, EfEmployeeDal>();
builder.Services.AddScoped<IEmployeeService, EmployeeManager>();


builder.Services.AddScoped<IEmployeeDal, EfEmployeeDal>();
builder.Services.AddScoped<IEmployeeService, EmployeeManager>();

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

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("TrackingApiCors");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
