using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace CollabMe.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int? GetUserId(this ClaimsPrincipal principal) =>
        int.TryParse(principal.FindFirstValue(JwtRegisteredClaimNames.Sub), out var id) ? id : null;

    public static int RequireUserId(this ClaimsPrincipal principal) =>
        principal.GetUserId() ?? throw new InvalidOperationException("The authenticated user has no id claim.");
}
