using System;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnock.Web.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        public IActionResult Get()
        {
            Guid myToken = new Guid("7004cd8e-58f2-43d3-902e-0eebf7385dae");
            return Ok(myToken);
        }
        
    }
}
