using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Contracts;

public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password);
