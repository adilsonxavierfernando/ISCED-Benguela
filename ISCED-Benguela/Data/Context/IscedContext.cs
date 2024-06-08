using ISCED_Benguela.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ISCED_Benguela.Data.Context
{
    public class IscedDbContext:DbContext
    {
        public IscedDbContext(DbContextOptions<IscedDbContext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<Capa> Capas { get; set; }
        public DbSet<Comentarios> Comentario { get; set; }
        public DbSet<Contactos> Contactos { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Disciplina> Disicplina { get; set; }
        public DbSet<Enderecos> Endereco { get; set; }
        public DbSet<Estudantes> Estudantes { get; set; }
        public DbSet<Feedbacks> feedbacks { get; set; }
        public DbSet<Formacao> Formacao { get; set; }
        public DbSet<GradeCurricular> GradeCurricular { get; set; }
        public DbSet<InfoSite> InfoSites { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Professores> Professores { get; set; }
        public DbSet<RedesSociais> RedeSociais { get; set; }
        public DbSet<Registro> Register { get; set; }
        public DbSet<Reposta> Respostas { get; set; }
        public DbSet<Bilhete> Bilhetes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<MembroDireccao> Funcionarios { get; set; }
        public DbSet<Banner> Banner { get; set; }
    }
}
