using Microsoft.AspNetCore.Mvc;
using VeggieVibes.Application.UseCases;
using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses;
using VeggieVibes.Application.UseCases.Recipes.GetById;

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

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseGetRecipeByIdJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromRoute] long id,
        [FromServices] IGetRecipeByIdUseCase useCase)
    {
        var response = await useCase.Execute(id);

        if (response is null)
            return NotFound();

        return Ok(response);
    }
}
