using Microsoft.AspNetCore.Http;

namespace Items.Types
{
    public interface IContextAccessor : IHttpContextAccessor
    {
        Guid UserId { get; }
    }
}
