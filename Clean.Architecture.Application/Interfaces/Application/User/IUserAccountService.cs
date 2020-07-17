using Clean.Architecture.Domain.User;

namespace Clean.Architecture.Application.Interfaces.Application.User {
    public interface IUserAccountService {
        long SaveUser(UserAccount userAccount);
        UserAccount Login(string UserName, string Password);
        bool CheckAvailability(string Username);
    }
}
