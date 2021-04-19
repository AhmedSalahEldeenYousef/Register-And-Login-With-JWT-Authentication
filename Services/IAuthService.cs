using System.Threading.Tasks;
using TtryJWTToken.Data;

namespace TtryJWTToken.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel input);
    }
}