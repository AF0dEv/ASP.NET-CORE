using Login23.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//esta linha foi adicionada: (e também o namespace Equipas.Data) <---------------------------------
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(
                        builder.Configuration.GetConnectionString("DefaultConnection")));

//##########################################################################
//Enable Session.-------------------------------------------------2023-04-28
//é necessário adicionar a lina app.UseSession antes
//da app.MapControllerRoute ao fundo
builder.Services.AddSession();





//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromSeconds(10);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});
//##########################################################################

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Publica/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Publica}/{action=Index}/{id?}");

app.Run();
