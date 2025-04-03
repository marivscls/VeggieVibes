using Microsoft.AspNetCore.Mvc;
using VeggieVibes.Communication.Responses;
using VeggieVibes.Communication.Requests.Users;
using VeggieVibes.Application.UseCases.Users.Register;

namespace VeggieVibes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(RequestUserJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterUser([FromServices] IRegisterUserUseCase useCase, [FromBody] RequestUserJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
}