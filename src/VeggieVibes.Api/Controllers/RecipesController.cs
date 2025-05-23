using Microsoft.AspNetCore.Mvc;
using VeggieVibes.Communication.Requests.Recipes;
using VeggieVibes.Communication.Responses;
using VeggieVibes.Communication.Responses.Recipes;
using VeggieVibes.Application.UseCases.Recipes.GetById;
using VeggieVibes.Application.UseCases.Recipes.Delete;
using VeggieVibes.Application.UseCases.Recipes.GetAll;
using VeggieVibes.Application.UseCases.Recipes.Update;
using VeggieVibes.Application.UseCases.Recipes.Register;
using Microsoft.AspNetCore.Authorization;

namespace VeggieVibes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]

public class RecipesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(RequestRecipeIngredientsJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromServices] IRegisterRecipesUseCase useCase, [FromBody] RequestRecipeJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseGetRecipeByIdJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
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

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromServices] IUpdateRecipeUseCase useCase, [FromRoute] long id, [FromBody] RequestUpdateRecipeJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }
}