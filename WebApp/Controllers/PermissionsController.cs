using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PermissionSample.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionsController : ControllerBase {
    /// <summary>システムに存在する全権限(権限設定画面の選択肢などに使う)。</summary>
    [HttpGet]
    [AllowAnonymous]
    public IActionResult All() => Ok(PermissionCatalog.All);

    /// <summary>ログイン中のユーザーが持つ権限。</summary>
    [HttpGet("me")]
    [Authorize]
    public IActionResult Me() => Ok(PermissionCatalog.GetGranted(User));
}
