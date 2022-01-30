using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloner.Models;
using TwitterCloner.Data;
using TwitterCloner.Models.DTO;

namespace TwitterCloner.Controllers
{
    [Route("api/users")]
    [Controller]
    public class UsersController : ControllerBase
    {
        private IRepository _repository;

        public UsersController(IRepository repository)
        {
            _repository = repository;
        }
       [HttpGet]
       public async  Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            List<UserDTO> users = await _repository.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {

                UserDTO use = await _repository.GetUserByIdAsync(id);
                if (use == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(use);


                }

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

       [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            
            try
            {
                if (ModelState.IsValid)
                {

                   await _repository.CreateUserAsync(user);
                    //return Created();
                    return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User user)
        {
            try
            {

                User use = await _repository.UpdateUserAsync(id, user);
                if (use == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetUserById), new { id = use.Id }, use);
                }

            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }
    }
}