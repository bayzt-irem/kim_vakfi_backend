using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Items.Types
{
    public class ContextAccessor : HttpContextAccessor, IContextAccessor
    {
        public Guid UserId
        {
            get
            {
                if (HttpContext == null || HttpContext.User == null)
                {
                    return Guid.Empty;
                }

                return HttpContext.User.HasClaim(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                ? Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value)
                : Guid.Empty;

            }
        }
    }
}
