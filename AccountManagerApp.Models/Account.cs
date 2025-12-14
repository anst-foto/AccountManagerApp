using System;
using System.Collections.Generic;

namespace AccountManagerApp.Models;

public class Account
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Login { get; set; }
    public string Password { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public ICollection<string> PhoneNumbers { get; set; } = [];

    public string ShortId => Id.ToString()[..8];
    public string FullName => $"{LastName} {FirstName}";
}
