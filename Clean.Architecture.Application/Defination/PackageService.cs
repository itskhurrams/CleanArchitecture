using Clean.Architecture.Application.Interfaces.Application.Defination;
using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using System;
using System.Collections.Generic;
namespace Clean.Architecture.Application.Defination
{
    public class PackageService : IPackageService
    {
        private readonly IPackageData _packageData;
        public PackageService(IPackageData packageData)
        {
            _packageData = packageData;
        }
        public IEnumerable<Package> GetPackages()
        {
            try
            {
                return _packageData.GetPackages();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
