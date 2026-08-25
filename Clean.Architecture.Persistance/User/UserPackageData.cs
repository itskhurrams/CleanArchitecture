using Clean.Architecture.Domain.Interfaces.User;
using Clean.Architecture.Domain.User;

using Dapper;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.User {
    public class UserPackageData : IUserPackageData {
        private readonly IDbConnection _connection;
        public UserPackageData(IDbConnection connection) {
            _connection = connection;
        }
        #region SQL Procedures
        private const string PROC_USERPACKAGE_INSERT = "[Core].[Proc_UserPackage_Insert]";
        private const string PROC_USERPACKAGE_UPDATE = "[Core].[Proc_UserPackage_Update]";
        private const string PROC_USERPACKAGE_GETBYID = "[Core].[Proc_UserPackage_GetById]";
        private const string PROC_USERPACKAGE_DELETE = "[Core].[Proc_UserPackage_Delete]";
        private const string PROC_USERPACKAGE_GETBYUSERID = "[Core].[Proc_UserPackage_GetByUserId]";
        private const string PROC_USERPACKAGE_DELETEBYUSERID = "[Core].[Proc_UserPackage_DeleteByUserId]";
        #endregion SQL Procedures
        #region Private Functions
        private long Insert(UserPackage _UserPackage, DbTransaction dbTransaction = null) {
            try {
                var parameters = new {
                    ID = _UserPackage.ID,
                    UserId = _UserPackage.UserId,
                    PackageId = _UserPackage.PackageId,
                    IsActive = _UserPackage.IsActive,
                    CreatedBy = _UserPackage.CreatedBy,
                };
                return _connection.ExecuteScalar<long?>(PROC_USERPACKAGE_INSERT, parameters, dbTransaction, commandType: CommandType.StoredProcedure) ?? 0;
            }
            catch (Exception ex) {
                throw new Exception("Add", ex);
            }
        }
        private long Update(UserPackage _UserPackage, DbTransaction dbTransaction = null) {
            try {
                var parameters = new {
                    ID = _UserPackage.ID,
                    UserId = _UserPackage.UserId,
                    PackageId = _UserPackage.PackageId,
                    IsActive = _UserPackage.IsActive,
                    UpdatedBy = _UserPackage.UpdatedBy,
                };
                return _connection.ExecuteScalar<long?>(PROC_USERPACKAGE_UPDATE, parameters, dbTransaction, commandType: CommandType.StoredProcedure) ?? 0;
            }
            catch (Exception ex) {
                throw new Exception("Update", ex);
            }
        }
        private long Delete(long Id, DbTransaction dbTransaction = null) {
            try {
                return _connection.Execute(PROC_USERPACKAGE_DELETE, new { ID = Id }, dbTransaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex) {
                throw new Exception("Delete", ex);
            }
        }
        private long DeleteByUserId(long UserId, DbTransaction dbTransaction = null) {
            try {
                return _connection.Execute(PROC_USERPACKAGE_DELETEBYUSERID, new { UserId }, dbTransaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex) {
                throw new Exception("DeleteByUserId", ex);
            }
        }
        private IEnumerable<UserPackage> GetByUserId(long UserId) {
            return _connection.Query<UserPackage>(PROC_USERPACKAGE_GETBYUSERID, new { UserId }, commandType: CommandType.StoredProcedure);
        }
        private UserPackage GetById(long Id) {
            return _connection.QueryFirstOrDefault<UserPackage>(PROC_USERPACKAGE_GETBYID, new { ID = Id }, commandType: CommandType.StoredProcedure);
        }
        #endregion Private Functions
        #region Public Functions
        public void SaveUserPackages(long UserId, List<UserPackage> UserPackageList, DbTransaction dbTransaction = null) {
            DeleteByUserId(UserId, dbTransaction);
            if (UserPackageList != null && UserPackageList.Count > 0) {
                foreach (UserPackage userPackage in UserPackageList) {
                    userPackage.UserId = UserId;
                    userPackage.IsActive = true;
                    Insert(userPackage, dbTransaction);
                }
            }
        }
        public IEnumerable<UserPackage> GetPackagesByUserId(long UserId) {
            return GetByUserId(UserId);
        }

        public long DeletePackagesByUserId(long UserId) {
            return DeleteByUserId(UserId);
        }

        #endregion
    }
}
