using Microsoft.EntityFrameworkCore;
using web.data;

var builder = WebApplication.CreateBuilder(args);

// Ajoutez le service DbContext et configurez-le pour utiliser PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Ajouter les services MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurez le pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
