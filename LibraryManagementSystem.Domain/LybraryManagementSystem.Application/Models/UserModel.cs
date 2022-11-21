using Microsoft.AspNetCore.Identity;

namespace LybraryManagementSystem.Application;

public class UserModel
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Hash { get; set; }
    public string Salt { get; set; }
    public string Password { get; set; }

}
