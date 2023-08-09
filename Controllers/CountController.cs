using DesafioBackEnd.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackEnd.Controllers
{
    [Route("contagem-pessoas")]
    [ApiController]
    public class CountController : ControllerBase
    {
        private readonly ICountPessoasUseCase _countPessoasUseCase;

        public CountController(ICountPessoasUseCase countPessoasUseCase)
        {
            _countPessoasUseCase = countPessoasUseCase;
        }

        [HttpGet()]
        public async Task<IActionResult> Count()
        {
            var response = await _countPessoasUseCase.ExecuteAsync();
            return Ok(response);
        }
    }
}
