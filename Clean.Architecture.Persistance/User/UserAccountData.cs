using Clean.Architecture.Domain.Interfaces.User;
using Clean.Architecture.Domain.User;

using Dapper;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.User {
    public class UserAccountData : IUserAccountData {
        private readonly IDbConnection _connection;
        private readonly IUserAddressData _userAddressData;
        private readonly IUserPackageData _userPackageData;
        private readonly IUserCustomerServiceData _userCustomerServiceData;
        public UserAccountData(IDbConnection connection, IUserAddressData userAddressData, IUserPackageData userPackageData, IUserCustomerServiceData userCustomerServiceData) {
            _connection = connection;
            _userAddressData = userAddressData;
            _userPackageData = userPackageData;
            _userCustomerServiceData = userCustomerServiceData;
        }
        #region SQL Procedures
        private const string PROC_USERACCOUNT_INSERT = "[Core].[Proc_UserAccount_Insert]";
        private const string PROC_USERACCOUNT_UPDATE = "[Core].[Proc_UserAccount_Update]";
        private const string PROC_USERACCOUNT_DELETE = "[Core].[Proc_UserAccount_Delete]";
        private const string PROC_USERACCOUNT_GETALL = "[Core].[Proc_UserAccount_GetAll]";
        private const string PROC_USERACCOUNT_GETBYID = "[Core].[Proc_UserAccount_GetById]";
        private const string PROC_USERACCOUNT_LOGIN = "[Core].[Proc_UserAccount_Login]";
        private const string PROC_USERACCOUNT_CHECKAVAILABILITY = "[Core].[Proc_UserAccount_CheckAvailability]";
        #endregion SQL Procedures
        #region Private Functions
        private long Insert(UserAccount _UserAccount, DbTransaction dbTransaction = null) {
            try {
                var parameters = new {
                    ID = _UserAccount.ID,
                    UserName = _UserAccount.UserName,
                    PassCode = _UserAccount.PassCode,
                    PrefixId = _UserAccount.PrefixId,
                    PrefixTitle = _UserAccount.PrefixTitle,
                    FirstName = _UserAccount.FirstName,
                    MiddleName = _UserAccount.MiddleName,
                    LastName = _UserAccount.LastName,
                    SufixId = _UserAccount.SufixId,
                    SufixTitle = _UserAccount.SufixTitle,
                    Gender = _UserAccount.Gender,
                    DOB = _UserAccount.DOB,
                    CellNumber = _UserAccount.CellNumber,
                    MaritalStatusId = _UserAccount.MaritalStatusId,
                    MaritalStatusTitle = _UserAccount.MaritalStatusTitle,
                    IsActive = _UserAccount.IsActive,
                    CreatedBy = _UserAccount.CreatedBy,
                };
                return _connection.ExecuteScalar<long?>(PROC_USERACCOUNT_INSERT, parameters, dbTransaction, commandType: CommandType.StoredProcedure) ?? 0;
            }
            catch (Exception ex) {
                throw new Exception("Add", ex);
            }
        }
        private long Update(UserAccount _UserAccount, DbTransaction dbTransaction = null) {
            try {
                var parameters = new {
                    ID = _UserAccount.ID,
                    UserName = _UserAccount.UserName,
                    PassCode = _UserAccount.PassCode,
                    PrefixId = _UserAccount.PrefixId,
                    PrefixTitle = _UserAccount.PrefixTitle,
                    FirstName = _UserAccount.FirstName,
                    MiddleName = _UserAccount.MiddleName,
                    LastName = _UserAccount.LastName,
                    SufixId = _UserAccount.SufixId,
                    SufixTitle = _UserAccount.SufixTitle,
                    Gender = _UserAccount.Gender,
                    DOB = _UserAccount.DOB,
                    CellNumber = _UserAccount.CellNumber,
                    MaritalStatusId = _UserAccount.MaritalStatusId,
                    MaritalStatusTitle = _UserAccount.MaritalStatusTitle,
                    IsActive = _UserAccount.IsActive,
                    CreatedBy = _UserAccount.CreatedBy,
                    CreatedDate = _UserAccount.CreatedDate,
                    UpdatedBy = _UserAccount.UpdatedBy,
                    UpdatedDate = _UserAccount.UpdatedDate,
                };
                return _connection.ExecuteScalar<long?>(PROC_USERACCOUNT_UPDATE, parameters, dbTransaction, commandType: CommandType.StoredProcedure) ?? 0;
            }
            catch (Exception ex) {
                throw new Exception("Update", ex);
            }
        }
        private long Delete(long Id, DbTransaction dbTransaction = null) {
            try {
                return _connection.Execute(PROC_USERACCOUNT_DELETE, new { ID = Id }, dbTransaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex) {
                throw new Exception("Delete", ex);
            }
        }
        private long Available(string Username, DbTransaction dbTransaction = null) {
            try {
                return _connection.ExecuteScalar<long?>(PROC_USERACCOUNT_CHECKAVAILABILITY, new { UserName = Username }, dbTransaction, commandType: CommandType.StoredProcedure) ?? 0;
            }
            catch (Exception ex) {
                throw new Exception("Available", ex);
            }
        }
        private IEnumerable<UserAccount> GetActiveUser() {
            return _connection.Query<UserAccount>(PROC_USERACCOUNT_GETALL, commandType: CommandType.StoredProcedure);
        }
        private UserAccount GetUser(long Id) {
            return _connection.QueryFirstOrDefault<UserAccount>(PROC_USERACCOUNT_GETBYID, new { ID = Id }, commandType: CommandType.StoredProcedure);
        }
        private UserAccount GetUser(string userName, string passWord) {
            return _connection.QueryFirstOrDefault<UserAccount>(PROC_USERACCOUNT_LOGIN, new { UserName = userName, PassCode = passWord }, commandType: CommandType.StoredProcedure);
        }
        #endregion Private Functions
        #region Public Functions
        public bool CheckAvailability(string Username) {
            return Available(Username) == 0;
        }
        public long DeleteUser(long Id) {
            return Delete(Id);
        }
        public UserAccount GetUserById(long Id) {
            return GetUser(Id);
        }
        public IEnumerable<UserAccount> GetUsers() {
            return GetActiveUser();
        }
        public UserAccount Login(string UserName, string Password) {
            return GetUser(UserName, Password);
        }
        public long SaveUser(UserAccount _userAccount) {
            SqlConnection connection = (SqlConnection)_connection;
            if (connection.State != ConnectionState.Open) {
                connection.Open();
            }
            using (SqlTransaction transaction = connection.BeginTransaction()) {
                try {
                    long UserId = (_userAccount.ID == 0)
                        ? Insert(_userAccount, transaction)
                        : Update(_userAccount, transaction);
                    if (_userAccount.UserAddressList != null) {
                        _userAddressData.SaveUserAddresses(UserId, _userAccount.UserAddressList, transaction);
                    }
                    if (_userAccount.UserPackageList != null) {
                        _userPackageData.SaveUserPackages(UserId, _userAccount.UserPackageList, transaction);
                    }
                    if (_userAccount.UserCustomerServiceList != null) {
                        _userCustomerServiceData.SaveUserCustomerServices(UserId, _userAccount.UserCustomerServiceList, transaction);
                    }
                    transaction.Commit();
                    return UserId;
                }
                catch {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        #endregion
    }
}
