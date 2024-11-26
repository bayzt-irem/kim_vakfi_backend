using Business.IService;
using Items.Command.Place;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("place"), Authorize(Roles = "Admin")]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        /// <summary>
        /// GetAllPlacesAsync
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("all")]
        public async Task<IActionResult> GetAllPlacesAsync()
        {
            Console.WriteLine("GetAllPlacesAsync");
            var result = await _placeService.GetAllPlacesAsync();
            return Ok(result);
        }

        /// <summary>
        /// GetPlaceAsync
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("{id:guid}")]
        public async Task<IActionResult> GetPlaceAsync([FromRoute] Guid id)
        {
            Console.WriteLine("GetPlaceAsync");
            var result = await _placeService.GetPlaceAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Create Place
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreatePlaceAsync([FromBody] CreatePlaceCommand command)
        {
            Console.WriteLine("CreatePlaceAsync");
            var result = await _placeService.CreatePlaceAsync(command);
            return Ok(result);
        }
         
        /// <summary>
        /// Update Place
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdatePlaceAsync([FromBody] UpdatePlaceCommand command)
        {
            Console.WriteLine("UpdatePlaceAsync");
            var result = await _placeService.UpdatePlaceAsync(command);
            return Ok(result);
        }
    }
}
