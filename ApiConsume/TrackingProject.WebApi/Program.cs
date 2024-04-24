using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.BusinessLayer.Concrete;
using TrackingProject.DataAccessLayer.Abstract;
using TrackingProject.DataAccessLayer.Concrete;
using TrackingProject.DataAccessLayer.EntityFramework;
using TrackingProject.EntityLayer.Concrete;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 5;
}).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

//builder.Services.AddAuthorization(
//    options=>
//    {
//        options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Admin"));
//        options.AddPolicy("RequireEmployeeRole", policy => policy.RequireRole("Employee"));
//    });


var jwtIssuer = builder.Configuration["AuthSettings:Issuer"];
var jwtKey = builder.Configuration["AuthSettings:Key"];
var jwtAudience = builder.Configuration["AuthSettings:Audience"];
//builder.Services.AddAuthentication(auth =>
//{
//    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = jwtAudience,
//        ValidIssuer = jwtIssuer,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
//        ValidateIssuerSigningKey = true
//    };
//});

builder.Services.AddAuthentication(auth=>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AuthSettings:Token").Value)),
            ValidateIssuer = false,
            ValidIssuer= builder.Configuration.GetSection("AuthSettings:Issuer").Value,
            ValidateAudience = false,
            ValidAudience = builder.Configuration.GetSection("AuthSettings:Audience").Value,
            RequireExpirationTime = false,
        };
    });
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => false;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementManager>();
builder.Services.AddScoped<IAnnouncementTypeDal, EfAnnouncementTypeDal>();
builder.Services.AddScoped<IAnnouncementTypeService, AnnouncementTypeManager>();

builder.Services.AddScoped<IDepartmentDal, EfDepartmentDal>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>();

builder.Services.AddScoped<IScheduleTypeDal, EfScheduleTypeDal>();
builder.Services.AddScoped<IScheduleTypeService, ScheduleTypeManager>();

builder.Services.AddScoped<IWeeklyScheduleDal, EfWeeklyScheduleDal>();
builder.Services.AddScoped<IWeeklyScheduleService, WeeklyScheduleManager>();

builder.Services.AddScoped<IApplicationUserDal, EfApplicationUserDal>();
builder.Services.AddScoped<IApplicationUserService, ApplicationUserManager>();

builder.Services.AddScoped<IRecognitionNotificationDal, EfRecognitionNotificationDal>();
builder.Services.AddScoped<IRecognitionNotificationService, RecognitionNotificationManager>();


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
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
