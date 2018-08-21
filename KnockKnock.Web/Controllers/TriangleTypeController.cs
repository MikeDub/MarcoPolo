using System;
using KnockKnock.Web.Services.TriangleType;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnock.Web.Controllers
{
    [Route("api/[controller]")]
    public class TriangleTypeController : Controller
    {
        private readonly ITriangleTypeService _triangleTypeService;

        public TriangleTypeController(ITriangleTypeService triangleTypeService)
        {
            _triangleTypeService = triangleTypeService;
        }

        /// <summary>
        /// Retrieves the triangle type based on the length of sides provided.
        /// </summary>
        /// <param name="a">Length of side a, should be > 1.</param>
        /// <param name="b">Length of side b, should be > 1.</param>
        /// <param name="c">Length of side c, should be > 1.</param>
        /// <returns>The name of the triangle type.</returns>
        [HttpGet]
        public IActionResult Get(int a, int b, int c)
        {
            try
            {
                string triangleType = _triangleTypeService.CalculateTriangleType(a, b, c);
                return Ok(triangleType);
            }
            catch (Exception)
            {
                return BadRequest("The request is invalid.");
            }
        }
        
    }
}
