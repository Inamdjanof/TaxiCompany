using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Users;
using TaxiCompany.Application.Services;

namespace TaxiCompany.API.Controllers
{
    
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(
            IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async ValueTask<ActionResult<UserDto>> PostUserAsync(
            UserForCreationDto userForCreationDto)
        {
            var createdUser = await userService
                .CreateUserAsync(userForCreationDto);

            return Created("", createdUser);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = this.userService.RetrieveUsers();

            return Ok(users);
        }

        [HttpGet("{userId:guid}")]
        public async ValueTask<ActionResult<UserDto>> GetUserByIdAsync(
            Guid userId)
        {
            var user = await this.userService
                .RetrieveUserByIdAsync(userId);

            return Ok(user);
        }

        [HttpPut]
        public async ValueTask<ActionResult<UserDto>> PutUserAsync(
            UserForModificationDto userForModificationDto)
        {
            var modifiedUser = await this.userService
                .ModifyUserAsync(userForModificationDto);

            return Ok(modifiedUser);
        }

        [HttpDelete("{userId:guid}")]
        public async ValueTask<ActionResult<UserDto>> DeleteUserAsync(
            Guid userId)
        {
            var removed = await this.userService
                .RemoveUserAsync(userId);

            return Ok(removed);
        }
    }
}