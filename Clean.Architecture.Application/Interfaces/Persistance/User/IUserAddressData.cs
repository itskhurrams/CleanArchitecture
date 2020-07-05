using Clean.Architecture.Domain.User;
using System.Collections.Generic;
using System.Data.Common;

namespace Clean.Architecture.Application.Interfaces.Persistance.User
{
    public interface IUserAddressData
    {
        IEnumerable<UserAddress> GetAddressesByUserId(long UserId);
        long DeleteAddressesByUserId(long UserId);
        void SaveUserAddresses(long UserId, List<UserAddress> userAddressList, DbTransaction dbTrasection = null);
    }
}
