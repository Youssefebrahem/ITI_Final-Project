using ITI_Project.Data;
using ITI_Project.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ITI_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo>();//save data in database
            //builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo2>();//save data in list in memory
            //builder.Services.AddTransient<IStudentRepo, StudentRepo>();

            //create one instance for the whole application, but addtransient will create a new instance for each request
            // it's better to use AddSingleton for memory saving..static data
            //builder.Services.AddSingleton<IDepartmentRepo, DepartmentRepo2>();

            //addscoped will create an instance for each request, more secure than transient, and usable for database
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
            builder.Services.AddScoped<IAccountRepo, AccountRepo>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(a =>
            {
                a.LogoutPath = "/Account/Logout";
                //a.Cookie.Name = "ITIProject";
                a.LoginPath = "/account/login";
                //a.AccessDeniedPath = "/account/accessdenied";
            });
            builder.Services.AddDbContext<ITIContext>(a =>
            {
                a.UseSqlServer(builder.Configuration.GetConnectionString("con1"));
            });
            builder.Services.AddSession(a =>
            {
                
            });


            var app = builder.Build();


            // Configure the HTTP request pipeline.


            ////Use is a middleware that is used to handle the request and response
            ////and take the next middleware in the pipeline
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("First Middleware\n");
            //    await next.Invoke();
            //    await context.Response.WriteAsync("After return from next Middleware\n");  
            //});
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Second Middleware\n");
            //});

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //this is for the static files like css, js, images from wwwroot folder
            app.UseStaticFiles();

            // name of the controller / name of the action
            app.UseRouting();

            //this is for the authorization, and after that the action will be executed (UseRouting)
            app.UseAuthentication();//who are you
            app.UseAuthorization();//what you can do

            app.UseSession();//add, read, delete session

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}
