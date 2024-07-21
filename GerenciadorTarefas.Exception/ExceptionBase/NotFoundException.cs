using System.Net;

namespace GerenciadorTarefas.Exception.ExceptionBase;

public class NotFoundException : TarefaException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override List<string> GetErrorMessages()
    {
        return [ Message ];
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.NotFound;
    }
}
