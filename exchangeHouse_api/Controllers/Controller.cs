using exchangeHouse_api.Domain.Enitty;
using exchangeHouse_api.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace exchangeHouse_api.Controllers
{
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
        public async Task<IActionResult> Create(string userId, [FromBody] Benefit benefit)
        {
            if (benefit == null)
                return BadRequest("Benefício inválido.");

            benefit.User_Id = userId;

            await _benefitService.CreateAsync(benefit);

            return CreatedAtAction(
                nameof(GetById),
                new { userId = userId, id = benefit.Id },
                benefit
            );
        }

        // GET api/v1/users/{userId}/benefits?id={id}
        [HttpGet]
        public async Task<IActionResult> GetById(string userId, [FromQuery] Guid id)
        {
            try
            {
                var benefit = await _benefitService.GetDetailsById(id);

                if (benefit == null)
                    return NotFound();

                // caso queira validar se o benefício pertence ao user
                // if (benefit.User_Id != userId) return NotFound();

                return Ok(benefit);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT api/v1/users/{userId}/benefits?id={id}
        [HttpPut]
        public async Task<IActionResult> Update(string userId, [FromQuery] Guid id, [FromBody] Benefit benefit)
        {
            if (benefit == null)
                return BadRequest("Benefício inválido.");

            benefit.Id = id;
            benefit.User_Id = userId;

            try
            {
                await _benefitService.UpdateAsync(id, benefit);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/v1/users/{userId}/benefits?id={id}
        [HttpDelete]
        public async Task<IActionResult> Delete(string userId, [FromQuery] Guid id)
        {
            try
            {
                await _benefitService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
