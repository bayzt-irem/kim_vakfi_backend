using Items.Command.Cart;
using Items.Command.User;
using Items.Dto.Cart;
using Items.Dto.User;

namespace Business.IService
{
    public interface ICartService
    {
        Task<List<CartInfoDto>> GetAllCartsAsync();
        Task<Guid> CreateCartAsync(CreateCartCommand command);
        Task<Guid> UpdateCartAsync(UpdateCartCommand command);
    }
}
