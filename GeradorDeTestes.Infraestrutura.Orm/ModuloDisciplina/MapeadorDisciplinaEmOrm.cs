using GeradorDeTestes.Dominio.ModuloDisciplina;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GeradorDeTestes.Infraestrutura.Orm.Compartilhado;
namespace GeradorDeTestes.Infraestrutura.Orm.ModuloDisciplina;
public class MapeadorDisciplinaEmOrm : IEntityTypeConfiguration<Disciplina>
{
    public void Configure(EntityTypeBuilder<Disciplina> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Nome)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasMany(x => x.Materias)
            .WithOne(m => m.Disciplina)
            .IsRequired();
    }
}
