using Business.IService;
using Core.Security.Hasing;
using Core.Security.JWT;
using Data.Infrastructure;
using Items.Command.User;
using Items.Dto.User;
using Items.Entities;
using Items.Types;
using Microsoft.EntityFrameworkCore;

namespace Business.Service
{
    public class AuthService : ServiceBase, IAuthService
    {
        private readonly AppDbContext _context;
        private ITokenHelper _tokenHelper;
        private ITokenService _tokenService;
        private readonly IContextAccessor _contextAccessor;

        public AuthService(AppDbContext context, ITokenHelper tokenHelper, ITokenService tokenService, IContextAccessor contextAccessor)
        {
            _context = context;
            _tokenHelper = tokenHelper;
            _tokenService = tokenService;
            _contextAccessor = contextAccessor;
        }

        public async Task<LoginUserInfo> Current()
        {
            Console.WriteLine("Current worked"); 

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == _contextAccessor.UserId);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

            var accessToken = _tokenHelper.CreateToken(user);

            var result = new LoginUserInfo
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Token = accessToken.Token,
                TokenExpiration = accessToken.Expiration
            };
            return result;
        }

        public async Task<LoginUserInfo> Login(LoginCommand command)
        {
            Console.WriteLine("Login worked");
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == command.Email);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }
            if (!HashingHelper.VerifyPasswordHash(command.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Şifre yanlış");
            }

            var accessToken = _tokenHelper.CreateToken(user);

            var result = new LoginUserInfo
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Token = accessToken.Token,
                TokenExpiration = accessToken.Expiration
            };
            return result;
        }

        public async Task<LoginUserInfo> Register(RegisterCommand command)
        {
            Console.WriteLine("Register worked");

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == command.Email);
            if (user != null)
            {
                throw new Exception("User is exist!");
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(command.Password, out passwordHash, out passwordSalt);
            var newUser = new User
            {
                Email = command.Email,
                Name = command.Name,
                Surname = command.Surname,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            var token = _tokenService.CreateToken(newUser);

            var result = new LoginUserInfo
            {
                Name = newUser.Name,
                Surname = newUser.Surname,
                Email = newUser.Email,
                Token = token.Token, 
                TokenExpiration = token.Expiration
            };
            return result;
        }
    }
}
