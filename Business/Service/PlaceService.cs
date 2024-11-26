using Business.IService;
using Data.Infrastructure;
using Items.Command.Place;
using Items.Dto.Cart;
using Items.Dto.Place;
using Items.Entities;
using Items.Types;
using Microsoft.EntityFrameworkCore;

namespace Business.Service
{
    public class PlaceService : ServiceBase, IPlaceService
    {
        private readonly AppDbContext _context; 
        private readonly IContextAccessor _contextAccessor;

        public PlaceService(AppDbContext context, IContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<Guid> CreatePlaceAsync(CreatePlaceCommand command)
        {
            var place = new Place
            {
                Name = command.Name,
                Description = command.Description,
                District = command.District,
                City = command.City,
                ImageUrl = command.ImageUrl,
            };
            await _context.Places.AddAsync(place);
            await _context.SaveChangesAsync();
            return place.Id;
        }

        public async Task<List<AllPlaceInfoDto>> GetAllPlacesAsync()
        {
            return await _context.Places.Include(x => x.CreatedBy).Include(x => x.ModifiedBy).Select(x => new AllPlaceInfoDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                City = x.City,
                District = x.District,
                ImageUrl = x.ImageUrl,
                CreateByUserName = x.CreatedBy.Name,
                UpdateByUserName = x.ModifiedBy.Name,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt,
            }).ToListAsync();
        }

        public async Task<PlaceInfoDto> GetPlaceAsync(Guid id)
        {
            var result = await _context.Places.Include(x => x.CreatedBy).Include(x => x.ModifiedBy)
                .Select(x => new PlaceInfoDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    City = x.City,
                    District = x.District,
                    ImageUrl = x.ImageUrl,
                    CreateByUserName = x.CreatedBy.Name, 
                    UpdateByUserName = x.ModifiedBy.Name,
                    CreatedAt = x.CreatedAt,
                    ModifiedAt = x.ModifiedAt,
                    Carts = x.Carts.Select(c => new CartInfoDto
                    {
                        Id = c.Id,
                        Title = c.Title, 
                        Description = c.Description,
                        Yaw = c.Yaw,
                        Pitch = c.Pitch,
                        CreatedAt = c.CreatedAt,
                        ModifiedAt = c.ModifiedAt,
                        CreateByUserName = c.CreatedBy.Name,
                        UpdateByUserName = c.ModifiedBy.Name
                    }).ToList()
                }).FirstOrDefaultAsync(x => x.Id == id);

            if(result == null)
            {
                throw new Exception("Place is not found!");
            }
            return result;
        }

        public async Task<Guid> UpdatePlaceAsync(UpdatePlaceCommand command)
        {
            var place = await _context.Places.FirstOrDefaultAsync(x => x.Id == command.Id);
            if (place == null)
            {
                throw new Exception("Place is not found!");
            }

            place.Name = command.Name;
            place.Description = command.Description;
            place.District = command.District;
            place.City = command.City;
            
            await _context.SaveChangesAsync();
            return place.Id;
        }

        public async Task<bool> DeletePlaceAsync(Guid placeId)
        {
            try
            {
                var place = await _context.Places.FirstOrDefaultAsync(x => x.Id == placeId);
                if (place == null)
                {
                    throw new ArgumentException("Place is not found!");
                }
                _context.Places.Remove(place);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
