using RepositoryPatternUoW.Data.Repositories;

namespace RepositoryPatternUoW.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
    }

    private IDepartamentoRepository _departamentoRepository;
    public IDepartamentoRepository DepartamentoRepository
    {
        get => _departamentoRepository ?? (_departamentoRepository = new DepartamentoRepository(_context));
    }

    public bool Commit()
    {
        return _context.SaveChanges() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
