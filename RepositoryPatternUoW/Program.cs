using Microsoft.EntityFrameworkCore;
using RepositoryPatternUoW.Data;
using RepositoryPatternUoW.Data.Repositories;
using RepositoryPatternUoW.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(p => p.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer("Data Source=DESKTOP-DSNQA59\\SQLEXPRESS;Initial Catalog=UoW;Integrated Security=True;pooling=false; Trust Server Certificate=true;")
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging());

builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//InicializarDataBase(app);

app.MapControllers();

app.Run();


using var db = new ApplicationContext();

if (db.Database.CanConnect())
{
    var isso = "posso";
}
else
{
    var aquilo = "nao posso";
}

/*
void InicializarDataBase(IApplicationBuilder app)
{
    var db = app
        .ApplicationServices
        .CreateScope()
        .ServiceProvider
        .GetRequiredService<ApplicationContext>();

    if (db.Database.EnsureCreated())
    {
        db.Departamentos.AddRange(Enumerable.Range(1, 10).Select(p => new Departamento
        {
            Descricao = $"Departamento {p}",
            Colaboradores = Enumerable.Range(1, 10).Select(x => new Colaborador
            {
                Nome = $"Colaborador {x}/{p}"
            }).ToList()
        }));

        db.SaveChanges();
    }
}
*/