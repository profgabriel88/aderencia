﻿// <auto-generated />
using ApiEscola.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiEscola.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20241114184129_relacao-aluno-curso")]
    partial class relacaoalunocurso
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ApiEscola.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
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

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("ApiEscola.Models.AlunoCurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlunosId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursosId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Nota")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AlunosId");

                    b.HasIndex("CursosId");

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

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("ApiEscola.Models.AlunoCurso", b =>
                {
                    b.HasOne("ApiEscola.Models.Aluno", null)
                        .WithMany()
                        .HasForeignKey("AlunosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiEscola.Models.Curso", null)
                        .WithMany()
                        .HasForeignKey("CursosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
