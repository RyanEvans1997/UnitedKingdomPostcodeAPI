using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using UnitedKingdomPostcodeAPI.Models;
using UnitedKingdomPostcodeAPI.Services;

namespace UnitedKingdomPostcodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostcodeController : ControllerBase
    {
        private readonly IPostcodeService _postcodeService;

        public PostcodeController(IPostcodeService postcodeService)
        {
            this._postcodeService = postcodeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostcodeModel>>> GetAllPostcodes()
        {
            return _postcodeService.GetAllPostcodes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostcodeModel>> GetSingularPostcode(int id)
        {
            return _postcodeService.GetSingularPostcode(id);
        }

        [HttpPost]
        public async Task<ActionResult<List<PostcodeModel>>> AddPostcode(PostcodeModel postcode)
        {
            var result = _postcodeService.AddPostcode(postcode);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<PostcodeModel>>> UpdatePostcode(int id, PostcodeModel updatedPostcode)
        {
            var result = _postcodeService.UpdatePostcode(id, updatedPostcode);
            if(result is null)
            {
                return NotFound("Postcode not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PostcodeModel>>> DeletePostcode(int id)
        {
            var result = _postcodeService.DeletePostcode(id);
            if (result is null)
            {
                return NotFound("Postcode does not exist");
            }
            return Ok(result);
        }
    }
}
