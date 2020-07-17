using Clean.Architecture.Domain.User;

using System.Collections.Generic;
using System.Data.Common;

namespace Clean.Architecture.Domain.Interfaces.User {
    public interface IUserPackageData {
        IEnumerable<UserPackage> GetPackagesByUserId(long UserId);
        long DeletePackagesByUserId(long UserId);
        void SaveUserPackages(long UserId, List<UserPackage> UserPackageList, DbTransaction dbTransaction = null);

    }
}
