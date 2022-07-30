using Coffe.Data;
using Coffe.Models.Users.Request;
using Coffe.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        
        public AccountController(IAccountRepository contextdb)
        {
            _accountRepository = contextdb;
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _accountRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid Id)
        {
            var user = await _accountRepository.GetUser(Id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> CheckUser([FromRoute] Guid Id)
        {
            var user = await _accountRepository.CheckUser(Id);
            return Ok(user);
        }

        [HttpPost()]
        public async Task<IActionResult> AddUser([FromBody] RequestCreateUserModel model)
        {
            //if (ModelState.IsValid)
            //    return BadRequest();
            var user = await _accountRepository.AddUser(model);
            //if (user == Guid.Empty)
            //    return BadRequest();
            return Ok(user);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateUser([FromBody] RequestUpdateUserModel model)
        {
            //if (ModelState.IsValid)
            //    return BadRequest();
            var user = await _accountRepository.UpdateUser(model);
            //if (user == Guid.Empty)
            //    return BadRequest();
            return Ok(user);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid Id)
        {
            var user = await _accountRepository.DeleteUser(Id);

            if (user == false)
                return NotFound();
            return Ok();
        }
    }
}
