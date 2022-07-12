using Microsoft.AspNetCore.Mvc;
using mysqlAPI.Model;
using mysqlAPI.Repository;

namespace mysqlAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UsersController : ControllerBase
{

    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet(Name = "GetAllUsers")]
    [Produces(typeof(User))]
    public IActionResult GetAll()
    {
        var users = _userRepository.GetAll();

        if (users.Count() == 0)
        return NoContent();

        return Ok(users);
    }
    [HttpGet("{id}")]
    [Produces(typeof(User))]
    public IActionResult Get(int id)
    {
        var user = _userRepository.Get(id);

        if (user == null)
            return NoContent();

        return Ok(user);
    }
    [HttpPost()]
    public IActionResult Post(User newUser)
    {
        var response = _userRepository.InsertUser(newUser);

        return Ok(response);
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, string name)
    {
        var response = _userRepository.UpdateUser(id, name);

        return Ok(response);
    }
    [HttpDelete()]
    public IActionResult Delete(int id)
    {
        var response = _userRepository.DeleteUser(id);

        return Ok(response);
    }
}