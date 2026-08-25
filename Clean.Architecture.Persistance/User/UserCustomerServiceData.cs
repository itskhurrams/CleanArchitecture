using Clean.Architecture.Domain.Interfaces.User;
using Clean.Architecture.Domain.User;

using Dapper;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.User {
    public class UserCustomerServiceData : IUserCustomerServiceData {
        private readonly IDbConnection _connection;
        public UserCustomerServiceData(IDbConnection connection) {
            _connection = connection;
        }
        #region SQL Procedures
        private const string PROC_USERCUSTOMERSERVICE_INSERT = "[Core].[Proc_UserCustomerService_Insert]";
        private const string PROC_USERCUSTOMERSERVICE_UPDATE = "[Core].[Proc_UserCustomerService_Update]";
        private const string PROC_USERCUSTOMERSERVICE_GETBYID = "[Core].[Proc_UserCustomerService_GetById]";
        private const string PROC_USERCUSTOMERSERVICE_DELETE = "[Core].[Proc_UserCustomerService_Delete]";
        private const string PROC_USERCUSTOMERSERVICE_GETBYUSERID = "[Core].[Proc_UserCustomerService_GetByUserId]";
        private const string PROC_USERCUSTOMERSERVICE_DELETEBYUSERID = "[Core].[Proc_UserCustomerService_DeleteByUserId]";
        #endregion SQL Procedures
        #region Private Functions
        private long Insert(UserCustomerService _UserCustomerService, DbTransaction dbTransaction = null) {
            try {
                var parameters = new {
                    ID = _UserCustomerService.ID,
                    UserId = _UserCustomerService.UserId,
                    CustomerId = _UserCustomerService.CustomerId,
                    CustomerServiceId = _UserCustomerService.CustomerServiceId,
                    IsActive = _UserCustomerService.IsActive,
                    CreatedBy = _UserCustomerService.CreatedBy,
                };
                return _connection.ExecuteScalar<long?>(PROC_USERCUSTOMERSERVICE_INSERT, parameters, dbTransaction, commandType: CommandType.StoredProcedure) ?? 0;
            }
            catch (Exception ex) {
                throw new Exception("Add", ex);
            }
        }
        private long Update(UserCustomerService _UserCustomerService, DbTransaction dbTransaction = null) {
            try {
                var parameters = new {
                    ID = _UserCustomerService.ID,
                    UserId = _UserCustomerService.UserId,
                    CustomerId = _UserCustomerService.CustomerId,
                    CustomerServiceId = _UserCustomerService.CustomerServiceId,
                    IsActive = _UserCustomerService.IsActive,
                    UpdatedBy = _UserCustomerService.UpdatedBy,
                };
                return _connection.ExecuteScalar<long?>(PROC_USERCUSTOMERSERVICE_UPDATE, parameters, dbTransaction, commandType: CommandType.StoredProcedure) ?? 0;
            }
            catch (Exception ex) {
                throw new Exception("Update", ex);
            }
        }
        private long Delete(long Id, DbTransaction dbTransaction = null) {
            try {
                return _connection.Execute(PROC_USERCUSTOMERSERVICE_DELETE, new { ID = Id }, dbTransaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex) {
                throw new Exception("Delete", ex);
            }
        }
        private long DeleteByUserId(long UserId, DbTransaction dbTransaction = null) {
            try {
                return _connection.Execute(PROC_USERCUSTOMERSERVICE_DELETEBYUSERID, new { UserId }, dbTransaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex) {
                throw new Exception("DeleteByUserId", ex);
            }
        }
        private IEnumerable<UserCustomerService> GetByUserId(long UserId) {
            return _connection.Query<UserCustomerService>(PROC_USERCUSTOMERSERVICE_GETBYUSERID, new { UserId }, commandType: CommandType.StoredProcedure);
        }
        private UserCustomerService GetById(long Id) {
            return _connection.QueryFirstOrDefault<UserCustomerService>(PROC_USERCUSTOMERSERVICE_GETBYID, new { ID = Id }, commandType: CommandType.StoredProcedure);
        }
        #endregion Private Functions
        #region Public Functions
        public void SaveUserCustomerServices(long UserId, List<UserCustomerService> UserCustomerServiceList, DbTransaction dbTransaction = null) {
            DeleteByUserId(UserId, dbTransaction);
            if (UserCustomerServiceList != null && UserCustomerServiceList.Count > 0) {
                foreach (UserCustomerService userCustomerService in UserCustomerServiceList) {
                    userCustomerService.UserId = UserId;
                    userCustomerService.IsActive = true;
                    Insert(userCustomerService, dbTransaction);
                }
            }
        }
        public IEnumerable<UserCustomerService> GetUserCustomerServicesByUserId(long UserId) {
            return GetByUserId(UserId);
        }

        public long DeleteUserCustomerServicesByUserId(long UserId) {
            return DeleteByUserId(UserId);
        }

        #endregion
    }
}
