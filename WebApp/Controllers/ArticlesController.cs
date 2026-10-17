using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PermissionSample.Web.Controllers;

[ApiController]
[Authorize]
[Permission("article", "read", "write")]
[Route("api/[controller]")]
public class ArticlesController : ControllerBase {
    [HttpGet]
    [Authorize(Policy = Permissions.Article.Read)]
    public IActionResult List() => Ok(new[] { "article-1", "article-2" });

    [HttpPost]
    [Authorize(Policy = Permissions.Article.Write)]
    public IActionResult Create() => StatusCode(StatusCodes.Status201Created);
}
