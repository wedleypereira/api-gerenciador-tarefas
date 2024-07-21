using GerenciadorTarefas.Communication.Responses;
using GerenciadorTarefas.Exception;
using GerenciadorTarefas.Exception.ExceptionBase;
using GerenciadorTarefas.Infrastructure;

namespace GerenciadorTarefas.Application.UseCases.Tarefas.GetById;

public class GetTarefaByIdUseCase
{
    public ResponseTarefaJson Execute(Guid Id)
    {
        var dbContext = new TarefasDbContext();

        var entity = dbContext.Tarefas.FirstOrDefault(tarefa => tarefa.Id == Id);

        if (entity is null)
        {
            throw new NotFoundException(ResourceErrorMessages.TASK_NOT_FOUND);
        }

        return new ResponseTarefaJson
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            DateLimit = entity.DateLimit,
            Priority = (Communication.Enums.TarefaPriority)entity.Priority,
            Status = (Communication.Enums.TarefaStatus)entity.Status
        };
    }
}
