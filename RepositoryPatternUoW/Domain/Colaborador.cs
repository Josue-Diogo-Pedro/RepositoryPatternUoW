namespace RepositoryPatternUoW.Domain;

public class Colaborador
{
    public int Id { get; set; }
    public string? Nome { get; set; }

    public int DepartamentoId { get; set; }
    public Departamento? Departamento { get; set; }
}
