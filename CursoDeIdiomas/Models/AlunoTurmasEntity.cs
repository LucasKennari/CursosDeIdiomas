namespace CursoDeIdiomas.Models
{
    public class AlunoTurmasEntity
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public AlunosEntity Aluno { get; set; }
        public int TurmaId { get; set; }
        public TurmasEntity Turma { get; set; }

        public AlunoTurmasEntity() {
          
        }

        public AlunoTurmasEntity(int alunoId, int turmaId)
        {
           
            AlunoId = alunoId;
            TurmaId = turmaId;
        }
    }
}
