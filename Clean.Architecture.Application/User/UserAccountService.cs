using Clean.Architecture.Application.Interfaces.Application.User;
using Clean.Architecture.Domain.Interfaces.User;
using Clean.Architecture.Domain.User;

using System;

namespace Clean.Architecture.Application.User {
    public class UserAccountService : IUserAccountService {
        private readonly IUserAccountData _userAccountData;

        public UserAccountService(IUserAccountData userAccountData) {
            _userAccountData = userAccountData;
        }
        public bool CheckAvailability(string Username) {
            try {
                return _userAccountData.CheckAvailability(Username);
            }
            catch (Exception exception) {

                throw exception;
            }
        }

        public UserAccount Login(string UserName, string Password) {
            try {
                return _userAccountData.Login(UserName, Password);
            }
            catch (Exception exception) {

                throw exception;
            }
        }

        public long SaveUser(UserAccount userAccount) {
            try {
                return _userAccountData.SaveUser(userAccount);
            }
            catch (Exception exception) {

                throw exception;
            }
        }
    }
}
