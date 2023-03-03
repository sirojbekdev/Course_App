using BlazorSpinner;
using MatBlazor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Presentation.Application.Interfaces;
using Presentation.Data;
using Presentation.Data.Services;
using Presentation.Infostructure.Identity;
using Presentation.Infostructure.Persistence;
using Presentation.Infostructure.Persistence.Repositories;
using Presentation.Infostructure.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

#region DbContext and Identity
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseLazyLoadingProxies()
    .UseSqlServer(connectionString), ServiceLifetime.Transient);

builder.Services.AddDefaultIdentity<AppUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.User.RequireUniqueEmail = true;
})
    .AddRoles<AppRole>()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<AppDbContextInitializer>();

#endregion

// Add services to the container.

builder.Services.AddMudServices();
builder.Services.AddAntDesign();
builder.Services.AddMatBlazor();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddLocalization();

builder.Services.AddScoped<SpinnerService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<AppData>();
builder.Services.AddTransient<IItemSearch, ItemSearch>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAuthorizationHandler, CorrectUserHandler>();
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("IsActive", policy => policy.Requirements.Add(new CorrectUserRequirement()));
});

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
