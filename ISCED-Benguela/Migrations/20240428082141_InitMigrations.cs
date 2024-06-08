using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class InitMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Caminho = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Capas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Caminho = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeDepartamento = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Localizacao = table.Column<string>(type: "TEXT", nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Assunto = table.Column<string>(type: "TEXT", nullable: false),
                    Mensagem = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Formacao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeFormacao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formacao", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Usuario = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GradeCurricular",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    ArquivoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeCurricular", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GradeCurricular_Arquivos_ArquivoID",
                        column: x => x.ArquivoID,
                        principalTable: "Arquivos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfoSites",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContactoID = table.Column<int>(type: "INTEGER", nullable: false),
                    EnderecoID = table.Column<int>(type: "INTEGER", nullable: false),
                    Geomap = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoSites", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InfoSites_Contactos_ContactoID",
                        column: x => x.ContactoID,
                        principalTable: "Contactos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfoSites_Endereco_EnderecoID",
                        column: x => x.EnderecoID,
                        principalTable: "Endereco",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCurso = table.Column<string>(type: "TEXT", nullable: false),
                    FormacaoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cursos_Formacao_FormacaoID",
                        column: x => x.FormacaoID,
                        principalTable: "Formacao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MoradaID = table.Column<int>(type: "INTEGER", nullable: false),
                    Bibliografia = table.Column<string>(type: "TEXT", nullable: false),
                    ContactoID = table.Column<int>(type: "INTEGER", nullable: false),
                    RegisterLoginID = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartamentosID = table.Column<int>(type: "INTEGER", nullable: false),
                    FotoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Professores_Capas_FotoID",
                        column: x => x.FotoID,
                        principalTable: "Capas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Professores_Contactos_ContactoID",
                        column: x => x.ContactoID,
                        principalTable: "Contactos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Professores_Departamentos_DepartamentosID",
                        column: x => x.DepartamentosID,
                        principalTable: "Departamentos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Professores_Endereco_MoradaID",
                        column: x => x.MoradaID,
                        principalTable: "Endereco",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Professores_Register_RegisterLoginID",
                        column: x => x.RegisterLoginID,
                        principalTable: "Register",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estudantes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    dataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nacionalidade = table.Column<string>(type: "TEXT", nullable: false),
                    ContactosID = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoID = table.Column<int>(type: "INTEGER", nullable: false),
                    RegisterLoginID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudantes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Estudantes_Contactos_ContactosID",
                        column: x => x.ContactosID,
                        principalTable: "Contactos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudantes_Cursos_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Cursos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudantes_Register_RegisterLoginID",
                        column: x => x.RegisterLoginID,
                        principalTable: "Register",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disicplina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeDisciplina = table.Column<string>(type: "TEXT", nullable: false),
                    DepartamentoID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProfessoresID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disicplina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Disicplina_Departamentos_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalTable: "Departamentos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disicplina_Professores_ProfessoresID",
                        column: x => x.ProfessoresID,
                        principalTable: "Professores",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RedeSociai",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rede = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    InfoSiteID = table.Column<int>(type: "INTEGER", nullable: true),
                    ProfessoresID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeSociai", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RedeSociai_InfoSites_InfoSiteID",
                        column: x => x.InfoSiteID,
                        principalTable: "InfoSites",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RedeSociai_Professores_ProfessoresID",
                        column: x => x.ProfessoresID,
                        principalTable: "Professores",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EstudanteID = table.Column<int>(type: "INTEGER", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comentario_Estudantes_EstudanteID",
                        column: x => x.EstudanteID,
                        principalTable: "Estudantes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Conteudo = table.Column<string>(type: "TEXT", nullable: false),
                    ArquivoID = table.Column<int>(type: "INTEGER", nullable: false),
                    CapaID = table.Column<int>(type: "INTEGER", nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DisciplinaID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProfessorID = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartamentosID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Materias_Arquivos_ArquivoID",
                        column: x => x.ArquivoID,
                        principalTable: "Arquivos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materias_Capas_CapaID",
                        column: x => x.CapaID,
                        principalTable: "Capas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materias_Departamentos_DepartamentosID",
                        column: x => x.DepartamentosID,
                        principalTable: "Departamentos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materias_Disicplina_DisciplinaID",
                        column: x => x.DisciplinaID,
                        principalTable: "Disicplina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materias_Professores_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Professores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComentarioID = table.Column<int>(type: "INTEGER", nullable: false),
                    Resposta = table.Column<string>(type: "TEXT", nullable: false),
                    ProfessorID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Respostas_Comentario_ComentarioID",
                        column: x => x.ComentarioID,
                        principalTable: "Comentario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Respostas_Professores_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Professores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_EstudanteID",
                table: "Comentario",
                column: "EstudanteID");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_FormacaoID",
                table: "Cursos",
                column: "FormacaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Disicplina_DepartamentoID",
                table: "Disicplina",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Disicplina_ProfessoresID",
                table: "Disicplina",
                column: "ProfessoresID");

            migrationBuilder.CreateIndex(
                name: "IX_Estudantes_ContactosID",
                table: "Estudantes",
                column: "ContactosID");

            migrationBuilder.CreateIndex(
                name: "IX_Estudantes_CursoID",
                table: "Estudantes",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Estudantes_RegisterLoginID",
                table: "Estudantes",
                column: "RegisterLoginID");

            migrationBuilder.CreateIndex(
                name: "IX_GradeCurricular_ArquivoID",
                table: "GradeCurricular",
                column: "ArquivoID");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSites_ContactoID",
                table: "InfoSites",
                column: "ContactoID");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSites_EnderecoID",
                table: "InfoSites",
                column: "EnderecoID");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_ArquivoID",
                table: "Materias",
                column: "ArquivoID");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_CapaID",
                table: "Materias",
                column: "CapaID");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_DepartamentosID",
                table: "Materias",
                column: "DepartamentosID");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_DisciplinaID",
                table: "Materias",
                column: "DisciplinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_ProfessorID",
                table: "Materias",
                column: "ProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_ContactoID",
                table: "Professores",
                column: "ContactoID");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_DepartamentosID",
                table: "Professores",
                column: "DepartamentosID");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_FotoID",
                table: "Professores",
                column: "FotoID");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_MoradaID",
                table: "Professores",
                column: "MoradaID");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_RegisterLoginID",
                table: "Professores",
                column: "RegisterLoginID");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSociai_InfoSiteID",
                table: "RedeSociai",
                column: "InfoSiteID");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSociai_ProfessoresID",
                table: "RedeSociai",
                column: "ProfessoresID");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_ComentarioID",
                table: "Respostas",
                column: "ComentarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_ProfessorID",
                table: "Respostas",
                column: "ProfessorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "GradeCurricular");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "RedeSociai");

            migrationBuilder.DropTable(
                name: "Respostas");

            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.DropTable(
                name: "Disicplina");

            migrationBuilder.DropTable(
                name: "InfoSites");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Estudantes");

            migrationBuilder.DropTable(
                name: "Capas");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Register");

            migrationBuilder.DropTable(
                name: "Formacao");
        }
    }
}
