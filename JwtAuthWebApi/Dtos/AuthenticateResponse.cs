namespace JwtAuthWebApi.Dtos;

public class AuthenticateResponse
{
    public bool Result { get; set; } = false;
    public string AccessToken { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public bool IsLockedOut { get; set; } = false;
    public bool IsNotAllowed { get; set; } = false;
    public bool RequiresTwoFactor { get; set; } = false;
}