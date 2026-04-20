using LecCRRUD.Services;
using Microsoft.EntityFrameworkCore;

// dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.*
// also added Core.Sqlite and Core.Design

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// Add services to the container.
builder.Services.AddControllersWithViews();
// objects are created once per request - notes from handwritten stuff
builder.Services.AddScoped<IPersonRepository,  DbPersonRepository>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
