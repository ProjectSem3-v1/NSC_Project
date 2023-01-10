using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSC_Project.Data;
using NSC_Project.SeedData;

var builder = WebApplication.CreateBuilder(args);

//Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

//DbContext
builder.Services.AddDbContext<NSC_ProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NSC_ProjectContext") ?? throw new InvalidOperationException("Connection string 'NSC_ProjectContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
//Seeddata
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//UseSession 
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=FlightRoutes}/{action=Index}/{id?}"
	);
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Trips}/{action=Index}/{id?}");


app.Run();
