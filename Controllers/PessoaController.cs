using DesafioBackEnd.Dtos;
using DesafioBackEnd.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackEnd.Controllers
{
    [Route("pessoas")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly ISearchPessoasUseCase _searchPessoasUseCase;
        private readonly IGetPessoaByIdUseCase _getPessoaByIdUseCase;
        private readonly ICreatePessoaUseCase _createPessoaUseCase;

        public PessoaController(
            ISearchPessoasUseCase searchPessoasUseCase,
            IGetPessoaByIdUseCase getPessoaByIdUseCase,
            ICreatePessoaUseCase createPessoaUseCase
        )
        {
            _searchPessoasUseCase = searchPessoasUseCase;
            _getPessoaByIdUseCase = getPessoaByIdUseCase;
            _createPessoaUseCase = createPessoaUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery(Name = "t")] string searchCriteria)
        {
            var response = await _searchPessoasUseCase.ExecuteAsync(searchCriteria);
            return Ok(response.Data);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _getPessoaByIdUseCase.ExecuteAsync(id);

            if (response.HasError)
                return NotFound();

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePessoaDto createPessoaDto)
        {
            var response = await _createPessoaUseCase.ExecuteAsync(createPessoaDto);

            if (response.HasError)
                return UnprocessableEntity();

            return CreatedAtAction(nameof(Get), new { Id = response.Data.Id }, response.Data);
        }
    }
}
