using GerenciadorTarefas.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Infrastructure;

public class TarefasDbContext : DbContext
{
    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=F:\\Users\\Wedley\\source\\repos\\TarefasDb.db");
    }
}
