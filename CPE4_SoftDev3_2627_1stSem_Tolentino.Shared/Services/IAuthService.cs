using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Datas;
namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Services
{
    public interface IAuthService
    {
        Task<MethodResult> RegisterAsync(RegisterModel model);
        Task<MethodResult<LoggedInUser>> LoginAsync(LoginModel model);
        Task<MethodResult> PlatformLoginAsync(LoggedInUser user);
        Task<MethodResult> PlayFromLoginAsync(LoggedInUser user);
        Task<MethodResult> PlatformLogoutAsync();
    }
}
