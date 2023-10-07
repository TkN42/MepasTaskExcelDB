using TaskExcelDB.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using TaskExcelDB.Repository.Product;
using TaskExcelDB.Helpers;
using TaskExcelDB.Repository.Login;
using TaskExcelDB.Repository.User;
using TaskExcelDB.Repository.Categori;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ExcelService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoriRepository, CategoriRepository>();
// Oturum (Session) yapýlandýrmasý
builder.Services.AddDistributedMemoryCache(); // Oturum verilerini bellekte saklamak için kullanýlýr
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10); // Oturum süresi (10 dakika olarak ayarlanabilir)
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.Cookie.Name = ".NetCoreMVC.Auth";
    x.LoginPath = "/Login/Index";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession(); // Oturumlarý etkinleþtirin

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();