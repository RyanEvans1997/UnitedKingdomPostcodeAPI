using UnitedKingdomPostcodeAPI.Models;

namespace UnitedKingdomPostcodeAPI.Services
{
    public class PostcodeService : IPostcodeService
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

                    postcodes.Add(postcodeEntry);

                }
            }

            return postcodes;
        }
        public List<PostcodeModel> AddPostcode(PostcodeModel postcode)
        {
            postcodes.Add(postcode);
            return postcodes;
        }

        public List<PostcodeModel>? DeletePostcode(int id)
        {
            var postcode = postcodes.Find(x => x.Id == id);

            if (postcode is null)
            {
                return null;
            }

            postcodes.Remove(postcode);
            return postcodes;
        }

        public List<PostcodeModel> GetAllPostcodes()
        {
            return postcodes;
        }

        public PostcodeModel? GetSingularPostcode(int id)
        {
            var postcode = postcodes.Find(x => x.Id == id);
            if (postcode is null)
            {
                return null;
            }
            return postcode;
        }

        public List<PostcodeModel>? UpdatePostcode(int id, PostcodeModel updatedPostcode)
        {
            var postcode = postcodes.Find(x => x.Id == id);

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

            return postcodes;
        }
    }
}
