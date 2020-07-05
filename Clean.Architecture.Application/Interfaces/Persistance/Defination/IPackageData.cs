using Clean.Architecture.Domain.Defination;
using System.Collections.Generic;

namespace Clean.Architecture.Application.Interfaces.Persistance.Defination
{
    public interface IPackageData
    {
        IEnumerable<Package> GetPackages();
        Package GetPackageById(int Id);
    }
}
