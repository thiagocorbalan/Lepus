using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using LepusAPI.Models;
using LepusAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LepusAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class IncomesController : ControllerBase
    {
        IncomesRepository _incomesRepository;
        public IncomesController(IncomesRepository incomesRepository)
        {
            _incomesRepository = incomesRepository;
        }

        [HttpGet("{userName}/{year}/{month}")]
        public async Task<IEnumerable<Income>> Get(string userName, int year, int month)
        {
            return await _incomesRepository.Get(userName, year, month);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Income income)
        {
            await _incomesRepository.Post(income);
            return Ok();
        }

        [HttpPut("{IncomeId}")]
        public async Task<IActionResult> Put(string incomeId, [FromBody]IncomeDto IncomeDto)
        {
            await _incomesRepository.Put(incomeId, IncomeDto);
            return Ok();
        }

        [HttpDelete("{IncomeId}")]
        public async Task<IActionResult> Delete(string incomeId)
        {
            await _incomesRepository.Delete(incomeId);
            return Ok();
        }
    }
}