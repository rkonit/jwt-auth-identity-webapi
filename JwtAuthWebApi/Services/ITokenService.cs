namespace JwtAuthWebApi.Services
{
    public interface ITokenService
    {
        Task<string> GetAccessTokenAsync(string userName);
    }
}