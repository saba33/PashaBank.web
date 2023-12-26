namespace PashaBank.Services.Abstractions.Auth
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string role);
    }
}
