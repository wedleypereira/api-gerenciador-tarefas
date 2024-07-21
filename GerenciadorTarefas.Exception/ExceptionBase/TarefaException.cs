using System.Net;

namespace GerenciadorTarefas.Exception.ExceptionBase;

public abstract class TarefaException : SystemException
{
    public TarefaException(string message) : base(message)
    {
    }

    public abstract HttpStatusCode GetStatusCode();
    public abstract List<string> GetErrorMessages();
}
