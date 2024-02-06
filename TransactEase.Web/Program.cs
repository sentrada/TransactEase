using Microsoft.EntityFrameworkCore;
using TransactEase.Infrastructure.Persistence;
using TransactEase.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TransactEaseDbContext>(options =>
    options.UseSqlServer(
        "Server=localhost;Database=TransactEase;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=sentrada;Password=!P'szt!c'!;"));


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();