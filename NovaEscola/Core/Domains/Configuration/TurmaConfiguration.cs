using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovaEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Core.Domains.Configuration
{
    
    public class TurmaConfiguration : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.Property(e => e.Ativo)
                .IsRequired()
                .HasDefaultValueSql("TRUE");
            
            builder.Property(e => e.DataInclusao)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_DATE");

            builder.Property(e => e.DataModificacao)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_DATE");

            builder.ToTable("Turmas");

            builder.HasData
            (
                 new Turma
                 {
                     Id = 1,
                     NomeTurma = "101",
                     Descricao = "Turma 101",
                     QuantidadeVagas = 30,
                     SerieId = SerieConfiguration.series[0].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Manha
                 },                 
                 new Turma
                 {
                     Id = 2,
                     NomeTurma = "201",
                     Descricao = "Turma 201",
                     QuantidadeVagas = 30,
                     SerieId = SerieConfiguration.series[1].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Manha
                 },                 
                 new Turma
                 {
                     Id = 3,
                     NomeTurma = "301",
                     Descricao = "Turma 301",
                     QuantidadeVagas = 30,
                     SerieId = SerieConfiguration.series[2].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Manha
                 },
                 new Turma
                 {
                     Id = 4,
                     NomeTurma = "401",
                     Descricao = "Turma 401",
                     QuantidadeVagas = 30,
                     SerieId = SerieConfiguration.series[3].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Manha
                 },                 
                 new Turma
                 {
                     Id = 5,
                     NomeTurma = "501",
                     Descricao = "Turma 501",
                     QuantidadeVagas = 30,
                     SerieId = SerieConfiguration.series[4].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Manha
                 },
                 new Turma
                 {
                     Id = 6,
                     NomeTurma = "601",
                     Descricao = "Turma 601",
                     QuantidadeVagas = 30,
                     SerieId = SerieConfiguration.series[5].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Manha
                 },
                 new Turma
                 {
                     Id = 7,
                     NomeTurma = "701",
                     Descricao = "Turma 701",
                     QuantidadeVagas = 30,
                     SerieId = SerieConfiguration.series[6].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Manha
                 },
                 new Turma
                 {
                     Id = 8,
                     NomeTurma = "801",
                     Descricao = "Turma 801",
                     QuantidadeVagas = 30,
                     SerieId = SerieConfiguration.series[7].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Manha
                 },
                 new Turma
                 {
                     Id = 9,
                     NomeTurma = "901",
                     Descricao = "Turma 901",
                     QuantidadeVagas = 30,
                     SerieId = SerieConfiguration.series[8].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Manha
                 },
                 new Turma
                 {
                     Id = 10,
                     NomeTurma = "1001",
                     Descricao = "Turma 1001",
                     QuantidadeVagas = 35,
                     SerieId = SerieConfiguration.series[9].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Tarde
                 },
                 new Turma
                 {
                     Id = 11,
                     NomeTurma = "1002",
                     Descricao = "Turma 1002",
                     QuantidadeVagas = 35,
                     SerieId = SerieConfiguration.series[9].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Tarde
                 },
                 new Turma
                 {
                     Id = 12,
                     NomeTurma = "2001",
                     Descricao = "Turma 2001",
                     QuantidadeVagas = 35,
                     SerieId = SerieConfiguration.series[10].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Tarde
                 },
                 new Turma
                 {
                     Id = 13,
                     NomeTurma = "2002",
                     Descricao = "Turma 2002",
                     QuantidadeVagas = 35,
                     SerieId = SerieConfiguration.series[10].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Tarde
                 },
                 new Turma
                 {
                     Id = 14,
                     NomeTurma = "3001",
                     Descricao = "Turma 3001",
                     QuantidadeVagas = 35,
                     SerieId = SerieConfiguration.series[10].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Tarde
                 },
                 new Turma
                 {
                     Id = 15,
                     NomeTurma = "3002",
                     Descricao = "Turma 3002",
                     QuantidadeVagas = 35,
                     SerieId = SerieConfiguration.series[10].Id,
                     EscolaId = EscolaConfiguration.escolas[0].Id,
                     Ativo = true,
                     Turno = Turno.Tarde
                 }
            );
        }
    }
}
