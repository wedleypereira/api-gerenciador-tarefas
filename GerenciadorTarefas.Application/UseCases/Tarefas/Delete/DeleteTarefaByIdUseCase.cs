using GerenciadorTarefas.Exception;
using GerenciadorTarefas.Exception.ExceptionBase;
using GerenciadorTarefas.Infrastructure;

namespace GerenciadorTarefas.Application.UseCases.Tarefas.Delete;

public class DeleteTarefaByIdUseCase
{
    public void Execute(Guid Id)
    {
        var dbContext = new TarefasDbContext();

        var entity = dbContext.Tarefas.FirstOrDefault(tarefa => tarefa.Id == Id);

        if (entity is null)
        {
            throw new NotFoundException(ResourceErrorMessages.TASK_NOT_FOUND);
        }

        dbContext.Tarefas.Remove(entity);
        dbContext.SaveChanges();
    }
}
