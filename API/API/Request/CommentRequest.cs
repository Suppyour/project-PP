using System.ComponentModel.DataAnnotations;

namespace API.Request;

    public record CommentRequest(
    [Required] Guid Id,
    [Required] string UserName,
    [Required] string Comment);
