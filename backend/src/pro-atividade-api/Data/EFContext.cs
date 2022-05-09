using Microsoft.EntityFrameworkCore;
using ProAtividade.API.Models;

namespace ProAtividada.API.Data;

public class EFContext : DbContext
{
    public DbSet<Atividade> Atividades { get; set; }
    public string connectionString;

    public EFContext(IConfiguration configuration) : base()
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}
