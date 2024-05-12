using System.Reflection;
using API;
using API.Infrastracture;
using API.Register;
using API.Repository;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

//services.AddApiAuthentication(configuration);

services.AddEndpointsApiExplorer();

services.AddSwaggerGen();

//services.AddTransient<ExceptionMiddleware>();

services.AddDbContext<LearningDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(LearningDbContext)));
});

services.AddScoped<IJwtProvider, JwtProvider>();
services.AddScoped<IPasswordHasher, PasswordHasher>();

//services.AddScoped<ICourseRepository, CourseRepository>();
//services.AddScoped<ILessonsRepository, LessonsRepository>();
services.AddScoped<IUsersRepository, UsersRepository>();

//services.AddScoped<CoursesService>();
//services.AddScoped<LessonsService>();
services.AddScoped<UserService>();

//services.AddAutoMapper(typeof(DataBaseMappings));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseAuthentication();

app.UseAuthorization();

//app.AddMappedEndpoints();

app.Run();