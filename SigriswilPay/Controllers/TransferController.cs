using Microsoft.AspNetCore.Mvc;
using SigriswilPay.DTO;
using SigriswilPay.Entities;
using SigriswilPay.Interfaces.Repositories;

namespace SigriswilPay.Controllers;

[ApiController]
[Route("v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class TransferController : ControllerBase
{
    /// <summary>
    /// Realizar uma Transfericia
    /// </summary>
    /// <remarks>
    /// Realizar uma Transfericia
    /// </remarks>
    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] CreateTransfer model
        , [FromServices] ITransferRepository repository)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new Transfer(model);
            await repository.InsertOneAsync(entity);
            
            return StatusCode(StatusCodes.Status201Created, entity);
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    /// <summary>
    /// Listar Transfericias
    /// </summary>
    /// <remarks>
    /// Listar Transfericias
    /// </remarks>
    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll([FromServices] ITransferRepository repository)
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