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
    public IResult GetUsers()
    {
        return TypedResults.Ok(Users);
    }

    [HttpGet("{id}")]
    public IResult GetUser(int id)
    {
        if (id < 0 || id >= Users.Count || Users[id] == null)
        {
            return TypedResults.NotFound("User not found");
        }
        return TypedResults.Ok(Users[id]);
    }

    [HttpPost]
    public IResult AddUser([FromBody] User user)
    {
        Users.Add(user);
        return TypedResults.Ok("User Successfully Added.");
    }

    [HttpPut("{id}")]
    public IResult EditUser(int id, [FromBody] User newUser)
    {
        if (id < 0 || id >= Users.Count || Users[id] == null)
        {
            return TypedResults.NotFound("User not found");
        }

        Users[id] = newUser;

        return TypedResults.Ok("User Successfully Edited.");
    }

    [HttpDelete("{id}")]
    public IResult DeleteUser(int id)
    {
        if (id < 0 || id >= Users.Count || Users[id] == null)
        {
            return TypedResults.NotFound("User not found");
        }
        
        Users.RemoveAt(id);

        return TypedResults.Ok("User Successfully Deleted.");
    }
}