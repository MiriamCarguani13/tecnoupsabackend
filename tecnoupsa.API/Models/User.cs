namespace TecnoupsaBackend.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } // En producción, usa hashing (e.g., bcrypt)
    public string Role { get; set; }
}