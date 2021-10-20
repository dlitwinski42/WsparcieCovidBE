using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.DTO;
using WsparcieCovid.Entities;
using WsparcieCovid.Repositories;
using WsparcieCovid.Services;


namespace WsparcieCovid.Controllers
{
    
    
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IUserService userService;
        
        public UsersController(
            IUserRepository userRepository,
            IUserService userService)
        {
            this.userRepository = userRepository;
            this.userService = userService;
        }

        [HttpGet("/user/{login}")]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(string login)
        {
            return new JsonResult(await userRepository.GetAsync(login)) { StatusCode = 200};
        }

        [HttpPost("/user")]
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] UsersDto userDto)
        {
            return await userService.CreateAsync(userDto.Role, userDto.Username, userDto.Password, userDto.FirstName, userDto.LastName, userDto.Email, userDto.Name, userDto.NipNumber, userDto.BankAccountNumber, userDto.PhoneNumber);
        }
        
        [HttpPost("/authenticate")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AuthenticationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
        // below only when credentials are invalid
        [ProducesResponseType(typeof(ExceptionDto), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> AuthenticateAsync([FromBody] LoginDto loginDto)
        {
            return await userService.AuthenticateAsync(loginDto.Login, loginDto.Password);
        }

        [HttpPost("/refresh")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AuthenticationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
        // below only when credentials are invalid
        [ProducesResponseType(typeof(ExceptionDto), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> RefreshAsync([FromBody] RefreshDto refreshDto)
        {
            return await userService.RefreshAsync(refreshDto.AccessToken, refreshDto.RefreshToken);
        }
        
        [HttpGet("/user/role/{login}")]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRoleAsync(string login)
        {
            return new JsonResult(await userService.GetRoleAsync(login)) { StatusCode = 200};
        }
    }
}