using GerenciadorTarefas.Communication.Responses;
using GerenciadorTarefas.Exception.ExceptionBase;
using GerenciadorTarefas.Infrastructure;

namespace GerenciadorTarefas.Application.UseCases.Tarefas.GetAll;

public class GetAllTarefasUseCase
{
    public ResponseAllTarefasJson Execute()
    {
        var dbContext = new TarefasDbContext();

        var tarefas = dbContext.Tarefas.ToList();

        if (tarefas.Count.Equals(0))
        {
            throw new ErrorOnValidationException(new List<string> { "Nenhuma tarefa encontrada." });
        }

        return new ResponseAllTarefasJson
        {
            Tarefas = tarefas.Select(tarefa => new ResponseTarefaJson
            {
                Id = tarefa.Id,
                Name = tarefa.Name,
                Description = tarefa.Description,
                DateLimit = tarefa.DateLimit,
                Priority = (Communication.Enums.TarefaPriority)tarefa.Priority,
                Status = (Communication.Enums.TarefaStatus)tarefa.Status
            }).ToList()
        };
    }
}
