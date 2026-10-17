using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PermissionSample.Web.Controllers;

/// <summary>
/// デモ用のログイン。指定した権限をクレームとして持つユーザーとしてサインインする。
/// 誰でも好きな権限を付けられるので、本番では使用しないこと。
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase {
    /// <summary>
    /// POST /api/login?permissions=article:read&amp;permissions=article:write
    /// </summary>
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromQuery] string[] permissions) {
        var claims = new List<Claim> { new(ClaimTypes.Name, "demo-user") };
        foreach (var permission in permissions) {
            var parts = permission.Split(':', 2);
            if (parts.Length == 2) {
                claims.Add(new Claim(parts[0], parts[1]));
            }
        }

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(new ClaimsPrincipal(identity));
        return NoContent();
    }
}
