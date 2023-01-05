using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using UnitedKingdomPostcodeAPI.Models;

namespace UnitedKingdomPostcodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostcodeController : ControllerBase
    {
        private static List<PostcodeModel> postcodes = PopulateData();

        public static List<PostcodeModel> PopulateData()
        {
            var postcodes = new List<PostcodeModel>();

            using (var reader = new StreamReader(@"C:\Users\ryan\source\repos\UnitedKingdomPostcodeAPI\UnitedKingdomPostcodeAPI\postcodedata.csv"))
            {
                while (!reader.EndOfStream)
                {
                    PostcodeModel postcodeEntry = new PostcodeModel();

                    string? line = reader.ReadLine();
                    var values = line.Split(",");

                    postcodeEntry.Postcode = values[0];
                    postcodeEntry.Eastings = values[1];
                    postcodeEntry.Northings = values[2];
                    postcodeEntry.Latitude = values[3];
                    postcodeEntry.Longitude = values[4];
                    postcodeEntry.Town = values[5];
                    postcodeEntry.Region = values[6];
                    postcodeEntry.UkRegion = values[7];
                    postcodeEntry.Country = values[8];
                    postcodeEntry.CountryString = values[9];

                    postcodes.Add(postcodeEntry);

                }
            }

            return postcodes;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPostcodes()
        {
            return Ok(postcodes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PostcodeModel>>> GetSingularPostcode(int id)
        {
            var postcode = postcodes.Find(x => x.Id == id);
            if (postcode == null)
            {
                return NotFound("Postcode does not exist");
            }
            return Ok(postcode);
        }

        [HttpPost]
        public async Task<ActionResult<List<PostcodeModel>>> AddPostcode(PostcodeModel postcode)
        {
            postcodes.Add(postcode);
            return Ok(postcode);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<PostcodeModel>>> UpdatePostcode(int id, PostcodeModel updatedPostcode)
        {
            var postcode = postcodes.Find(x => x.Id == id);

            if (postcode == null)
            {
                return NotFound("Failed to update postcode - does not exist");
            }

            postcode.Postcode = updatedPostcode.Postcode;
            postcode.Eastings = updatedPostcode.Eastings;
            postcode.Northings = updatedPostcode.Northings;
            postcode.Longitude = updatedPostcode.Longitude;
            postcode.Latitude = updatedPostcode.Latitude;
            postcode.Town = updatedPostcode.Town;
            postcode.Region = updatedPostcode.Region;
            postcode.UkRegion = updatedPostcode.UkRegion;
            postcode.Country = updatedPostcode.Country;
            postcode.CountryString = updatedPostcode.CountryString;

            return Ok(postcodes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PostcodeModel>>> DeletePostcode(int id)
        {
            var postcode = postcodes.Find(x => x.Id == id);

            if (postcode == null)
            {
                return NotFound("Failed to delete postcode - does not exist");
            }

            postcodes.Remove(postcode);
            return Ok(postcodes);
        }
    }
}
