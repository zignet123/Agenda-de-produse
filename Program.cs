using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Agenda_de_produse.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Agenda_de_produseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Agenda_de_produseContext") ?? throw new InvalidOperationException("Connection string 'Agenda_de_produseContext' not found.")));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
