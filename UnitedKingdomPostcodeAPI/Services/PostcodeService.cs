using Microsoft.EntityFrameworkCore;
using UnitedKingdomPostcodeAPI.Data;
using UnitedKingdomPostcodeAPI.Models;

namespace UnitedKingdomPostcodeAPI.Services
{
    public class PostcodeService : IPostcodeService
    {
        private readonly DataContext _context;

        public PostcodeService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<PostcodeModel>> AddPostcode(PostcodeModel postcode)
        {
            _context.Postcodes.Add(postcode);
            await _context.SaveChangesAsync();
            return await _context.Postcodes.ToListAsync();
        }

        public async Task<List<PostcodeModel>> PrePopulatePostcodes()
        {
            var postcodes = new List<PostcodeModel>();
            using (var reader = new StreamReader(@"C:\Users\ryan\source\repos\UnitedKingdomPostcodeAPI\UnitedKingdomPostcodeAPI\postcodedata.csv"))
            {
                while (!reader.EndOfStream)
                {
                    PostcodeModel postcodeEntry = new PostcodeModel();

                    string? line = reader.ReadLine();
                    var values = line!.Split(",");

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

                    _context.Postcodes.Add(postcodeEntry);
                }
            }
            await _context.SaveChangesAsync();
            return await _context.Postcodes.ToListAsync();
        }

        public async Task<List<PostcodeModel>?> DeletePostcode(int id)
        {
            var postcode = await _context.Postcodes.FindAsync(id);

            if (postcode is null)
            {
                return null;
            }

            _context.Postcodes.Remove(postcode);
            await _context.SaveChangesAsync();
            return await _context.Postcodes.ToListAsync();
        }

        public async Task<List<PostcodeModel>> GetAllPostcodes()
        {
            var postcodes = await _context.Postcodes.ToListAsync();
            return postcodes;
        }

        public async Task<PostcodeModel?> GetSingularPostcode(int id)
        {
            var postcode = await _context.Postcodes.FindAsync(id);
            if (postcode is null)
            {
                return null;
            }
            return postcode;
        }

        public async Task<List<PostcodeModel>?> UpdatePostcode(int id, PostcodeModel updatedPostcode)
        {
            var postcode = await _context.Postcodes.FindAsync(id);

            if (postcode == null)
            {
                return null;
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

            await _context.SaveChangesAsync();

            return await _context.Postcodes.ToListAsync();
        }
    }
}
