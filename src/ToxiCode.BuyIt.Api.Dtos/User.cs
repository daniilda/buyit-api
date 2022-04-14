namespace ToxiCode.BuyIt.Api.Dtos;

public class User
{
    public long Id { get; set; }
    
    public string Username { get; set; } = null!;

    public string Name { get; set; } = null!;
    
    public DateTime RegistrationDate { get; set; }

    public Picture ProfilePicture { get; set; } = null!;
}