using CursoDeIdiomas.DTOs;
using CursoDeIdiomas.Models;
using CursoDeIdiomas.Repository;
using CursoDeIdiomas.Servces;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIdiomas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmasController : ControllerBase
    {
        private readonly TurmasService _turmasService;
        public TurmasController(TurmasService turmasService)
        {
            _turmasService = turmasService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTurmas()
        {
            var turmas = await _turmasService.GetAllAsync();
            return Ok(turmas);
        }
        /*
                [HttpGet("{id}")]
                public async Task<IActionResult> GetById(int id)
                {
                    var turma = await _turmasService.GetByIdAsync(id);
                    if (turma == null)
                    {
                        return NotFound();
                    }
                    return Ok(turma);
                }
        */
                [HttpPost]
                public async Task<IActionResult> Post([FromBody] TurmaRequest turmaRequest)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);  // Retorna erros de validação
                    }
                    TurmasEntity turma = turmaRequest;
                    var turmaAdded = await _turmasService.AddNewAluno(turmaRequest);

                    if (turmaAdded == null)
                    {
                        return BadRequest("The Turma was not created");
                    }
                    return Ok(turma);
                }
        /*
                [HttpPut("{id}")]
                public async Task<IActionResult> Put(int id, [FromBody] TurmaRequest turmaDTO)
                {
                    var result = await _turmasRepository.UpdateAsync(id, turmaDTO);

                    if (result == null)
                    {
                        return NotFound();
                    }
                    return Ok();
                }

                [HttpDelete("{id}")]
                public async Task<IActionResult> Delete(int id)
                {

                    var result = await _turmasRepository.DeleteAsync(id);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return Ok();
                }
        */
    }

}
