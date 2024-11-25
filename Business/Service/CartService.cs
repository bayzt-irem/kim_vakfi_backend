using Business.IService;
using Data.Infrastructure;
using Items.Command.Cart;
using Items.Dto.Cart;
using Items.Dto.User;
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
            return await _context.Carts.Include(x => x.CreateByUser).Include(x => x.UpdateByUser).Select(x => new CartInfoDto
            {
                Id = x.Id,  
                Title = x.Title ,
                Description = x.Description , 
                PositionYaw = x.PositionYaw ,
                PositionPitch = x.PositionPitch ,
                CreateByUserName = x.CreateByUser.Name,
                UpdateByUserName = x.UpdateByUser.Name,
                CreatedAt = x.CreatedAt ,
                ModifiedAt = x.ModifiedAt
            }).ToListAsync();
        }

        public async Task<Guid> CreateCartAsync(CreateCartCommand command)
        {
            var cart = new Cart
            {
                Title = command.Title,
                Description = command.Description,
                PositionYaw = command.PositionYaw,
                PositionPitch = command.PositionPitch,
                CreateByUserId = _contextAccessor.UserId,
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
            cart.PositionYaw = command.PositionYaw;
            cart.PositionPitch = command.PositionPitch;
            cart.UpdateByUserId = _contextAccessor.UserId;
            await _context.SaveChangesAsync();
            return cart.Id;
        }
    }
}
