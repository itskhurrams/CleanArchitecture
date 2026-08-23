using Clean.Architecture.Application.Interfaces.Application.User;
using Clean.Architecture.Domain.Interfaces.User;
using Clean.Architecture.Domain.User;

using System.Collections.Generic;

namespace Clean.Architecture.Application.User {
    public class UserAccountService : IUserAccountService {
        private readonly IUserAccountData _userAccountData;

        public UserAccountService(IUserAccountData userAccountData) {
            _userAccountData = userAccountData;
        }
        public bool CheckAvailability(string Username) {
            return _userAccountData.CheckAvailability(Username);
        }

        public UserAccount GetUserById(long Id) {
            return _userAccountData.GetUserById(Id);
        }

        public IEnumerable<UserAccount> GetUsers() {
            return _userAccountData.GetUsers();
        }

        public UserAccount Login(string UserName, string Password) {
            return _userAccountData.Login(UserName, Password);
        }

        public long SaveUser(UserAccount userAccount) {
            return _userAccountData.SaveUser(userAccount);
        }

        public long DeleteUser(long Id) {
            return _userAccountData.DeleteUser(Id);
        }
    }
}
