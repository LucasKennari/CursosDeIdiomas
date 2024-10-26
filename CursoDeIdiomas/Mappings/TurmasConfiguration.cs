using CursoDeIdiomas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoDeIdiomas.Mappings
{
    public class TurmasConfiguration : IEntityTypeConfiguration<TurmasEntity>
    {
        public void Configure(EntityTypeBuilder<TurmasEntity> builder)
        {
            builder.ToTable("Turmas");

            builder.HasMany(t => t.AlunoTurmas)
                .WithOne(at => at.Turma)
                .HasForeignKey(at => at.TurmaId);

            builder.Property(t => t.Codigo).IsRequired();
            builder.Property(t => t.Nivel).IsRequired();
            builder.Property(t => t.AlunoId).IsRequired();


        }
    }
}