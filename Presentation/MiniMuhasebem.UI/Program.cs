using Microsoft.AspNetCore.Authentication.Cookies;
using MiniMuhasebem.UI.Configurations;
using MiniMuhasebem.UI.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(opt => {
    opt.ModelValidatorProviders.Clear();
    opt.Filters.Add(new ActionExceptionFilter());
});

builder.Services.AddHttpContextAccessor();

//Fluent Validation
builder.Services.AddFluentValidationService();

//Automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//Session
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(30);
});

//Custom Services
builder.Services.AddDIServices();

//Authentication

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    opt =>
    {
        opt.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {
                context.Response.Redirect("/entry/login/signin");
                //E�er admin taraf�nda login olmadan yetki gerektiren bir sayfaya gitmeye �al���rsa admin login gelsin
                //if (context.Request.Path.Value.Contains("admin"))
                //{
                //    context.Response.Redirect("/admin/login/signin");
                //}
                //else //sunum projesinde ise o projeye ait login gelsin
                //{
                //    context.Response.Redirect("/login/signin");
                //}
                return Task.CompletedTask;
            }
        };

    });


//Authorization
builder.Services.AddAuthorizationService();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "user",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "entry",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
