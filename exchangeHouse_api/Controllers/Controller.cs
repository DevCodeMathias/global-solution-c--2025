using exchangeHouse_api.Application.DTOs;
using exchangeHouse_api.Domain.Enitty;
using exchangeHouse_api.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/users/{userId}/[controller]")]
public class BenefitsController : ControllerBase
{
    private readonly IBenefitService _benefitService;

    public BenefitsController(IBenefitService benefitService)
    {
        _benefitService = benefitService;
    }

    // POST api/v1/users/{userId}/benefits
    [HttpPost]
    public async Task<IActionResult> Create([FromRoute] string userId, [FromBody] Benefit benefit)
    {
        if (benefit == null)
            return BadRequest("Benefício inválido.");

        benefit.UserId = userId;

        await _benefitService.CreateAsync(benefit);

        return CreatedAtAction(
            nameof(GetById),
            new { userId = userId, id = benefit.Id },
            benefit
        );
    }

    // GET api/v1/users/{userId}/benefits
    [HttpGet]
    public async Task<IActionResult> GetAll([FromRoute] string userId)
    {
        var benefits = await _benefitService.GetAll(); // ideal seria GetAllByUser(userId)
        if (benefits == null)
            return NotFound();

        return Ok(benefits);
    }

    // GET api/v1/users/{userId}/benefits/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] string userId, [FromRoute] Guid id)
    {
        var benefit = await _benefitService.GetDetailsById(id);

        if (benefit == null)
            return NotFound();

        return Ok(benefit);
    }

    // PUT api/v1/users/{userId}/benefits/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] string userId, [FromRoute] Guid id, [FromBody] Benefit benefit)
    {
        if (benefit == null)
            return BadRequest("Benefício inválido.");

        benefit.Id = id;
        benefit.UserId = userId;

        await _benefitService.UpdateAsync(id, benefit);
        return NoContent();
    }

    // DELETE api/v1/users/{userId}/benefits/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] string userId, [FromRoute] Guid id)
    {
        await _benefitService.DeleteAsync(id);
        return NoContent();
    }

    // POST api/v1/users/{userId}/benefits/{id}/acquire
    [HttpPost("{id:guid}/acquire")]
    public async Task<IActionResult> AcquireBenefit([FromRoute] string userId, [FromRoute] Guid id, [FromBody] AcquireBenefitRequest request)
    {
        if (request == null || request.Quantity <= 0)
            return BadRequest("Informe uma quantidade válida para aquisição do benefício.");

        try
        {
            var history = await _benefitService.AcquireBenefitAsync(userId, id, request.Quantity);
            return Ok(history);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }


}
