using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Infrastructure.EntitiesConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p=> p.Id);

            builder.Property(p=>p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.ImagemUrl)
              .IsRequired()
              .HasColumnType("varchar(250)");

            builder.Property(p => p.Preco)
                .IsRequired()
                .HasPrecision(10, 2);

            //EF relations

            builder.HasOne(p => p.Categoria).
                WithMany(c => c.Produtos).
                HasForeignKey(p => p.CategoriaId);


            builder.ToTable("Produtos");
        }


    }
}
