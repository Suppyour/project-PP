using API.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CommentsController
{
    [HttpGet]
    public async Task<ActionResult<List<CommentRequest>>> GetComment()
    {
        var getComment = await  
    }
}