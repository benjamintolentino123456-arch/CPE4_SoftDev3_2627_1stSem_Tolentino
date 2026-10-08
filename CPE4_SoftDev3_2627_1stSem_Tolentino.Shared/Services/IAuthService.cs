using System;
using System.Collections.Generic;
using System.Text;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Datas;
namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Services
{
    public interface IAuthService
    {
        Task<MethodResult> RegisterAsync(RegisterModel model);
        Task<MethodResult> LoginAsync(LoginModel model);
    }
}
