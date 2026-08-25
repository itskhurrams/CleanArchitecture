using Clean.Architecture.Domain.Customer;
using Clean.Architecture.Domain.Interfaces.Customer;

using Dapper;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.Customer {
    public class CustomerAccountData : ICustomerAccountData {
        private readonly IDbConnection _connection;
        private readonly ICustomerServiceData _customerServiceData;
        public CustomerAccountData(IDbConnection connection, ICustomerServiceData customerServiceData) {
            _connection = connection;
            _customerServiceData = customerServiceData;
        }
        #region SQL Procedures
        private const string PROC_CUSTOMERACCOUNT_INSERT = "[Core].[Proc_CustomerAccount_Insert]";
        private const string PROC_CUSTOMERACCOUNT_UPDATE = "[Core].[Proc_CustomerAccount_Update]";
        private const string PROC_CUSTOMERACCOUNT_DELETE = "[Core].[Proc_CustomerAccount_Delete]";
        private const string PROC_CUSTOMERACCOUNT_GETALL = "[Core].[Proc_CustomerAccount_GetAll]";
        private const string PROC_CUSTOMERACCOUNT_GETBYID = "[Core].[Proc_CustomerAccount_GetById]";
        private const string PROC_CUSTOMERACCOUNT_LOGIN = "[Core].[Proc_CustomerAccount_Login]";
        private const string PROC_CUSTOMERACCOUNT_CHECKAVAILABILITY = "[Core].[Proc_CustomerAccount_CheckAvailability]";
        #endregion SQL Procedures
        #region Private Functions
        private long Insert(CustomerAccount _CustomerAccount, DbTransaction dbTransaction = null) {
            try {
                var parameters = new {
                    ID = _CustomerAccount.ID,
                    UserName = _CustomerAccount.UserName,
                    PassCode = _CustomerAccount.PassCode,
                    CustomerName = _CustomerAccount.CustomerName,
                    AddressLine1 = _CustomerAccount.AddressLine1,
                    AddressLine2 = _CustomerAccount.AddressLine2,
                    ZipCode = _CustomerAccount.ZipCode,
                    CityName = _CustomerAccount.CityName,
                    StateName = _CustomerAccount.StateName,
                    CountryName = _CustomerAccount.CountryName,
                    Longitude = _CustomerAccount.Longitude,
                    Latitude = _CustomerAccount.Latitude,
                    IsActive = _CustomerAccount.IsActive,
                    CreatedBy = _CustomerAccount.CreatedBy,
                };
                return _connection.ExecuteScalar<long?>(PROC_CUSTOMERACCOUNT_INSERT, parameters, dbTransaction, commandType: CommandType.StoredProcedure) ?? 0;
            }
            catch (Exception ex) {
                throw new Exception("Add", ex);
            }
        }
        private long Update(CustomerAccount _CustomerAccount, DbTransaction dbTransaction = null) {
            try {
                var parameters = new {
                    ID = _CustomerAccount.ID,
                    UserName = _CustomerAccount.UserName,
                    PassCode = _CustomerAccount.PassCode,
                    CustomerName = _CustomerAccount.CustomerName,
                    AddressLine1 = _CustomerAccount.AddressLine1,
                    AddressLine2 = _CustomerAccount.AddressLine2,
                    ZipCode = _CustomerAccount.ZipCode,
                    CityName = _CustomerAccount.CityName,
                    StateName = _CustomerAccount.StateName,
                    CountryName = _CustomerAccount.CountryName,
                    Longitude = _CustomerAccount.Longitude,
                    Latitude = _CustomerAccount.Latitude,
                    IsActive = _CustomerAccount.IsActive,
                    UpdatedBy = _CustomerAccount.UpdatedBy,
                };
                return _connection.ExecuteScalar<long?>(PROC_CUSTOMERACCOUNT_UPDATE, parameters, dbTransaction, commandType: CommandType.StoredProcedure) ?? 0;
            }
            catch (Exception ex) {
                throw new Exception("Update", ex);
            }
        }
        private long Delete(long Id, DbTransaction dbTransaction = null) {
            try {
                return _connection.Execute(PROC_CUSTOMERACCOUNT_DELETE, new { ID = Id }, dbTransaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex) {
                throw new Exception("Delete", ex);
            }
        }
        private long Available(string Username, DbTransaction dbTransaction = null) {
            try {
                return _connection.ExecuteScalar<long?>(PROC_CUSTOMERACCOUNT_CHECKAVAILABILITY, new { UserName = Username }, dbTransaction, commandType: CommandType.StoredProcedure) ?? 0;
            }
            catch (Exception ex) {
                throw new Exception("Available", ex);
            }
        }
        private IEnumerable<CustomerAccount> GetActiveCustomers() {
            return _connection.Query<CustomerAccount>(PROC_CUSTOMERACCOUNT_GETALL, commandType: CommandType.StoredProcedure);
        }
        private CustomerAccount GetCustomer(long Id) {
            return _connection.QueryFirstOrDefault<CustomerAccount>(PROC_CUSTOMERACCOUNT_GETBYID, new { ID = Id }, commandType: CommandType.StoredProcedure);
        }
        private CustomerAccount GetUser(string userName, string passWord) {
            return _connection.QueryFirstOrDefault<CustomerAccount>(PROC_CUSTOMERACCOUNT_LOGIN, new { UserName = userName, PassCode = passWord }, commandType: CommandType.StoredProcedure);
        }
        #endregion Private Functions
        #region Public Functions
        public bool CheckAvailability(string Username) {
            return Available(Username) == 0;
        }
        public long DeleteCustomer(long Id) {
            return Delete(Id);
        }
        public CustomerAccount GetCustomerById(long Id) {
            return GetCustomer(Id);
        }
        public IEnumerable<CustomerAccount> GetCustomers() {
            return GetActiveCustomers();
        }
        public CustomerAccount Login(string UserName, string Password) {
            return GetUser(UserName, Password);
        }
        public long SaveCustomer(CustomerAccount _CustomerAccount) {
            SqlConnection connection = (SqlConnection)_connection;
            if (connection.State != ConnectionState.Open) {
                connection.Open();
            }
            using (SqlTransaction transaction = connection.BeginTransaction()) {
                try {
                    long CustomerId = (_CustomerAccount.ID == 0)
                        ? Insert(_CustomerAccount, transaction)
                        : Update(_CustomerAccount, transaction);
                    if (_CustomerAccount.CustomerServicesList != null) {
                        _customerServiceData.SaveCustomerServices(CustomerId, _CustomerAccount.CustomerServicesList, transaction);
                    }
                    transaction.Commit();
                    return CustomerId;
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
