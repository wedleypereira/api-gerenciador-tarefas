using FluentValidation;
using GerenciadorTarefas.Communication.Requests;
using GerenciadorTarefas.Exception;

namespace GerenciadorTarefas.Application.UseCases.Tarefas.Register;

public class RegisterTarefaValidator : AbstractValidator<RequestRegisterTarefaJson>
{
    public RegisterTarefaValidator()
    {
        RuleFor(task => task.Name).NotEmpty().WithMessage(ResourceErrorMessages.TASK_NAME_REQUIRED);
        RuleFor(task => task.DateLimit).GreaterThan(DateTime.UtcNow).WithMessage(ResourceErrorMessages.TASK_NEED_IN_THE_FUTURE);
        RuleFor(task => task.Priority).IsInEnum().WithMessage(ResourceErrorMessages.INVALID_PRIORITY);
        RuleFor(task => task.Status).IsInEnum().WithMessage(ResourceErrorMessages.INVALID_STATUS);
    }
}
