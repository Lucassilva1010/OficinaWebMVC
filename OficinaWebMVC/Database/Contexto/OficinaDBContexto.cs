using Microsoft.EntityFrameworkCore;
using OficinaWebMVC.Database.Entities;

namespace OficinaWebMVC.Database.Contexto;

public class OficinaDBContexto:DbContext
{
    public DbSet<Carro> Carros { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Moto> Motos { get; set; }
    public DbSet<Orcamento> Orcamentos { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<Configuracao> Configuracoes { get; set; }
   

    public OficinaDBContexto(DbContextOptions<OficinaDBContexto>options):base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(Program.connectionString,ServerVersion.AutoDetect(Program.connectionString));
        }
        base.OnConfiguring(optionsBuilder); 
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Configuracao>().HasData(new Configuracao { Id = Guid.NewGuid(), NomeConfiguracao = "PrazoOrcamento", ValorConfiguracao = "10" });
        base.OnModelCreating(modelBuilder);

    }

    public DbSet<OficinaWebMVC.Database.Entities.Veiculo> Veiculo { get; set; } = default!;






}
