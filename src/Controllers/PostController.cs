using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;
using Tryitter.Model;

namespace Tryitter.Controllers;


[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
  public PostRepository _context;

  public PostController(PostRepository context)
  {
    _context = context;
  }

  [HttpGet]
  public ActionResult Get()
  {
    var posts = _context.GetPosts();

    return Ok(posts);
  }

  [HttpGet("{Id}")]
  public ActionResult GetPostById(int Id)
  {
    var post = _context.GetPostById(Id);

    if (post == null) return NotFound();

    return Ok(post);
  }

  [HttpPost]
  public ActionResult AddPost(PostModel Post)
  {
    var createPost = _context.AddPost(Post);

    return CreatedAtRoute("done", createPost);
  }

  [HttpPut]
  public ActionResult UpdatePost(PostModel Post)
  {
    var post = _context.GetPostById(Post.PostId);
    if (post == null) return BadRequest();

    _context.UpdatePost(post);

    return NoContent();
  }

  [HttpDelete("{Id}")]
  public ActionResult DeletePost(int Id)
  {
    var post = _context.GetPostById(Id);
    if (post == null) return BadRequest();

    _context.DeletePost(Id);
    return NoContent();
  }
}
