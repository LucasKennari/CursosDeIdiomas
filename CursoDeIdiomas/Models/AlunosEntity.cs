using CursoDeIdiomas.DTOs;

namespace CursoDeIdiomas.Models
{
    public class AlunosEntity
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }

        public ICollection<AlunoTurmasEntity> AlunoTurmas { get; private set; }

        private AlunosEntity()
        {
            Nome = string.Empty;
            Cpf = string.Empty;
            Email = string.Empty;
            AlunoTurmas = new List<AlunoTurmasEntity>();
        }

        public AlunosEntity(int id, string nome, string cpf, string email)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            AlunoTurmas = new List<AlunoTurmasEntity>();
        }


        public void Update(string nome, string cpf, string email)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
        }
       

        internal object Select(Func<object, AlunoResponse> value)
        {
            throw new NotImplementedException();
        }
    }
}