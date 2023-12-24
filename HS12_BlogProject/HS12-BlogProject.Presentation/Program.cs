using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region API Sonras� Kald�r�lan Kodlar
//API sonras� kald�r�lan kodlar...
////Connection
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

////IdentityUser'da kald�r�lmas� gerekiyor, AppUser kullanaca��z ��nk� AppUser'da bir IdentityUser'd�r. Onun i�in buray� vererek aya�a kald�rmas�n� istiyorum.
//builder.Services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<AppDbContext>();
////Ve aya�a kald�r�rken de AppUser, IdentityRole kullanaca��z.
////**Burada Identity'nin kurallar�n� yani zorlay�c�l�klar�n� ortadan kald�rmak i�in yada o kurallar� verebilmek i�in  yapt�k.
//builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
//{
//	options.SignIn.RequireConfirmedEmail = false;
//	options.SignIn.RequireConfirmedPhoneNumber = false;
//	options.SignIn.RequireConfirmedAccount = false;
//	options.Password.RequireUppercase = false;
//	options.Password.RequiredLength = 3;
//	options.Password.RequireLowercase = false;
//	options.Password.RequireNonAlphanumeric = false;
//}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


//!!**.NetCore'un kendi DependencyResolver'�n� kullanmak istemiyoruz IOC container'�n� kullanmak istemiyoruz.Bunun yerine DependencyResolver ad�nda ba�ka bir class'�m var o da Application'�n i�erisinde. Bu DependencyResolver AutoFac ile �al���yor.
//!****DependencyResolver k�sm�n� yazd���m i�in a�a��daki kodlar� yazmama gerek kalmad�! IOC alt�nda DependencyResolver class'�n i�inde tan�mlad�k.
//builder.Services.AddTransient<IGenreService, GenreService>(); //Bunu microsoftun kendi IOC yap�yor ama ben bunun dependency resolver IOC �zerinden ger�ekle�mesini istiyorum.
//builder.Services.AddTransient<IGenreRepository, GenreRepository>();

////AutoMapper 
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//!!**API yazd�ktan sonra Presentation direkt servise ula�amad��� i�in servisin repository'sini falan IOC container'�n kald�rmas�na ihtiya� kalmad�.Buradan kald�r�p API'deki Program.cs i�erisine bunlar� veriyoruz. 
//API yazd�ktan sonra bu kodlar� kald�rd�k!
//DependencyResolver k�sm�n� yazd�m ama program a�a��daki ba�lant�y� yazmazsam DependencyResolver k�sm�n� bilmez i�ine girip �al��maz!
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
//{
//    builder.RegisterModule(new DependencyResolver());
//});
#endregion


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
