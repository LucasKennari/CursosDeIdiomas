namespace CursoDeIdiomas.Models
{
    public class TurmasEntity
    {
        public int Id { get; private set; }

        public int Codigo { get; private set; }
        public string Nivel { get; private set; }
        public int AlunoID { get; private set; }
        public  AlunosEntity Alunos { get; private set; }
        public TurmasEntity() { }

        public TurmasEntity(int id, int codigo, string nivel, int alunoId)
        {
            Id = id;
            Codigo = codigo;
            Nivel = nivel;
            AlunoID = alunoId;
        }
    }
}
