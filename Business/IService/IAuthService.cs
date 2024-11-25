using Core.Security.JWT;
using Items.Command.User;
using Items.Dto.User;
using Items.Entities;

namespace Business.IService
{
    public interface IAuthService
    {
        Task<LoginUserInfo> Current();
        Task<LoginUserInfo> Login(LoginCommand command);
        Task<LoginUserInfo> Register(RegisterCommand command);
    }
}
