namespace CursoDeIdiomas.Models
{
    public class AlunosEntity
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }

        private AlunosEntity()
        {

        }
        public AlunosEntity(int id, string nome, string cpf, string email)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
        }
    }

}