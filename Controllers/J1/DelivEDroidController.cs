using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C_Assignment_2.Controllers.J1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelivEDroidController : ControllerBase
    {
        /// <summary>
        /// Calculates the final score based on the deliveries and collisions.
        /// </summary>
        /// <param name="deliveries">The number of packages delivered</param>
        /// <param name="collisions">The number of collisions with obstacles</param>
        /// <returns>The final score</returns>
        /// <example>POST: /api/DelivEDroid?deliveries=5&collisions=2</example>
        [HttpPost]
        public IActionResult CalculateScore([FromForm] int deliveries, [FromForm] int collisions)
        {
            int score = (deliveries * 50) - (collisions * 10);
            if (deliveries > collisions)
            {
                score += 500; // bonus points
            }
            return Ok(score);
        }
    }
}
