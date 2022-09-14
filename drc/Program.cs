using Dados.Repositorio;
using Dados.Repositorio.Context;
using Dominio.Entidade;
using Dominio.Servico;
using Dominio.Servico.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

string conection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DrcDbContext>(options => options.UseMySql(conection, ServerVersion.AutoDetect(conection)));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IUOW), typeof(UOW));


builder.Services.AddScoped(typeof(IBaseRepository<Produto>), typeof(ProdutoRepository));
builder.Services.AddScoped(typeof(ProdutoService));
builder.Services.AddScoped(typeof(IBaseRepository<Categoria>), typeof(CategoriaRepository));
builder.Services.AddScoped(typeof(CategoriaService));
builder.Services.AddScoped(typeof(IBaseRepository<UnidadeMedida>), typeof(UnidadeMedidaRepository));
builder.Services.AddScoped(typeof(UnidadeMedidaService));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produto}/{action=Index}/{id?}");

app.Run();
