namespace AdaSigortaAppYeniWebApi.Models
{
    public class AuthenticateUser
    {
        public string? Token { get; set; }
        public User user { get; set; }
    }
}
