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
    public class AccountController : ControllerBase
    {
        private readonly AppContextdb _contextdb;
        public AccountController(AppContextdb contextdb)
        {
            _contextdb = contextdb;
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _contextdb.Users.Select(f => new
            {
                f.Id,
                f.FullName
            }).ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid Id)
        {
            var user = await _contextdb.Users.Where(f => f.Id == Id).FirstOrDefaultAsync();
            if (user == null)
                return NotFound();
            return Ok();
        }
    }
}
