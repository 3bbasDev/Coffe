using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Controller
{
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        public OrderController()
        {

        }
        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders()
        {
            return Ok();
        }
    }
}
