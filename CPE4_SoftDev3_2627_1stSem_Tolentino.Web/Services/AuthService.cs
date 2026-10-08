using CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Datas;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Services;
using Microsoft.EntityFrameworkCore;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Data;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Services;

    public class AuthService : IAuthService
{
    private readonly IDbContextFactory<DataContext> _contextFactory;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthService(IDbContextFactory<DataContext> contextFactory,IPasswordHasher<User> passwordHasher)
    {
        _contextFactory = contextFactory;
        _passwordHasher = passwordHasher;
    }
    public async Task<MethodResult> LoginAsync(LoginModel model)
    {
        var context = _contextFactory.CreateDbContext();

        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
        if (user == null)
        
            return MethodResult.Fail("Invalid email or password");

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
        if (passwordVerificationResult == PasswordVerificationResult.Success)
         
             return MethodResult.Fail("Incorrect Password");
            return MethodResult.Ok();
        
    }
    public async Task<MethodResult> RegisterAsync(RegisterModel model)
    {
        var context = _contextFactory.CreateDbContext();
        var isEmailExist = await context.Users.AnyAsync(u => u.Email == model.Email);
        if (isEmailExist)
        {
            return MethodResult.Fail("Email exists already");
        }

        var user = new User
        {
            Name = model.Name,
            Email = model.Email
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return MethodResult.Ok();
    }
}
