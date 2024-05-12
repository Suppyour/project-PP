using System.ComponentModel.DataAnnotations;

namespace API.Request;

public record RegisterRequest(
    [Required] string UserName,
    [Required] string Password,
    [Required] string Email);