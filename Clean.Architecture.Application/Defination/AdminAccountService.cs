using Clean.Architecture.Application.Interfaces.Application.Defination;
using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using System;
namespace Clean.Architecture.Application.Defination {
    public class AdminAccountService : IAdminAccountService {
        private readonly IAdminAccountData _adminAccountData;
        public AdminAccountService(IAdminAccountData adminAccountData) {
            _adminAccountData = adminAccountData;
        }
        public AdminAccount Login(string UserName, string Password) {
            try {
                return _adminAccountData.Login(UserName, Password);
            }
            catch (Exception exception) {
                throw exception;
            }
        }
    }
}
