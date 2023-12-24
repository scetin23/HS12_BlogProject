using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region API Sonrasý Kaldýrýlan Kodlar
//API sonrasý kaldýrýlan kodlar...
////Connection
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

////IdentityUser'da kaldýrýlmasý gerekiyor, AppUser kullanacaðýz çünkü AppUser'da bir IdentityUser'dýr. Onun için burayý vererek ayaða kaldýrmasýný istiyorum.
//builder.Services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<AppDbContext>();
////Ve ayaða kaldýrýrken de AppUser, IdentityRole kullanacaðýz.
////**Burada Identity'nin kurallarýný yani zorlayýcýlýklarýný ortadan kaldýrmak için yada o kurallarý verebilmek için  yaptýk.
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


//!!**.NetCore'un kendi DependencyResolver'ýný kullanmak istemiyoruz IOC container'ýný kullanmak istemiyoruz.Bunun yerine DependencyResolver adýnda baþka bir class'ým var o da Application'ýn içerisinde. Bu DependencyResolver AutoFac ile çalýþýyor.
//!****DependencyResolver kýsmýný yazdýðým için aþaðýdaki kodlarý yazmama gerek kalmadý! IOC altýnda DependencyResolver class'ýn içinde tanýmladýk.
//builder.Services.AddTransient<IGenreService, GenreService>(); //Bunu microsoftun kendi IOC yapýyor ama ben bunun dependency resolver IOC üzerinden gerçekleþmesini istiyorum.
//builder.Services.AddTransient<IGenreRepository, GenreRepository>();

////AutoMapper 
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//!!**API yazdýktan sonra Presentation direkt servise ulaþamadýðý için servisin repository'sini falan IOC container'ýn kaldýrmasýna ihtiyaç kalmadý.Buradan kaldýrýp API'deki Program.cs içerisine bunlarý veriyoruz. 
//API yazdýktan sonra bu kodlarý kaldýrdýk!
//DependencyResolver kýsmýný yazdým ama program aþaðýdaki baðlantýyý yazmazsam DependencyResolver kýsmýný bilmez içine girip çalýþmaz!
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
