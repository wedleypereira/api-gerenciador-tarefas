using GerenciadorTarefas.Communication.Requests;
using GerenciadorTarefas.Communication.Responses;
using GerenciadorTarefas.Exception;
using GerenciadorTarefas.Exception.ExceptionBase;
using GerenciadorTarefas.Infrastructure;
using GerenciadorTarefas.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Application.UseCases.Tarefas.Update;

public class UpdateTarefaByIdUseCase
{
    public ResponseTarefaJson Execute(Guid Id, RequestUpdateTarefaByIdJson request)
    {
        var dbContext = new TarefasDbContext();
        var entity = dbContext.Tarefas.FirstOrDefault(tarefa => tarefa.Id == Id);

        if (entity is null) throw new NotFoundException(ResourceErrorMessages.TASK_NOT_FOUND);

        Validate(entity, request);

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.DateLimit = request.DateLimit;
        entity.Priority = (Infrastructure.Enums.TarefaPriority)request.Priority;
        entity.Status = (Infrastructure.Enums.TarefaStatus)request.Status;

        dbContext.Tarefas.Update(entity);
        dbContext.SaveChanges();

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

    void Validate(Tarefa task, RequestUpdateTarefaByIdJson request)
    {
        var validator = new UpdateTarefaValidator(task);

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
