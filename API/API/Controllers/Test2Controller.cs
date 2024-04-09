using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Test2Controller : ControllerBase
    {
        public static List<Comment> Comments = new();
        
        [HttpPost("")]
        public ActionResult AddComm([FromBody] Comment comment)
        {
            Comments.Add(comment);
            return Ok();
        }
        
        [HttpGet("")]
        public ActionResult<List<Comment>> Get()
        {
            return Ok(Comments);
        }
        [HttpDelete("")]
        public ActionResult DeleteComm([FromQuery] int Id)
        {
            var commToDelete = Comments.FirstOrDefault(s => s.Id == Id);
            Comments.Remove(commToDelete);
            return Ok();    
        }
        
        public class Comment
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public string Author { get; set; }
        }
        
    }
}
