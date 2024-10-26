using CursoDeIdiomas.Data;
using CursoDeIdiomas.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.Repository
{
    public class AlunosRepository : BaseRepository<AlunosEntity>
    {
        private readonly CursoDeIdiomasContext _context;
        public AlunosRepository(CursoDeIdiomasContext context) : base(context)
        {
            _context = context;
        }
        public async override Task<IQueryable<AlunosEntity>> GetAllAsync()
        {

            var alunos = _context.Alunos.Include(a => a.AlunoTurmas);
            return alunos; ;
        }
      
        public async override Task<AlunosEntity> GetByIdAsync(int id)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == id);
            if (aluno == null)
            {
                return null;
            }
            return aluno;
        }
      
        public async Task<AlunosEntity> AddAsync(AlunosEntity aluno)
        {
         
            await base.AddAsync(aluno);
            return aluno;
        }
        public async Task<bool> UpdateAsync(int alunoId, AlunosEntity alunoRequest)
        {
            var aluno = await _context.Alunos.FindAsync(alunoId);
            if (aluno == null)
            {
                return false;
            }
            aluno.Update(alunoRequest.Nome, alunoRequest.Cpf, alunoRequest.Email);
            base.Update(aluno);

            return true;

        }
        public async Task<bool> DeleteAsync(int alunoId)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == alunoId);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                base.Delete(aluno);
                await _context.SaveChangesAsync(); // Certifique-se de salvar as mudanças no contexto
                return true;
            }
            return false;
        }
    }

}
