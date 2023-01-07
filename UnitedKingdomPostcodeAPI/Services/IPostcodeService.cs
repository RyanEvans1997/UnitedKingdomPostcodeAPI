using UnitedKingdomPostcodeAPI.Models;

namespace UnitedKingdomPostcodeAPI.Services
{
    public interface IPostcodeService
    {
        Task<List<PostcodeModel>> GetAllPostcodes();

        Task<PostcodeModel?> GetSingularPostcode(int id);

        Task<List<PostcodeModel>> AddPostcode(PostcodeModel postcode);

        Task<List<PostcodeModel>> PrePopulatePostcodes();

        Task<List<PostcodeModel>?> UpdatePostcode(int id, PostcodeModel postcode);

        Task<List<PostcodeModel>?> DeletePostcode(int id);
    }
}
