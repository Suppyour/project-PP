using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class LikeController : ControllerBase
{
    public static List<Post> Posts = new();

    [HttpPost("Like")]
    public ActionResult AddLikes([FromBody] Post postId)
    {
        var post = Posts.FirstOrDefault(p => p.Id == postId.Id);
        if (post == null)
        {
            return NotFound();
        }
        post.Like++;
        return Ok(post);
    }
    [HttpGet("Marks")]
    public ActionResult<List<Post>> Get()
    {
        return Ok(Posts);
    }
}




// доделать на этом моменте TODO 