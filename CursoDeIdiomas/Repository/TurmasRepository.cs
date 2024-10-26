using CursoDeIdiomas.Data;
using CursoDeIdiomas.DTOs;
using CursoDeIdiomas.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CursoDeIdiomas.Repository
{
    public class TurmasRepository : BaseRepository<TurmasEntity>
    {
        private readonly CursoDeIdiomasContext _context;

        public TurmasRepository(CursoDeIdiomasContext context) : base(context)
        {
            _context = context;
        }
        public async override Task<IQueryable<TurmasEntity>> GetAllAsync()
        {
            var turmas = await _context.Turmas
                .Include(t => t.AlunoTurmas)
                .ThenInclude(at => at.Aluno)
                .ToListAsync();

            return turmas.AsQueryable();
        }
        public async Task<IQueryable<TurmasEntity>> GetTurmaByCodigo(int codigo)
        {
            var turma = await _context.Turmas.Where(t => t.Codigo == codigo).ToListAsync();
            return turma.AsQueryable();
        }

        public async Task<IQueryable<TurmasEntity>> AddAsync(TurmaRequest turma)
        {
            var turmaResult = await _context.Alunos.Where(a => a.Id == turma.AlunoId).FirstOrDefaultAsync();

            if (turmaResult == null)
            {
                throw new ArgumentException("Turma not found!");
            }
            Console.WriteLine(turmaResult);
            var AlunoTurmaEntity = new AlunoTurmasEntity(turma.AlunoId, turma.Codigo);
            await _context.AlunoTurma.AddAsync(AlunoTurmaEntity);
            await base.AddAsync(turma);
            return (IQueryable<TurmasEntity>)turma;
        }
        

        public async Task<TurmasEntity> UpdateAsync(int id, TurmasEntity turma)
        {
            var turmaResult = await _context.Turmas.AsQueryable().FirstOrDefaultAsync(t => t.Id == id);
            if (turmaResult == null)
            {
                return null;
            }
           turmaResult.Update(turma.Codigo, turma.Nivel, turma.AlunoId);
            base.Update(turmaResult);
            return turmaResult;
        }
        public async Task<TurmasEntity> DeleteAsync(int id)
        {
            var turma = await _context.Turmas.FirstOrDefaultAsync(t => t.Id == id);
            if (turma != null)
            {
                _context.Turmas.Remove(turma);
                base.Delete(turma);
               
                return turma;
            }
            return null;
        }

    }

}
