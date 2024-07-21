using GerenciadorTarefas.Infrastructure.Enums;

namespace GerenciadorTarefas.Infrastructure.Entities;

public class Tarefa
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TarefaPriority Priority { get; set; }
    public DateTime DateLimit { get; set; }
    public TarefaStatus Status { get; set; }
}
