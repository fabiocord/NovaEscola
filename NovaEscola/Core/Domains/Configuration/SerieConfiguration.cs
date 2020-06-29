using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovaEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Core.Domains.Configuration
{
    public class SerieConfiguration : IEntityTypeConfiguration<Serie>
    {
        public static Serie[] series = {
                 new Serie
                 {
                     Id = 1,
                     Nome = "1º ano",
                     Ensino = Ensino.Fundamental
                 },
                 new Serie
                 {
                     Id = 2,
                     Nome = "2º ano",
                     Ensino = Ensino.Fundamental
                 },
                 new Serie
                 {
                     Id = 3,
                     Nome = "3º ano",
                     Ensino = Ensino.Fundamental
                 },
                 new Serie
                 {
                     Id = 4,
                     Nome = "4º ano",
                     Ensino = Ensino.Fundamental
                 },
                 new Serie
                 {
                     Id = 5,
                     Nome = "5º ano",
                     Ensino = Ensino.Fundamental
                 },
                 new Serie
                 {
                     Id = 6,
                     Nome = "6º ano",
                     Ensino = Ensino.Fundamental
                 },
                 new Serie
                 {
                     Id = 7,
                     Nome = "7º ano",
                     Ensino = Ensino.Fundamental
                 },
                 new Serie
                 {
                     Id = 8,
                     Nome = "8º ano",
                     Ensino = Ensino.Fundamental
                 },
                 new Serie
                 {
                     Id = 9,
                     Nome = "9º ano",
                     Ensino = Ensino.Fundamental
                 },
                 new Serie
                 {
                     Id = 10,
                     Nome = "1º ano",
                     Ensino = Ensino.Medio
                 },
                 new Serie
                 {
                     Id = 11,
                     Nome = "2º ano",
                     Ensino = Ensino.Medio
                 },
                 new Serie
                 {
                     Id = 12,
                     Nome = "3º ano",
                     Ensino = Ensino.Medio
                 }
           };
        public void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder.ToTable("Series");
     
            builder.HasData
            (
                SerieConfiguration.series
            );
        }
    }
}
