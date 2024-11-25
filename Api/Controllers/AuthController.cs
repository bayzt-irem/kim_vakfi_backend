using Business.IService;
using Items.Command.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("auth"), AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// login
        /// </summary>
        /// <param name="viewDto"></param>
        /// <returns></returns>
        [HttpGet, Route("current")]
        public async Task<IActionResult> GetCurrentUserAsync()
        {
            Console.WriteLine("GetCurrentUserAsync");
            var result = await  _authService.Current();
            return Ok(result);
        }

        /// <summary>
        /// login
        /// </summary>
        /// <param name="viewDto"></param>
        /// <returns></returns>
        [HttpPost, Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand command)
        {
            Console.WriteLine("LoginAsync");
            var result = await  _authService.Login(command);
            return Ok(result);
        }

        /// <summary>
        /// register
        /// </summary>
        /// <param name="viewDto"></param>
        /// <returns></returns>
        [HttpPost, Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommand command)
        {
            Console.WriteLine("RegisterAsync");
            var result = await _authService.Register(command);
            return Ok(result);
        }
    }
}
