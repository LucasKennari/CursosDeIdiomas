using CursoDeIdiomas.Models;

namespace CursoDeIdiomas.DTOs
{
    public class TurmaResponse
    {
        public int Codigo { get; set; }
        public string Nivel { get; set; }
        public ICollection<AlunosEntity> Alunos { get; set; } = new List<AlunosEntity>();

        public static implicit operator TurmaResponse(TurmasEntity turma)
        {
            return new TurmaResponse
            {
                Codigo = turma.Codigo,
                Nivel = turma.Nivel,
                Alunos = turma.AlunoTurmas.Select(a => a.Aluno).ToList()
            };
        }
    }

}
