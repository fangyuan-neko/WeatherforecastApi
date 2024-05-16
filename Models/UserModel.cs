using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Model;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Username), IsUnique = true)]
public class UserModel
{
    [Key]
    [EmailAddress]
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string Token { get; set; }
}