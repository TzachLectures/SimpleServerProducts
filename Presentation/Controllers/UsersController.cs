using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleServerProducts.Core.Models;

namespace SimpleServerProducts.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static private List<User> users = new List<User> {
            new User() { Id=1, FirstName="Avi", LastName="Cohen" },
            new User() {Id=2, FirstName="Matan", LastName="Neeman"},
            new User() {Id=3, FirstName="Ron", LastName="Moshe"}};

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User? userToReturn = users.FirstOrDefault(u => u.Id == id);
            if (userToReturn == null)
            {
                return NotFound();
            }
            return Ok(userToReturn);

        }


        [HttpPost]
        public IActionResult Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            users.Add(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            int userToReplaceIndex = users.FindIndex(u => u.Id == id);

            if (userToReplaceIndex == -1)
            {
                return NotFound("user not found");
            }

            users[userToReplaceIndex] = user;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User? userToRemove = users.FirstOrDefault(u => u.Id == id);
            if (userToRemove == null)
            {
                return NotFound();
            }
            users.Remove(userToRemove);
            return NoContent();
        }
    }
}
