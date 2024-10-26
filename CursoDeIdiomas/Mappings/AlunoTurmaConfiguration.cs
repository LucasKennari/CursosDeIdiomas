using CursoDeIdiomas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoDeIdiomas.Mappings
{
    public class AlunoTurmaConfiguration : IEntityTypeConfiguration<AlunoTurmasEntity>
    {
        public void Configure(EntityTypeBuilder<AlunoTurmasEntity> builder)
        {
            builder.ToTable("AlunoTurmas");

            builder.HasKey(at => new { at.AlunoId, at.TurmaId });
        }
    }
}
