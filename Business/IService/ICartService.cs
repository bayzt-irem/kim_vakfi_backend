using Items.Command.Cart;
using Items.Dto.Cart;

namespace Business.IService
{
    public interface ICartService
    {
        Task<List<CartInfoDto>> GetAllCartsAsync();
        Task<Guid> CreateCartAsync(CreateCartCommand command);
        Task<Guid> UpdateCartAsync(UpdateCartCommand command);
        Task<bool> DeleteCartAsync(Guid cartId);
    }
}
