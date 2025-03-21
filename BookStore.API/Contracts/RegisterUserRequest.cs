using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Contracts;

public record RegisterUserRequest(
    [Required] string UserName,
    [Required] string Email,
    [Required] string Password);
