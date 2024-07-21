using GerenciadorTarefas.Communication.Requests;
using GerenciadorTarefas.Communication.Responses;
using GerenciadorTarefas.Exception.ExceptionBase;
using GerenciadorTarefas.Infrastructure.Enums;
using GerenciadorTarefas.Infrastructure;
using GerenciadorTarefas.Infrastructure.Entities;

namespace GerenciadorTarefas.Application.UseCases.Tarefas.Register;

public class RegisterTarefaUseCase
{
    public ResponseTarefaJson Execute(RequestRegisterTarefaJson request)
    {
        var dbContext = new TarefasDbContext();

        Validate(request);

        var entity = new Tarefa
        {
            Name = request.Name,
            Description = request.Description,
            DateLimit = request.DateLimit,
            Priority = (TarefaPriority)request.Priority,
            Status = (TarefaStatus)request.Status
        };

        dbContext.Tarefas.Add(entity);
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

    private void Validate(RequestRegisterTarefaJson request)
    {
        var validator = new RegisterTarefaValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
