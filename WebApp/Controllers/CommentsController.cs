using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PermissionSample.Web.Controllers;

[ApiController]
[Authorize]
[Permission("comment", "read", "write", "moderate")]
[Route("api/[controller]")]
public class CommentsController : ControllerBase {
    [HttpGet]
    [Authorize(Policy = Permissions.Comment.Read)]
    public IActionResult List() => Ok(new[] { "comment-1", "comment-2" });

    [HttpPost]
    [Authorize(Policy = Permissions.Comment.Write)]
    public IActionResult Create() => StatusCode(StatusCodes.Status201Created);

    [HttpDelete("{id:int}")]
    [Authorize(Policy = Permissions.Comment.Moderate)]
    public IActionResult Delete(int id) => NoContent();
}
