using RepositoryPatternUoW.Data.Repositories;

namespace RepositoryPatternUoW.Data;

public interface IUnitOfWork : IDisposable
{
    IDepartamentoRepository DepartamentoRepository { get; }
    bool Commit();
}
