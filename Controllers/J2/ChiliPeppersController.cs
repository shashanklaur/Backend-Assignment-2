using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C_Assignment_2.Controllers.J2
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiliPeppersController : ControllerBase
    {
        private readonly Dictionary<string, int> pepperHeatUnits = new Dictionary<string, int>
        {
            { "Poblano", 1500 },
            { "Mirasol", 6000 },
            { "Serrano", 15500 },
            { "Cayenne", 40000 },
            { "Thai", 75000 },
            { "Habanero", 125000 }
        };

        /// <summary>
        /// Calculates total spiciness based on the ingredients.
        /// </summary>
        /// <param name="ingredients">Comma-separated list of pepper names</param>
        /// <returns>Total spiciness in SHU</returns>
        /// <example>GET: /api/ChiliPeppers?ingredients=Poblano,Cayenne,Thai</example>
        [HttpGet]
        public IActionResult CalculateSpiciness([FromQuery] string ingredients)
        {
            int totalSpiciness = 0;
            var peppers = ingredients.Split(',');

            foreach (var pepper in peppers)
            {
                if (pepperHeatUnits.TryGetValue(pepper.Trim(), out int heat))
                {
                    totalSpiciness += heat;
                }
            }

            return Ok(totalSpiciness);
        }
    }
}
