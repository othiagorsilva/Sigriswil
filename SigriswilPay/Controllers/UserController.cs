using Microsoft.AspNetCore.Mvc;
using SigriswilPay.DTO;
using SigriswilPay.Entities;
using SigriswilPay.Interfaces.Repositories;

namespace SigriswilPay.Controllers;

[ApiController]
[Route("v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class UserController : ControllerBase
{
    /// <summary>
    /// Cria um Usuario
    /// </summary>
    /// <remarks>
    /// Cria um Usuario
    /// </remarks>
    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] CreateUser model
        , [FromServices] IUserRepository repository)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new User(model);
            await repository.InsertOneAsync(entity);
            
            return StatusCode(StatusCodes.Status201Created, entity);
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    /// <summary>
    /// Listar Usuarios
    /// </summary>
    /// <remarks>
    /// Listar Usuarios
    /// </remarks>
    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll([FromServices] IUserRepository repository)
    {
        try
        {
            var users = await repository.GetAllAsync();
            if (users != null && users.Any())
                return StatusCode(StatusCodes.Status200OK, users);

            return NotFound("Data not found");
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}