using Microsoft.AspNetCore.Mvc;
using VeggieVibes.Application.UseCases;
using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses;
namespace VeggieVibes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterRecipesJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterRecipesUseCase useCase,
        [FromBody] RequestRegisterRecipesJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
