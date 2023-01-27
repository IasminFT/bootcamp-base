using Tarefas.DAO;
using Tarefas.DTO;
using Tarefas.Web.Models;

//AutoMapper: framework que ajuda a converter a ViewModel em DTO (remove código repetido)
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

//Configuraçao do AutoMapper
var config = new AutoMapper.MapperConfiguration(c =>{
    //conversão possivel
    c.CreateMap<TarefaViewModel, TarefaDTO>().ReverseMap();
});

IMapper mapper = config.CreateMapper();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ITarefaDAO, TarefaDAO>();
builder.Services.AddSingleton(mapper);

//Classes DAO

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
