using BankCloud.Data.Entities;

namespace BankCloud.Services.Interfaces
{
    public interface IUsersService
    {
        BankUser GetUserByUsername(string username);

        BankUser GetCurrentUser();
    }
}
