using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YatriSewa_MVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UserContext>(options =>
{
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=YatriDB;Trusted_Connection=True;MultipleActiveResultSets=true");
});

// Configure ASP.NET Core Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    // Other configuration options...
})
    .AddEntityFrameworkStores<UserContext>()
    .AddDefaultTokenProviders();

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

// Configure authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Yatri}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "landing",
    pattern: "Landing",
    defaults: new { controller = "Yatri", action = "Landing" });

app.MapControllerRoute(
    name: "GetStarted",
    pattern: "GetStarted",
    defaults: new { controller = "Yatri", action = "GetStarted" });
app.MapControllerRoute(
    name: "Signin",
    pattern: "Signin",
    defaults: new { controller = "Yatri", action = "Signin" });
app.MapControllerRoute(
    name: "Signup",
    pattern: "Signup",
    defaults: new { controller = "Yatri", action = "Signup" });
app.MapControllerRoute(
    name: "Error",
    pattern: "Error",
    defaults: new { controller = "Yatri", action = "Error" });app.MapControllerRoute(
    name: "Changepassword",
    pattern: "Changepassword",
    defaults: new { controller = "Yatri", action = "Changepassword" });
app.MapControllerRoute(
    name: "Busdetails",
    pattern: "Busdetails",
    defaults: new { controller = "Yatri", action = "Busdetails" });
app.MapControllerRoute(
    name: "Customerfeedback",
    pattern: "Customerfeedback",
    defaults: new { controller = "Yatri", action = "Customerfeedback" });
app.MapControllerRoute(
    name: "Giftcard",
    pattern: "Giftcard",
    defaults: new { controller = "Yatri", action = "Giftcard" });
app.MapControllerRoute(
    name: "Myticket",
    pattern: "Myticket",
    defaults: new { controller = "Yatri", action = "Myticket" });
app.MapControllerRoute(
    name: "Notavailable",
    pattern: "Notavailable",
    defaults: new { controller = "Yatri", action = "Notavailable" });
app.MapControllerRoute(
    name: "Notification",
    pattern: "Notification",
    defaults: new { controller = "Yatri", action = "Notification" });
app.MapControllerRoute(
    name: "Payment",
    pattern: "Payment",
    defaults: new { controller = "Yatri", action = "Payment" });
app.MapControllerRoute(
    name: "Paymentcard",
    pattern: "Paymentcard",
    defaults: new { controller = "Yatri", action = "Paymentcard" });
app.MapControllerRoute(
    name: "Profile",
    pattern: "Profile",
    defaults: new { controller = "Yatri", action = "Profile" });
app.MapControllerRoute(
    name: "Selectseat",
    pattern: "Selectseat",
    defaults: new { controller = "Yatri", action = "Selectseat" });
app.MapControllerRoute(
    name: "Home",
    pattern: "Home",
    defaults: new { controller = "Yatri", action = "Home" });
app.Run();
