using UnitedKingdomPostcodeAPI.Models;

namespace UnitedKingdomPostcodeAPI.Services
{
    public interface IPostcodeService
    {
        List<PostcodeModel> GetAllPostcodes();

        PostcodeModel GetSingularPostcode(int id);

        List<PostcodeModel> AddPostcode(PostcodeModel postcode);

        List<PostcodeModel> UpdatePostcode(int id, PostcodeModel postcode);

        List<PostcodeModel> DeletePostcode(int id);
    }
}
