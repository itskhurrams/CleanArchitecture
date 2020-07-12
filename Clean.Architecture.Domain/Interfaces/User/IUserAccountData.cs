using Clean.Architecture.Domain.User;
using System.Collections.Generic;

namespace Clean.Architecture.Domain.Interfaces.User
{
    public interface IUserAccountData
    {
        IEnumerable<UserAccount> GetUsers();
        UserAccount GetUserById(long Id);
        long SaveUser(UserAccount userAccount);
        UserAccount Login(string UserName, string Password);
        bool CheckAvailability(string Username);
        long DeleteUser(long Id);
    }
}
