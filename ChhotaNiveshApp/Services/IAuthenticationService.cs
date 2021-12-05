namespace ChhotaNiveshToolApp.Services
{
    public interface IAuthenticationService
    {
        string Authenticate(string userId, string companyId);
    }
}
