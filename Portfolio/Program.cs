using System.Configuration;
using Portfolio.Middleware;
using Portfolio.Misc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEmailService, EmailService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AppContext>(options => options.UseNpgsql(
        builder.Configuration.GetConnectionString("Connect")
    )
);
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

app.UseRequestLogs();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
