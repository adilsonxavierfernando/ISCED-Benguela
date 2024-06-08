
using ISCED_Benguela.Data.AutoMapper;
using ISCED_Benguela.Data.Context;
using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Register/Login";
        x.AccessDeniedPath = "/Register/Login";
    }
    );
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(typeof(AutomapperProfile));
builder.Services.AddDbContext<IscedDbContext>(o=>o.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(EstudanteRepository));
builder.Services.AddScoped(typeof(RegisterRepository));
builder.Services.AddScoped(typeof(ProfessorRepository));
builder.Services.AddScoped(typeof(CursosRepository));
builder.Services.AddScoped(typeof(DepartamentosRepository));
builder.Services.AddScoped(typeof(DisciplinaRepository));
builder.Services.AddScoped(typeof(MateriaRepository));
builder.Services.AddScoped(typeof(UsuarioRepository));
builder.Services.AddScoped(typeof(MembershipRepository));
builder.Services.AddScoped(typeof(InfoSiteRepository));
builder.Services.AddTransient<Button>();


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
