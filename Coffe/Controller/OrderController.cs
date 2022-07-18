using Coffe.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly AppContextdb contextdb;
        public OrderController(AppContextdb contextdb)
        {
            this.contextdb = contextdb;
        }
        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders()
        {
            var res = await contextdb.Orders.ToListAsync();
            return Ok();
        }
    }
}
