using System.Data.Entity.ModelConfiguration;
using WebApplication.Entities;

namespace WebApplication.Infra.Mapping
{
    class TreinamentoMap : EntityTypeConfiguration<Treinamento>
    {
        public TreinamentoMap()
        {
            ToTable("treinamentos");
        }
    }
}