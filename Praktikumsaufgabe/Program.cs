using Microsoft.EntityFrameworkCore;
using Praktikumsaufgabe.Data;
using Praktikumsaufgabe.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICommunicationRepositry, CommunicationRepositry>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EFContext>(options => {
	options.UseSqlServer(builder.Configuration.GetConnectionString("EFConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
