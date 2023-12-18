using RepositoryPatternUoW.Data.Repositories.Base;
using RepositoryPatternUoW.Domain;

namespace RepositoryPatternUoW.Data.Repositories;

public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamentoRepository
{
    //private readonly ApplicationContext _context;
    //private readonly DbSet<Departamento> _dbSet;

    public DepartamentoRepository(ApplicationContext context) : base(context)
    {
        //_context = context;
        //_dbSet = _context.Set<Departamento>();
    }

    /*
    public async Task<Departamento> GetById(int id)
    {
        var result = await _dbSet
            .AsNoTracking()
            .Include(p => p.Colaboradores)
            .FirstOrDefaultAsync(p => p.Id == id);

        return result;
    }

    public void CriarDepartamento(Departamento departamento)
    {
        _dbSet.Add(departamento);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    */
}
