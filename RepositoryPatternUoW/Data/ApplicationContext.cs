using Microsoft.EntityFrameworkCore;
using RepositoryPatternUoW.Domain;

namespace RepositoryPatternUoW.Data;

public class ApplicationContext : DbContext
{
	public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Colaborador> Colaboradores { get; set; }

	public ApplicationContext() { }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
}
