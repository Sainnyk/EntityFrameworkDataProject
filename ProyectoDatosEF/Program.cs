using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using ProyectoDatosEF.Data;
using ProyectoDatosEF.Models;
using ProyectoDatosEF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("sqlhospital");
//Resolvemos dependencias. El new lo hace ya por nosotros
builder.Services.AddTransient<RepositoryHospital>();
builder.Services.AddTransient<RepositoryDoctor>();
builder.Services.AddTransient<RepositoryPlantilla>();
builder.Services.AddTransient<RepositoryEmpleados>();
//Las clases context de acceso a datos utilizan un método especial llamado AddContext
builder.Services.AddDbContext<HospitalContext>(options => options.UseSqlServer(connectionString));




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
