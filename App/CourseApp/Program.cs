using Microsoft.EntityFrameworkCore;
using Presentation.Application.Interfaces;
using Presentation.Infostructure.Identity;
using Presentation.Infostructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

#region DbContext and Identity
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseLazyLoadingProxies()
    .UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => {
    options.SignIn.RequireConfirmedEmail = false;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddRoles<AppRole>()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<AppDbContextInitializer>();

#endregion

// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var initialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitializer>();
    await initialiser.InitialiseAsync();
    await initialiser.SeedAsync();
}

app.Run();
