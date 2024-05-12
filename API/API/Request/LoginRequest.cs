using System.ComponentModel.DataAnnotations;

namespace API.Request;

public record LoginRequest(
    [Required] string Email,
    [Required] string Password);