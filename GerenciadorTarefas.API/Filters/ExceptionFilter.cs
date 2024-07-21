using GerenciadorTarefas.Communication.Responses;
using GerenciadorTarefas.Exception;
using GerenciadorTarefas.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GerenciadorTarefas.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is TarefaException)
        {
            var tarefaException = (TarefaException)context.Exception;

            context.HttpContext.Response.StatusCode = (int)tarefaException.GetStatusCode();

            var responseJson = new ResponseErrorJson(tarefaException.GetErrorMessages());

            context.Result = new ObjectResult(responseJson);
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var responseJson = new ResponseErrorJson(new List<string> { ResourceErrorMessages.UNKNOWN_ERROR });

            context.Result = new ObjectResult(responseJson);
        }
    }
}
