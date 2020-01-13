namespace NWBA.Model
{
    public class Login
    {
        string LoginId { get; set; }
        int CustomerId { get; set; }
        string PasswordHash { get; set; }
    }
}
