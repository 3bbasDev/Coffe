using Coffe.Data;
using Coffe.Repos;
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
        private readonly IAcountRepo _acountRepo;
        public AccountController(IAcountRepo contextdb)
        {
            _acountRepo = contextdb;
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _acountRepo.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid Id)
        {
            var user = await _acountRepo.GetUser(Id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> CheckUser([FromRoute] Guid Id)
        {
            var user = await _acountRepo.CheckUser(Id);
            return Ok(user);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid Id)
        {
            var user = await _acountRepo.DeleteUser(Id);

            if (user == false)
                return NotFound();
            return Ok();
        }
    }
}
