using System.Collections.Generic;
using System.Linq;
using ApiEscola.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEscola.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext (DbContextOptions<ApiContext> options) : base (options) {}

        public DbSet <Aluno> Alunos { get; set; }
        public DbSet <Curso> Cursos { get; set; }
        public DbSet <AlunoCurso> AlunoCurso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoCurso>()
                .HasKey(ac => new {ac.AlunosId, ac.CursosId});
        }
    }
}