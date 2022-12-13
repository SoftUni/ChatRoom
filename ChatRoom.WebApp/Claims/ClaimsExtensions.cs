using System.Security.Claims;

namespace ChatRoom.WebApp.Claims
{
    public static class ClaimsExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
