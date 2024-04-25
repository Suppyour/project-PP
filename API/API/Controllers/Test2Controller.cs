using API.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class Test2Controller : ControllerBase
    {
        
        public static List<User> Comments = new();
        
        [HttpPost("")]
        public ActionResult AddComm([FromBody] User user)
        {
            Comments.Add(user);
            return Ok();
        }
        /// <summary>
        ///  коммент сумм
        /// </summary>
        /// <remarks>
        ///  коммент ремарок
        /// </remarks>
        /// <returns></returns>
        [HttpGet("")]
        public ActionResult<List<User>> Get()
        {
            return Ok(Comments);
        }
        [HttpDelete("")]
        public ActionResult DeleteComm([FromQuery] Guid Id)
        {
            var commToDelete = Comments.FirstOrDefault(s => s.Id == Id);
            Comments.Remove(commToDelete);
            return Ok();    
        }
    }
}
