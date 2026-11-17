using CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Datas;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Services;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Data;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Principal;



namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Services;

    public class AuthService : IAuthService
{
    private readonly IDbContextFactory<DataContext> _contextFactory;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(IDbContextFactory<DataContext> contextFactory, IPasswordHasher<User> passwordHasher, IHttpContextAccessor httpContextAccessor)
    {
        _contextFactory = contextFactory;
        _passwordHasher = passwordHasher;
        _httpContextAccessor = httpContextAccessor;
    }

    
    public async Task<MethodResult<LoggedInUser>> LoginAsync(LoginModel model)
    {
        var context = _contextFactory.CreateDbContext();

        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == model.Username);
        if (user == null)
            return MethodResult<LoggedInUser>.Fail("Invalid username or password");

        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
        if (passwordVerificationResult != PasswordVerificationResult.Success)
            return MethodResult<LoggedInUser>.Fail("Invalid username or password");

        var loggedInUser = new LoggedInUser(user.Id, user.Name, user.Email);
        return MethodResult<LoggedInUser>.Ok(loggedInUser);
    }

    public async Task<MethodResult> PlatformLoginAsync(LoggedInUser user)
    {
        var httpContext = _httpContextAccessor.HttpContext;

        Claim[] claims = [new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Name),];

        var identity = new ClaimsIdentity(claims, WebConstants.WebAuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await httpContext.SignInAsync(WebConstants.WebAuthenticationScheme, principal);

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

    public Task<MethodResult> PlayFromLoginAsync(LoggedInUser user)
    {
        // Forward to the existing PlatformLoginAsync implementation.
        return PlatformLoginAsync(user);
    }

    public async Task<MethodResult> PlatformLogoutAsync()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        await httpContext.SignOutAsync(WebConstants.WebAuthenticationScheme);
        return MethodResult.Ok();
    }
}
