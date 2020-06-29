using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NovaEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NovaEscola.Core.Domains.Configuration
{
    public class EscolaConfiguration : IEntityTypeConfiguration<Escola>
    {
        public static Escola[] escolas =
        {
            new Escola
                 {
                     Id = 1,
                     Name = "Escola ABC",
                     Descricao = "Escola Municipal ABC",
                     DataFundacao = new DateTime(1980, 1, 1),
                     Cep = 20540030,
                     Lougradouro = "Rua Severino Brandão",
                     Numero = "41",
                     Complemento = "Apto 201 F",
                     Bairro = "Tijuca",
                     Cidade = "Rio de Janeiro",
                     Uf = "RJ",
                     Pais = "Brasil",
                     Email = "contato@escolaabc.com.br",
                     TelFixo = "2125692407",
                     TelMovel = "21995132912",
                     Ativo = true,
                 },
                 new Escola
                 {
                    Id = 2,
                    Name = "Escola DEF",
                    Descricao = "Escola Municipal DEF",
                    DataFundacao = new DateTime(1981, 2, 2),
                    Cep = 20540030,
                    Lougradouro = "Rua Barão de Mesquita",
                    Numero = "134",
                    Complemento = "Apto 301",
                    Bairro = "Tijuca",
                    Cidade = "Rio de Janeiro",
                    Uf = "RJ",
                    Pais = "Brasil",
                    Email = "contato@escoladef.com.br",
                    TelFixo = "2125692407",
                    TelMovel = "21995132912",
                    Ativo = false,
                 }
        };
        public EscolaConfiguration()
        {
            
        }
        public void Configure(EntityTypeBuilder<Escola> builder)
        {
            builder.Property(e => e.Ativo)
                .IsRequired()
                .HasDefaultValueSql("TRUE");

            builder.Property(e => e.DataFundacao)
            .HasColumnType("timestamp without time zone");

            builder.Property(e => e.DataInclusao)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_DATE");
            
            builder.Property(e => e.DataModificacao)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_DATE");

            builder.ToTable("Escolas");

            builder.HasData
            (
                EscolaConfiguration.escolas
            );
        }
    }
}
