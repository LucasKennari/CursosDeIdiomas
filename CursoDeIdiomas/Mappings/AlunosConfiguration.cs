using CursoDeIdiomas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CursoDeIdiomas.Mappings
{
    public class AlunosConfiguration : IEntityTypeConfiguration<AlunosEntity>
    {
        public void Configure(EntityTypeBuilder<AlunosEntity> builder)
        {
            builder.ToTable("Alunos");

            builder.Property(a => a.Id);
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Id).IsUnique();

            builder.HasMany(a => a.AlunoTurmas)
                     .WithOne(at => at.Aluno)
                     .HasForeignKey(at => at.AlunoId);

            builder.Property(a => a.Nome).IsRequired().HasColumnType("varchar(150)").HasMaxLength(150);

            builder.Property(a => a.Cpf).IsRequired().HasColumnType("char(11)").HasMaxLength(11);
            builder.HasIndex(a => a.Cpf).IsUnique();

            builder.Property(a => a.Email).IsRequired().HasColumnType("varchar(150)");


        }
    }
}
