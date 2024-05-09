var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    defaults: new { controller = "Yatri", action = "Error" });


app.Run();
