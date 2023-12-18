using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternUoW.Data;
using RepositoryPatternUoW.Data.Repositories;
using RepositoryPatternUoW.Domain;

namespace RepositoryPatternUoW.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
      
        private readonly ILogger<DepartamentoController> _logger;
        //private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IUnitOfWork _uow;

        public DepartamentoController(
            ILogger<DepartamentoController> logger,
            //IDepartamentoRepository departamentoRepository,
            IUnitOfWork uow)
        {
            _logger = logger;
            //_departamentoRepository = departamentoRepository;
            _uow = uow;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _uow.DepartamentoRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateDepartamento(Departamento departamento)
        {
            _uow.DepartamentoRepository.Add(departamento);
            _uow.Commit();

            return Ok(departamento);
        }

        //Departamento/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveDepartamentoAsync(int id)
        {
            var departamento = await _uow.DepartamentoRepository.GetByIdAsync(id);
            _uow.DepartamentoRepository.Remove(departamento);

            _uow.Commit();

            return Ok(departamento);
        }

        //Departamento/1
        [HttpGet]
        public async Task<IActionResult> ConsultarDepartamentoAsync([FromQuery] string descricao)
        {
            var departamentos = await _uow.DepartamentoRepository.GetDataAsync(
                p => p.Descricao.Contains(descricao),
                p => p.Include(c => c.Colaboradores),
                take: 2);

            return Ok(departamentos);
        }

    }
}