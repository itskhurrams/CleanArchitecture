using Clean.Architecture.Domain.User;

using System.Collections.Generic;
using System.Data.Common;

namespace Clean.Architecture.Domain.Interfaces.User {
    public interface IUserCustomerServiceData {
        IEnumerable<UserCustomerService> GetUserCustomerServicesByUserId(long UserId);
        long DeleteUserCustomerServicesByUserId(long UserId);
        void SaveUserCustomerServices(long UserId, List<UserCustomerService> UserCustomerServiceList, DbTransaction dbTransaction = null);

    }
}
