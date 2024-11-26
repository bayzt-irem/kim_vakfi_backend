using Items.Command.Place;
using Items.Dto.Cart;
using Items.Dto.Place;

namespace Business.IService
{
    public interface IPlaceService
    {
        Task<List<AllPlaceInfoDto>> GetAllPlacesAsync();
        Task<PlaceInfoDto> GetPlaceAsync(Guid id);
        Task<Guid> CreatePlaceAsync(CreatePlaceCommand command);
        Task<Guid> UpdatePlaceAsync(UpdatePlaceCommand command);
        Task<bool> DeletePlaceAsync(Guid placeId);
    }
}
