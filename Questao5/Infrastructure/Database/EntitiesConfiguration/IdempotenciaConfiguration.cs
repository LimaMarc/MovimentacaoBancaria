using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questao5.Domain.Entities.UserCase;

namespace Questao5.Infrastructure.Database.EntitiesConfiguration
{
    public class IdempotenciaConfiguration : IEntityTypeConfiguration<Idempotencia>
    {

        public void Configure(EntityTypeBuilder<Idempotencia> builder)
        {
            builder.HasKey(t => t.ChaveIdempotencia);
            builder.Property(n => n.Requisicao).HasMaxLength(1000);
            builder.Property(n => n.Resultado).HasMaxLength(1000);
        }
    }
}
