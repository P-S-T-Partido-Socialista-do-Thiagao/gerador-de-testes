using GeradorDeTestes.Dominio.ModuloMateria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDeTestes.Infraestrutura.Orm.ModuloMateria;

public class MapeadorMateriaEmOrm : IEntityTypeConfiguration<Materia>
{
    public void Configure(EntityTypeBuilder<Materia> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Serie)
            .IsRequired();

        builder.Property(x => x.Nome)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasOne(x => x.Disciplina)
            .WithMany(d => d.Materias)
            .IsRequired();
    }
}
