using CursoDeIdiomas.Models;

namespace CursoDeIdiomas.DTOs
{
    public class AlunoResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

        public List<TurmaResponse> Turmas { get; set; }

        public static implicit operator AlunoResponse(AlunosEntity aluno)
        {
            return new AlunoResponse
            {
                Nome = aluno.Nome,
                Cpf = aluno.Cpf,
                Email = aluno.Email,
                Turmas = aluno.AlunoTurmas.Select(t => new TurmaResponse
                {
                    Codigo = t.Turma.Codigo,
                    Nivel = t.Turma.Nivel,
                    Alunos = t.Turma.AlunoTurmas.Select(a => a.Aluno).ToList()
                }).ToList()
            };
        }

        public static explicit operator AlunoResponse(TurmasEntity v)
        {
            throw new NotImplementedException();
        }
    }
}
