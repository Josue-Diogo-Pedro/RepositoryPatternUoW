using RepositoryPatternUoW.Data.Repositories.Base;
using RepositoryPatternUoW.Domain;

namespace RepositoryPatternUoW.Data.Repositories;

public interface IDepartamentoRepository : IGenericRepository<Departamento>
{
    //Task<Departamento> GetByIdAsync(int id);
    //void Add(Departamento departamento);
}
