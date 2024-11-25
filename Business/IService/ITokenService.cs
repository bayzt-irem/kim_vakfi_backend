using Items.Entities;
using Items.Types;

namespace Business.IService
{
    public interface ITokenService
    {
        AccessToken CreateToken(User user);
    }
}
