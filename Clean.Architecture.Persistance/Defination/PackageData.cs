using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using Dapper;

using System.Collections.Generic;
using System.Data;

namespace Clean.Architecture.Persistance.Defination {
    public class PackageData : IPackageData {
        private readonly IDbConnection _connection;
        public PackageData(IDbConnection connection) {
            _connection = connection;
        }
        #region SQL Procedures
        private const string PROC_PACKAGE_GETALL = "[Defination].[Proc_Package_GetAll]";
        private const string PROC_PACKAGE_GETBYID = "[Defination].[Proc_Package_GetById]";
        #endregion SQL Procedures
        #region Private Functions
        private IEnumerable<Package> GetActivePackages() {
            return _connection.Query<Package>(PROC_PACKAGE_GETALL, commandType: CommandType.StoredProcedure);
        }
        private Package GetPackage(int Id) {
            return _connection.QueryFirstOrDefault<Package>(PROC_PACKAGE_GETBYID, new { ID = Id }, commandType: CommandType.StoredProcedure);
        }
        #endregion Private Functions
        #region Public Functions
        public Package GetPackageById(int Id) {
            return GetPackage(Id);
        }
        public IEnumerable<Package> GetPackages() {
            return GetActivePackages();
        }
        #endregion
    }
}
