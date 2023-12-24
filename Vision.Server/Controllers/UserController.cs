using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.Server.DTO.CreateDTOs;
using Vision.Server.Models;

namespace Vision.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly VisionDbContext _context;

        public UserController(VisionDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            var userDTOs = users.Select(user => new UserDTO
            {
                PK = user.PK,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Description = user.Description
            }).ToList();

            return Ok(userDTOs);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<UserDTO>> GetUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new UserDTO
            {
                PK = user.PK,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Description = user.Description
            };

            return userDTO;
        }

        //[HttpPost(Name = "CreateUser")]
        //public async Task<ActionResult<UserDTO>> CreateUser(CreateUserDTO userDTO)
        //{
        //    var user = new User
        //    {
        //        FirstName = userDTO.FirstName,
        //        LastName = userDTO.LastName,
        //        Email = userDTO.Email,
        //        Description = userDTO.Description,
        //        CreationDate = DateTime.Now
        //    };

        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();

        //    return await GetUser(user.PK);
        //}

        [HttpPost(Name = "RegisterUser")]
        public async Task<ActionResult<UserDTO>> CreateUser(CreateUserDTO userDTO)
        {
            PasswordHasher passwordHasher = new PasswordHasher();

            var user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Password = passwordHasher.HashPassword(userDTO.password),
                Description = userDTO.Description,
                CreationDate = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return await GetUser(user.PK);
        }



        [HttpPut("{id}", Name = "UpdateUser")]
        public async Task<ActionResult> UpdateUser(Guid id, UserUpdateDTO userUpdateDTO)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = userUpdateDTO.FirstName;
            user.LastName = userUpdateDTO.LastName;
            user.Email = userUpdateDTO.Email;
            user.Description = userUpdateDTO.Description;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
