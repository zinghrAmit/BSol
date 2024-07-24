using BSol.API.DTOs.Auth;
using BSol.API.Models.Requests;

namespace BSol.API.Services.Auth
{
    public interface IAuthServices
    {
        Task<NResponse> RegisterAsync(RequestRegister request);
    }
}