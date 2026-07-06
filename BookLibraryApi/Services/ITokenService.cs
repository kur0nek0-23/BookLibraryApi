// Services/ITokenService.cs
using BookLibraryApi.Models;
public interface ITokenService
{
    string CreateToken(User user);
}