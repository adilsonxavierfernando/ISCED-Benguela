﻿// <auto-generated />
using System;
using ISCED_Benguela.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    [DbContext(typeof(IscedDbContext))]
    [Migration("20240525180903_Coluna de aprovado")]
    partial class Colunadeaprovado
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("ISCED_Benguela.Modelos.Arquivo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Extensao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Ficheiro")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.HasKey("ID");

                    b.ToTable("Arquivos");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Bilhete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bilhetes");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Capa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Extensao")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Ficheiro")
                        .HasColumnType("BLOB");

                    b.HasKey("ID");

                    b.ToTable("Capas");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Comentarios", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<int>("EstudanteID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MateriaID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Respondido")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("EstudanteID");

                    b.HasIndex("MateriaID");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Contactos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Cursos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ArquivoCursoID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CapaCursoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartamentoID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int>("FormacaoID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeCurso")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ArquivoCursoID");

                    b.HasIndex("CapaCursoID");

                    b.HasIndex("DepartamentoID");

                    b.HasIndex("FormacaoID");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Departamentos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChefedepartamentoID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeDepartamento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isPrincipal")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ChefedepartamentoID");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Disciplina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartamentoID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeDisciplina")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("DepartamentoID");

                    b.ToTable("Disicplina");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Enderecos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .HasColumnType("TEXT");

                    b.Property<string>("Localizacao")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Estudantes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Aprovado")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactosID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursosID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RegisterLoginID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("dataNascimento")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ContactosID");

                    b.HasIndex("CursosID");

                    b.HasIndex("RegisterLoginID");

                    b.ToTable("Estudantes");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Feedbacks", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Assunto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("feedbacks");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Formacao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeFormacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Formacao");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.GradeCurricular", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArquivoID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ArquivoID");

                    b.ToTable("GradeCurricular");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.InfoSite", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnderecoID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Geomap")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RedesID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ContactoID");

                    b.HasIndex("EnderecoID");

                    b.HasIndex("RedesID");

                    b.ToTable("InfoSites");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Materia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArquivoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CapaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepartamentosID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplinaID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfessorID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ArquivoID");

                    b.HasIndex("CapaID");

                    b.HasIndex("DepartamentosID");

                    b.HasIndex("DisciplinaID");

                    b.HasIndex("ProfessorID");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.MembroDireccao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FotoID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeFuncionario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RedesSociaisID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("FotoID");

                    b.HasIndex("RedesSociaisID");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Professores", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Aprovado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bibliografia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ContactoID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepartamentosID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FotoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoradaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RedesID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RegisterLoginID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ContactoID");

                    b.HasIndex("DepartamentosID");

                    b.HasIndex("FotoID");

                    b.HasIndex("MoradaID");

                    b.HasIndex("RedesID");

                    b.HasIndex("RegisterLoginID");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.RedesSociais", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Facebook")
                        .HasColumnType("TEXT");

                    b.Property<string>("Instagram")
                        .HasColumnType("TEXT");

                    b.Property<string>("Linkedin")
                        .HasColumnType("TEXT");

                    b.Property<string>("Youtube")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("RedeSociais");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Registro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Register");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Reposta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComentarioID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfessorID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Resposta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ComentarioID");

                    b.HasIndex("ProfessorID");

                    b.ToTable("Respostas");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RegisterLoginID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("RegisterLoginID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Comentarios", b =>
                {
                    b.HasOne("ISCED_Benguela.Modelos.Estudantes", "Estudante")
                        .WithMany()
                        .HasForeignKey("EstudanteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.Materia", "Materia")
                        .WithMany("Comentarios")
                        .HasForeignKey("MateriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estudante");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Cursos", b =>
                {
                    b.HasOne("ISCED_Benguela.Modelos.Arquivo", "ArquivoCurso")
                        .WithMany()
                        .HasForeignKey("ArquivoCursoID");

                    b.HasOne("ISCED_Benguela.Modelos.Capa", "CapaCurso")
                        .WithMany()
                        .HasForeignKey("CapaCursoID");

                    b.HasOne("ISCED_Benguela.Modelos.Departamentos", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.Formacao", "Formacao")
                        .WithMany("Cursos")
                        .HasForeignKey("FormacaoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArquivoCurso");

                    b.Navigation("CapaCurso");

                    b.Navigation("Departamento");

                    b.Navigation("Formacao");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Departamentos", b =>
                {
                    b.HasOne("ISCED_Benguela.Modelos.MembroDireccao", "ChefeDepartamento")
                        .WithMany()
                        .HasForeignKey("ChefedepartamentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChefeDepartamento");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Disciplina", b =>
                {
                    b.HasOne("ISCED_Benguela.Modelos.Departamentos", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Estudantes", b =>
                {
                    b.HasOne("ISCED_Benguela.Modelos.Contactos", "Contactos")
                        .WithMany()
                        .HasForeignKey("ContactosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.Cursos", "Curso")
                        .WithMany()
                        .HasForeignKey("CursosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.Registro", "RegisterLogin")
                        .WithMany()
                        .HasForeignKey("RegisterLoginID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contactos");

                    b.Navigation("Curso");

                    b.Navigation("RegisterLogin");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.GradeCurricular", b =>
                {
                    b.HasOne("ISCED_Benguela.Modelos.Arquivo", "Arquivo")
                        .WithMany()
                        .HasForeignKey("ArquivoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arquivo");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.InfoSite", b =>
                {
                    b.HasOne("ISCED_Benguela.Modelos.Contactos", "Contacto")
                        .WithMany()
                        .HasForeignKey("ContactoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.Enderecos", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.RedesSociais", "Redes")
                        .WithMany()
                        .HasForeignKey("RedesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contacto");

                    b.Navigation("Endereco");

                    b.Navigation("Redes");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Materia", b =>
                {
                    b.HasOne("ISCED_Benguela.Modelos.Arquivo", "Arquivo")
                        .WithMany()
                        .HasForeignKey("ArquivoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.Capa", "Capa")
                        .WithMany()
                        .HasForeignKey("CapaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.Departamentos", "Departamentos")
                        .WithMany()
                        .HasForeignKey("DepartamentosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.Disciplina", "Disciplina")
                        .WithMany()
                        .HasForeignKey("DisciplinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.Professores", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arquivo");

                    b.Navigation("Capa");

                    b.Navigation("Departamentos");

                    b.Navigation("Disciplina");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.MembroDireccao", b =>
                {
                    b.HasOne("ISCED_Benguela.Modelos.Capa", "Foto")
                        .WithMany()
                        .HasForeignKey("FotoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.RedesSociais", "RedesSociais")
                        .WithMany()
                        .HasForeignKey("RedesSociaisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Foto");

                    b.Navigation("RedesSociais");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Professores", b =>
                {
                    b.HasOne("ISCED_Benguela.Modelos.Contactos", "Contacto")
                        .WithMany()
                        .HasForeignKey("ContactoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.Departamentos", "Departamentos")
                        .WithMany()
                        .HasForeignKey("DepartamentosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.Capa", "Foto")
                        .WithMany()
                        .HasForeignKey("FotoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.Enderecos", "Morada")
                        .WithMany()
                        .HasForeignKey("MoradaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.RedesSociais", "Redes")
                        .WithMany()
                        .HasForeignKey("RedesID");

                    b.HasOne("ISCED_Benguela.Modelos.Registro", "RegisterLogin")
                        .WithMany()
                        .HasForeignKey("RegisterLoginID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contacto");

                    b.Navigation("Departamentos");

                    b.Navigation("Foto");

                    b.Navigation("Morada");

                    b.Navigation("Redes");

                    b.Navigation("RegisterLogin");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Reposta", b =>
                {
                    b.HasOne("ISCED_Benguela.Modelos.Comentarios", "Comentario")
                        .WithMany("Respostas")
                        .HasForeignKey("ComentarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCED_Benguela.Modelos.Professores", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comentario");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Usuario", b =>
                {
                    b.HasOne("ISCED_Benguela.Modelos.Registro", "RegisterLogin")
                        .WithMany()
                        .HasForeignKey("RegisterLoginID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegisterLogin");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Comentarios", b =>
                {
                    b.Navigation("Respostas");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Formacao", b =>
                {
                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("ISCED_Benguela.Modelos.Materia", b =>
                {
                    b.Navigation("Comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}
