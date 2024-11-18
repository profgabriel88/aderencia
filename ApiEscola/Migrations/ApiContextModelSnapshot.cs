﻿// <auto-generated />
using ApiEscola.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiEscola.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ApiEscola.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Turma")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("NomeCompleto")
                        .IsUnique();

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("ApiEscola.Models.AlunoCurso", b =>
                {
                    b.Property<int>("AlunosId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursosId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Nota")
                        .HasColumnType("TEXT");

                    b.HasKey("AlunosId", "CursosId");

                    b.ToTable("AlunoCurso");
                });

            modelBuilder.Entity("ApiEscola.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("ApiEscola.Models.Aluno", b =>
                {
                    b.HasOne("ApiEscola.Models.Curso", null)
                        .WithMany("Alunos")
                        .HasForeignKey("CursoId");
                });

            modelBuilder.Entity("ApiEscola.Models.Curso", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
