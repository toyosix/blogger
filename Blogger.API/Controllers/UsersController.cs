using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blogger.Data;
using Blogger.Domain;
using Blogger.API.Lib;
using Blogger.API.Service;

namespace Blogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BloggerContext _context;
        IUserService userservice = null;

        public UsersController(BloggerContext context)
        {
            _context = context;
            userservice = ServiceLocator.Instance.GetService<IUserService>(context);
        }


        // GET: api/Users
        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            var users = await userservice.GetAllUser();

            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userservice.GetUserbyId_tracking(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = await userservice.UpdateUser(id, user);

            if (isUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isSaved = await userservice.InsertUser(user.name);

            if (isSaved)
            {
                return CreatedAtAction("GetUser", new { id = user.id }, user);
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isDeleted = await this.userservice.DeleteUser(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok(isDeleted);
        }

    }
}