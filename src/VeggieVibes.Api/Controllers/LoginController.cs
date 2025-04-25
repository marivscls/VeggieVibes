using Microsoft.AspNetCore.Mvc;
using VeggieVibes.Application.UseCases.Login;
using VeggieVibes.Communication.Requests;
using VeggieVibes.Communication.Responses.Users;

namespace VeggieVibes.Api.Controllers;

[Route("api/[controller]")]
[ApiController] 
public class LoginController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromServices] IDoLoginUseCase useCase, [FromBody] RequestLoginJson request)
    {
        var response = await useCase.Execute(request);
        return Ok(response);
    }
}

