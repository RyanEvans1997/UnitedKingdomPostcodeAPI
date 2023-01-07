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
            return await _postcodeService.GetAllPostcodes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostcodeModel>> GetSingularPostcode(int id)
        {
            var result = await _postcodeService.GetSingularPostcode(id);
            if (result is null)
            {
                return NotFound("Postcode not found");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<PostcodeModel>>> AddPostcode(PostcodeModel postcode)
        {
            var result = await _postcodeService.AddPostcode(postcode);
            return Ok(result);
        }

        //[HttpPost]
        //[Route("prepopulate")]
        //public async Task<ActionResult<List<PostcodeModel>>> PrePopulateDb()
        //{
        //    var result = await _postcodeService.PrePopulatePostcodes();
        //    return Ok(result);
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult<List<PostcodeModel>>> UpdatePostcode(int id, PostcodeModel updatedPostcode)
        {
            var result = await _postcodeService.UpdatePostcode(id, updatedPostcode);
            if(result is null)
            {
                return NotFound("Postcode not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PostcodeModel>>> DeletePostcode(int id)
        {
            var result = await _postcodeService.DeletePostcode(id);
            if (result is null)
            {
                return NotFound("Postcode does not exist");
            }
            return Ok(result);
        }



    }
}
