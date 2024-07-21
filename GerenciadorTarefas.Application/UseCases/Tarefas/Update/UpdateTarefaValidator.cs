using FluentValidation;
using GerenciadorTarefas.Communication.Requests;
using GerenciadorTarefas.Exception;
using GerenciadorTarefas.Infrastructure.Entities;

namespace GerenciadorTarefas.Application.UseCases.Tarefas.Update;

public class UpdateTarefaValidator : AbstractValidator<RequestUpdateTarefaByIdJson>
{
    public UpdateTarefaValidator(Tarefa task)
    {
        RuleFor(tarefa => tarefa.Name).NotEmpty().WithMessage(ResourceErrorMessages.TASK_NAME_REQUIRED);
        RuleFor(tarefa => tarefa.DateLimit).GreaterThan(DateTime.UtcNow).WithMessage(ResourceErrorMessages.TASK_NEED_IN_THE_FUTURE);
        RuleFor(tarefa => tarefa.Priority).IsInEnum().WithMessage(ResourceErrorMessages.INVALID_PRIORITY);
        RuleFor(tarefa => tarefa.Status).IsInEnum().WithMessage(ResourceErrorMessages.INVALID_STATUS);

        RuleFor(tarefa => tarefa)
            .Must(tarefa => tarefa.Name != task.Name).WithMessage(ResourceErrorMessages.NAME_TASK_IS_EQUALS)
            .Must(tarefa => tarefa.DateLimit != task.DateLimit).WithMessage(ResourceErrorMessages.DATE_TASK_IS_EQUALS)
            .Must(tarefa => (int)tarefa.Priority != (int)task.Priority).WithMessage(ResourceErrorMessages.PRIORITY_TASK_IS_EQUALS)
            .Must(tarefa => (int)tarefa.Status != (int)task.Status).WithMessage(ResourceErrorMessages.STATUS_TASK_IS_EQUALS);
    }
}
