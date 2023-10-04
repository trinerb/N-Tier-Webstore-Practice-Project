using Microsoft.EntityFrameworkCore;
using WebStore.DataAccess.Data;
using WebStore.DataAccess.Repository;
using WebStore.DataAccess.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //get the connectionstring and pass it into UseSqlServer. Name "DefaultConnection" important, must match from appsettings.json
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); //for repository-pattern

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); //wwwroot-files

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}"); //"if nothing is defined, go here"

app.Run();
