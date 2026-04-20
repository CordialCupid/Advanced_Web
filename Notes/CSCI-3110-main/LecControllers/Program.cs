var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
// Establishes that we will be using routing in the app
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// The routes we will use
app.MapControllerRoute(
    name: "default", // this name is used as something that the dev can use to reference to this route
    pattern: "{controller=Home}/{action=Index}/{id?}") // declares that /home/index is the root directory
    .WithStaticAssets();

// if the route has four segments, it will use this controller route
app.MapControllerRoute(
    name: "fourSegments", 
    pattern: "{controller}/{action}/{code}/{idnumber}") 
    .WithStaticAssets();

// if the route begins with student, use this one
app.MapControllerRoute(
    name: "student", 
    pattern: "student/{enumber}",
    defaults: new { controller="Home", action = "Details" })
    .WithStaticAssets();

app.MapControllerRoute(
    name: "variable", 
    pattern: "query/{name}/{*values}",
    defaults: new { controller="Home", action = "Variable" })
    .WithStaticAssets();


app.Run();
