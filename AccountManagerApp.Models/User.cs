namespace AccountManagerApp.Models;

public class User
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public ICollection<string> PhoneNumbers { get; set; } = [];
    public bool IsActive { get; set; } = true;

    public Guid AccountId { get; set; }
    public Account Account { get; set; }
}
