using Microsoft.AspNetCore.Mvc;
using VeggieVibes.Application.UseCases;
using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses;
using VeggieVibes.Application.UseCases.Recipes.GetById;
using VeggieVibes.Exception.ExceptionsBase;

namespace VeggieVibes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredIngredientsJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromServices] IRegisteredRecipesUseCase useCase, [FromBody] RequestRegisterRecipesJson request)
    {
        try
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (ErrorOnValidationException ex)
        {
            var ErrorResponse = new ResponseErrorJson(ex.Errors);

            return BadRequest(ErrorResponse);
        }
        catch
        {
            var ErrorResponse = new ResponseErrorJson("Unknown error");

            return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseGetRecipeByIdJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] long id, [FromServices] IGetRecipeByIdUseCase useCase)
    {
        var response = await useCase.Execute(id);

        if (response is null)
            return NotFound();

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseRecipesJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllRecipes([FromServices] IGetAllRecipesUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Recipes.Count != 0)
            return Ok(response);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] long id, [FromServices] IDeleteRecipeUseCase useCase)
    {
        var deleted = await useCase.Execute(id);

        if (!deleted)
            return NotFound(new ResponseErrorJson($"Recipe with id {id} not found."));

        return NoContent();
    }
}
