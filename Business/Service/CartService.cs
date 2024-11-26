using Business.IService;
using Data.Infrastructure;
using Items.Command.Cart;
using Items.Dto.Cart;
using Items.Entities;
using Items.Types;
using Microsoft.EntityFrameworkCore;

namespace Business.Service
{
    public class CartService : ServiceBase, ICartService
    {
        private readonly AppDbContext _context;
        private readonly IContextAccessor _contextAccessor;

        public CartService(AppDbContext context, IContextAccessor contextAccessor)
        {
            _context = context; 
            _contextAccessor = contextAccessor; 
        } 

        public async Task<List<CartInfoDto>> GetAllCartsAsync()
        {
            return await _context.Carts.Include(x => x.CreatedBy).Include(x => x.ModifiedBy).Select(x => new CartInfoDto
            {
                Id = x.Id,  
                Title = x.Title ,
                Description = x.Description , 
                Yaw = x.Yaw ,
                Pitch = x.Pitch ,
                CreateByUserName = x.CreatedBy.Name,
                UpdateByUserName = x.ModifiedBy.Name,
                CreatedAt = x.CreatedAt ,
                ModifiedAt = x.ModifiedAt
            }).ToListAsync();
        }

        public async Task<Guid> CreateCartAsync(CreateCartCommand command)
        {
            var place = await _context.Places.FirstOrDefaultAsync(x => x.Id == command.PlaceId);
            if (place == null)
            {
                throw new Exception("Place is not found!");
            }

            var cart = new Cart
            {
                PlaceId = command.PlaceId,
                Title = command.Title,
                Description = command.Description,
                Yaw = command.Yaw,
                Pitch = command.Pitch,
            };

            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart.Id;
        }
      
        public async Task<Guid> UpdateCartAsync(UpdateCartCommand command)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.Id == command.Id);
            if (cart == null)
            {
                throw new ArgumentException("Cart is not found!");
            }
            cart.Title = command.Title;
            cart.Description = command.Description;
            cart.Yaw = command.PositionYaw;
            cart.Pitch = command.PositionPitch; 
            await _context.SaveChangesAsync();
            return cart.Id;
        }
      
        public async Task<bool> DeleteCartAsync(Guid cartId)
        {
            try
            {
                var cart = await _context.Carts.FirstOrDefaultAsync(x => x.Id == cartId);
                if (cart == null)
                {
                    throw new ArgumentException("Cart is not found!");
                }
                _context.Carts.Remove(cart);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
