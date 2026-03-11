

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEcommerce.Controllers
{
  [Route("usuario")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }


    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserDto userLoginDto)
    {

      if (userLoginDto == null || !ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      try
      {
        var user = await _userService.Login(userLoginDto);
        return Ok(user);
      }
      catch (ArgumentNullException ex)
      {
        return BadRequest(new { message = ex.Message });
      }
      catch (ArgumentException ex)
      {
        return BadRequest(new { message = ex.Message });
      }
      catch (KeyNotFoundException ex)
      {
        return NotFound(new { message = ex.Message });
      }
      catch (UnauthorizedAccessException ex)
      {
        return Unauthorized(new { message = ex.Message });
      }
      catch (InvalidOperationException ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            new { message = ex.Message });
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            new { message = "Error interno del servidor" });
      }
    }

  }
}