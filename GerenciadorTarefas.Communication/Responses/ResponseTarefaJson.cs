using GerenciadorTarefas.Communication.Enums;

namespace GerenciadorTarefas.Communication.Responses;

public class ResponseTarefaJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TarefaPriority Priority { get; set; }
    public DateTime DateLimit { get; set; }
    public TarefaStatus Status { get; set; }
}
