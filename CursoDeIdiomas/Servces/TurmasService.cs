using CursoDeIdiomas.DTOs;
using CursoDeIdiomas.Models;
using CursoDeIdiomas.Repository;

namespace CursoDeIdiomas.Servces
{
    public class TurmasService
    {
        private readonly TurmasRepository _turmasRepository;
        public TurmasService(TurmasRepository turmasRepository)
        {
            _turmasRepository = turmasRepository;
        }
        public async Task<List<TurmaResponse>> GetAllAsync()
        {
            var turmas = await _turmasRepository.GetAllAsync();

            if (turmas == null)
            {
                return null;
            }
            return turmas.Select(turma => (TurmaResponse)turma).ToList();
            /*  var turmaResponse = turmas.Select(turma => new TurmaResponse
              {
                  Codigo = turma.Codigo,
                  Nivel = turma.Nivel,
                  Alunos = turma.Alunos.Select(aluno => new AlunoResponse
                  {
                      Id = aluno.,
                      Nome = aluno,
                      Cpf = aluno.Cpf,
                      Email = aluno.Email
                  }).ToList()
              }).ToList();


              return turmaResponse;
            */
        }
        public async Task<TurmasEntity> AddNewAluno(TurmaRequest turmaRequest)
        {
      

            return await _turmasRepository.AddAsync(turmaRequest);
        }
    }
}
