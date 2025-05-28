using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities.Business;
using Questao5.Domain.Entities.UserCase;
using Questao5.Infrastructure.Database.EntitiesConfiguration;

namespace Questao5.Infrastructure.Database.Context
{
    public class DbContextConfig:DbContext
    {
       public DbContextConfig(DbContextOptions<DbContextConfig> options)
       : base(options)
        { }

        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Movimento> Movimento { get; set; }

        public DbSet<Idempotencia> Idempotencia { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ContaCorrenteConfiguration());
            modelBuilder.ApplyConfiguration(new MovimentoConfiguration());
            modelBuilder.ApplyConfiguration(new IdempotenciaConfiguration());
        }
    }
}
