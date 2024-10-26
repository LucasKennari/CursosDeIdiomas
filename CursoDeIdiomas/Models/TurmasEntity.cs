using CursoDeIdiomas.DTOs;
using System.Text.Json.Serialization;

namespace CursoDeIdiomas.Models
{
    public class TurmasEntity
    {
        public int Id { get; private set; }

        public int Codigo { get; private set; }
        public string Nivel { get; private set; }

        public int AlunoId { get; private set; }

        public ICollection<AlunoTurmasEntity> AlunoTurmas { get; private set; }

        public TurmasEntity() { }

        public TurmasEntity(int id, int codigo, string nivel, int alunoId)
        {
            Id = id;
            Codigo = codigo;
            Nivel = nivel;
            AlunoId = alunoId;
            AlunoTurmas = new List<AlunoTurmasEntity>();

        }

      
        public static implicit operator TurmasEntity(TurmaRequest turma)
        {
            return new TurmasEntity
            {
                Codigo = turma.Codigo,
                Nivel = turma.Nivel,
                AlunoId = turma.AlunoId
            };
        }

        public void Update(int codigo, string nivel, int alunoId)
        {
            Codigo = codigo;
            Nivel = nivel;
            AlunoId = alunoId;
        }
    }
}
