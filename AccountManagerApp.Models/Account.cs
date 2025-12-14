using System;

namespace AccountManagerApp.Models;

public class Account
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Login { get; set; }
    public string Password { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public User User { get; set; }
}
