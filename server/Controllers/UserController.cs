using Microsoft.AspNetCore.Mvc;
using ActivityClubPortal.Models;
using ActivityClubPortal.Models.Repositories;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;

    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        var users = _userRepository.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _userRepository.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User newUser)
    {
        if (newUser == null)
        {
            return BadRequest("Invalid user data");
        }

        _userRepository.AddUser(newUser);

        return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, newUser);
    }


    [HttpPut("{id}")]
    public ActionResult<User> UpdateUser(int id, [FromBody] User updatedUser)
    {
        var existingUser = _userRepository.GetUserById(id);

        if (existingUser == null)
        {
            return NotFound();
        }

        existingUser.Name = updatedUser.Name;
        existingUser.DateOfBirth = updatedUser.DateOfBirth;
        existingUser.Gender = updatedUser.Gender;
        existingUser.Email = updatedUser.Email;
        existingUser.Password = updatedUser.Password;
        existingUser.Role = updatedUser.Role;

        _userRepository.UpdateUser(existingUser);

        return Ok(existingUser);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        var existingUser = _userRepository.GetUserById(id);

        if (existingUser == null)
        {
            return NotFound();
        }

        _userRepository.DeleteUser(id);

        return NoContent();
    }
}
