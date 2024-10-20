using CursoDeIdiomas.Mappings;
using CursoDeIdiomas.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CursoDeIdiomas.Data
{
    public class CursoDeIdiomasContext : DbContext
    {
        public DbSet<AlunosEntity> Alunos { get; set; }
        public DbSet<TurmasEntity> Turmas { get; set; }
        public CursoDeIdiomasContext(DbContextOptions<CursoDeIdiomasContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
