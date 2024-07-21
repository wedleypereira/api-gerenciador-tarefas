using GerenciadorTarefas.Application.UseCases.Tarefas.Delete;
using GerenciadorTarefas.Application.UseCases.Tarefas.GetAll;
using GerenciadorTarefas.Application.UseCases.Tarefas.GetById;
using GerenciadorTarefas.Application.UseCases.Tarefas.Register;
using GerenciadorTarefas.Application.UseCases.Tarefas.Update;
using GerenciadorTarefas.Communication.Requests;
using GerenciadorTarefas.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TarefasController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseTarefaJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterTarefaJson request)
    {
        var response = new RegisterTarefaUseCase().Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet("get-all-tarefas")]
    [ProducesResponseType(typeof(ResponseAllTarefasJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult GetAll()
    {
        var response = new GetAllTarefasUseCase().Execute();

        return Ok(response);
    }

    [HttpGet]
    [Route("{idTarefa}")]
    [ProducesResponseType(typeof(ResponseTarefaJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult Get([FromRoute] Guid idTarefa)
    {
        var response = new GetTarefaByIdUseCase().Execute(idTarefa);

        return Ok(response);
    }

    [HttpPut]
    [Route("{idTarefa}")]
    [ProducesResponseType(typeof(ResponseTarefaJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] Guid idTarefa, [FromBody] RequestUpdateTarefaByIdJson request)
    {
        var response = new UpdateTarefaByIdUseCase().Execute(idTarefa, request);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{idTarefa}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid idTarefa)
    {
        var useCase = new DeleteTarefaByIdUseCase();
        useCase.Execute(idTarefa);

        return NoContent();
    }
}
