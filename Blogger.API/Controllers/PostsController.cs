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
using Blogger.API.Services;
using Newtonsoft.Json.Linq;
using Blogger.API.CustomTypes;

namespace Blogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostService postservice = null;

        public PostsController(BloggerContext context)
        {
            postservice = ServiceLocator.Instance.GetService<IPostService>(context);
        }

        // GET: api/Posts
        [HttpGet]
        public IEnumerable<Post> GetPosts()
        {
            return null;
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = await postservice.GetPostbyId(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost([FromRoute] int id, [FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.id)
            {
                return BadRequest();
            }

            try
            {
               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        [HttpPost]
        public IActionResult PostPost([FromBody] _PostTag post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postData = postservice.InsertPost(post.blog_id, post.title, post.text, post.tags);

            if (postData != null)
            {
                return CreatedAtAction("GetPost", new { id = postData.id }, postData);
            }
            else
            {
                return NoContent();
            }

           
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

        
            return Ok();
        }

        private bool PostExists(int id)
        {
            return false;
        }
    }
}