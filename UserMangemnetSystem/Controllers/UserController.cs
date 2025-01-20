using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserMangemnetSystem.Data;
using UserMangemnetSystem.Models;
using UserMangemnetSystem.Models.Entites;

namespace UserMangemnetSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = dbContext.UserEntities.ToList();
            return Ok( new ApiResponse<List<UserEntity>>(true,"User retrived successfully",users));
           
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetUsersById(Guid id) {
            try
            {
                var user = dbContext.UserEntities.Find(id);
                if (user == null)
                {
                    return NotFound(new ApiResponse<UserEntity>(false, "User not found"));
                }
                return Ok(new ApiResponse<UserEntity>(true, "User retrieved successfully", user));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(false, ex.Message));
            }
        }

        [HttpPost]
        public IActionResult AddUser(AddUserDto addUserDto)
        {
            var userEntity=new UserEntity() { 
                Name = addUserDto.Name,
                Email = addUserDto.Email,
                Password=addUserDto.Password,
                Phone = addUserDto.Phone,

            
            };

            dbContext.UserEntities.Add(userEntity);
            dbContext.SaveChanges();
            return Ok(new ApiResponse<UserEntity>(true, "User added successfully", userEntity));
        }

        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult UpadteUserById(Guid id, UpdateUserDto updateUserDto)
        {
            var user = dbContext.UserEntities.Find(id);
            if (user is null)
            {
                return NotFound();
            }

            user.Name = updateUserDto.Name;
            user.Phone = updateUserDto.Phone;
            user.Email = updateUserDto.Email;
            user.Password = updateUserDto.Password;


            dbContext.SaveChanges();
            return Ok(new ApiResponse<UserEntity>(true, "User updated successfully", user));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteUserById(Guid id)
        {
            var user = dbContext.UserEntities.Find(id);

            if (user is null)
            {
                return NotFound(new ApiResponse<UserEntity>(false, "User not found"));
            }

            dbContext.UserEntities.Remove(user);
            dbContext.SaveChanges();

            return Ok(new ApiResponse<string>(true, "User deleted successfully"));
        }

    }
}
