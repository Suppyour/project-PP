using API.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class CommentController : ControllerBase
    {
        /// <summary>
        ///  Тут должен быть пост коммента
        /// </summary>
        /// <remarks>
        ///  Тут эээ ну что то должно же быть тоже
        /// </remarks>
        /// <returns></returns>
        public static List<User> Comments = new();
        
        [HttpPost("")]
        public ActionResult AddComm([FromBody] User user)
        {
            Comments.Add(user);
            return Ok();
        }
        /// <summary>
        ///  Тут сервак должен принять этот пост
        /// </summary>
        /// <remarks>
        ///  Тут эээ ну что то должно же быть тоже
        /// </remarks>
        /// <returns></returns>
        [HttpGet("")]
        public ActionResult<List<User>> Get()
        {
            return Ok(Comments);
        }
        /// <summary>
        ///  Тут сервак должен удалить пост по ID который его оставил
        /// </summary>
        /// <remarks>
        ///  Тут эээ ну что то должно же быть тоже
        /// </remarks>
        /// <returns></returns>
        [HttpDelete("")]
        public ActionResult DeleteComm([FromQuery] Guid Id)
        {
            var commToDelete = Comments.FirstOrDefault(s => s.Id == Id);
            if (commToDelete != null) Comments.Remove(commToDelete);
            return Ok();    
        }
    }
}
// comm for fun