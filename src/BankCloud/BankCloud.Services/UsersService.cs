using BankCloud.Data.Context;
using BankCloud.Data.Entities;
using BankCloud.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace BankCloud.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<BankUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly BankCloudDbContext context;

        public UsersService(BankCloudDbContext context,
            UserManager<BankUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public BankUser GetCurrentUser()
        {
            string userId = httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            return this.context.Users
                .Include(user => user.Accounts)
                .ThenInclude(account => account.Currency)
                .SingleOrDefault(user => user.Id == userId);
        }

        public BankUser GetUserByUsername(string username)
        {
            return this.userManager.FindByNameAsync(username)
                .GetAwaiter()
                .GetResult();
        }
    }
}
