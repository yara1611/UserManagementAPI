using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private static List<User> Users = new List<User>
    {
        new User { Username = "alice", Password = "password123" },
        new User { Username = "bob", Password = "qwerty456" },
        new User { Username = "charlie", Password = "letmein789" }
    };
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(Users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        try
        {
            if (id < 0 || id >= Users.Count)
            {
                return NotFound("User not found");
            }
            return Ok(Users[id]);
        }
        catch (Exception ex)
        {

            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] User user)
    {
        Users.Add(user);
        return Ok("User Successfully Added");
    }

    [HttpPut("{id}")]
    public IActionResult EditUser(int id, [FromBody] User newUser)
    {
        try
        {
            if (id < 0 || id >= Users.Count)
            {
                return NotFound("User not found");
            }
            Users[id] = newUser;
            return Ok("User Successfully Edited.");

        }
        catch (Exception ex)
        {

            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        try
        {
            if (id < 0 || id >= Users.Count)
            {
                return NotFound("User not found");
            }
            Users.RemoveAt(id);
            return Ok("User Successfully Deleted.");
        }
        catch (Exception ex)
        {

            return StatusCode(500, $"Internal server error: {ex.Message}");
        }


    }
}