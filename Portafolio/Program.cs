using Microsoft.AspNetCore.Localization;
using Portafolio.Servicios;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Razor;
using Portafolio;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
builder.Services.AddTransient<IRepositorioProyectos , RepositorioProyectos>();

//ass localizacion
builder.Services.AddLocalization(opciones =>
{
    opciones.ResourcesPath = "Recursos";
});

var app = builder.Build();


var supportedCultures = Constantes.CulturasUISoportadas.Select(c => new CultureInfo(c.Value)).ToList();
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("es"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new CookieRequestCultureProvider(), // lee la cultura desde las cookies
        new AcceptLanguageHeaderRequestCultureProvider() // como fallback
    }
};


app.UseRequestLocalization(localizationOptions);




app.UseRequestLocalization(opciones =>
{ 
    opciones.DefaultRequestCulture = new RequestCulture("es");
    opciones.SupportedUICultures = Constantes.CulturasUISoportadas.Select(cultura => new  CultureInfo(cultura.Value)).ToList();
});

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
