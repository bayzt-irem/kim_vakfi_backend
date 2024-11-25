using Business.IService;
using Items.Command.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("cart"), Authorize(Roles = "Admin")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        /// <summary>
        /// GetAllCartsAsync
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("all")]
        public async Task<IActionResult> GetAllCartsAsync()
        {
            Console.WriteLine("GetAllCartsAsync");
            var result = await _cartService.GetAllCartsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Create Cart
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCartAsync([FromBody] CreateCartCommand command)
        {
            Console.WriteLine("LoginAsync");
            var result = await _cartService.CreateCartAsync(command);
            return Ok(result);
        }

        /// <summary>
        /// Update Cart
        /// </summary>
        /// <param name="viewDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCartAsync([FromBody] UpdateCartCommand command)
        {
            Console.WriteLine("UpdateCartAsync");
            var result = await _cartService.UpdateCartAsync(command);
            return Ok(result);
        }
    }
}
