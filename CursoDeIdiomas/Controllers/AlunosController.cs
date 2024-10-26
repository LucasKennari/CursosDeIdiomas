using CursoDeIdiomas.Models;
using CursoDeIdiomas.Repository;
using CursoDeIdiomas.Servces;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIdiomas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {


        private readonly AlunosService _alunoService;
        public AlunosController(AlunosService alunoService)
        {
           
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlunos()
        {
            try
            {
                var alunosResponse = await _alunoService.GetAllAsync();

                if (alunosResponse == null)
                {
                    return NotFound("Users not found");
                }
                return Ok(alunosResponse);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }


        }
        
        [HttpPost]
        public async Task<IActionResult> AlunoRegister([FromBody] AlunosEntity aluno)
        {
            try
            {
                if (aluno == null)
                {
                    return BadRequest("Data aluno is null");
                }

                var newAluno = await _alunoService.AddNewAluno(aluno);
                return Created();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }


        }
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AlunosEntity? alunoRequest)
        {
            try
            {
                if (alunoRequest == null)
                {
                    return NotFound();
                }
                var alunoId = await _alunosRepository.GetByIdAsync(id);

                if (alunoId == null)
                {
                    return NotFound();
                }

                await _alunosRepository.UpdateAsync(alunoId.Id, alunoRequest);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
     

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == null) return NotFound();

                var alunoId = await _alunosRepository.GetByIdAsync(id);

                if (alunoId == null) return NotFound();

                await _alunosRepository.DeleteAsync(alunoId.Id);

                return Ok();

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
      */
    }
}
