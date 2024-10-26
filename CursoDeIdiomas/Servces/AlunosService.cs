using CursoDeIdiomas.DTOs;
using CursoDeIdiomas.Models;
using CursoDeIdiomas.Repository;

namespace CursoDeIdiomas.Servces
{
    public class AlunosService
    {
      private readonly AlunosRepository _alunosRepository;
        public AlunosService(AlunosRepository alunosRepository)
        {
            _alunosRepository = alunosRepository;
        }
        public async Task<List<AlunoResponse>> GetAllAsync()
        {
        var aluno = await _alunosRepository.GetAllAsync();

            if (aluno == null)
            {
                return null;
            }

            var alunoResponse = aluno.Select(aluno => new AlunoResponse
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Cpf = aluno.Cpf,
                Email = aluno.Email,
                Turmas = aluno.AlunoTurmas.Select(turma => new TurmaResponse
                {
                    Codigo = turma.Turma.Codigo,
                    Nivel = turma.Turma.Nivel 
                }).ToList()
            }).ToList();

            return alunoResponse;
        }
        public async Task<AlunosEntity> AddNewAluno(AlunosEntity aluno)
        {
            await _alunosRepository.AddAsync(aluno);
            return aluno;
        }
    }
}
