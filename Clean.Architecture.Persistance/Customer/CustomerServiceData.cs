using Clean.Architecture.Domain.Customer;
using Clean.Architecture.Domain.Interfaces.Customer;

using Dapper;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.Customer {
    public class CustomerServiceData : ICustomerServiceData {
        private readonly IDbConnection _connection;
        public CustomerServiceData(IDbConnection connection) {
            _connection = connection;
        }
        #region SQL Procedures
        private const string PROC_CUSTOMERSERVICE_INSERT = "[Core].[Proc_CustomerService_Insert]";
        private const string PROC_CUSTOMERSERVICE_UPDATE = "[Core].[Proc_CustomerService_Update]";
        private const string PROC_CUSTOMERSERVICE_GETBYID = "[Core].[Proc_CustomerService_GetById]";
        private const string PROC_CUSTOMERSERVICE_DELETE = "[Core].[Proc_CustomerService_Delete]";
        private const string PROC_CUSTOMERSERVICE_GETBYCUSTOMERID = "[Core].[Proc_CustomerService_GetByCustomerId]";
        private const string PROC_CUSTOMERSERVICE_DELETEBYCUSTOMERID = "[Core].[Proc_CustomerService_DeleteByCustomerId]";
        #endregion SQL Procedures
        #region Private Functions
        private long Insert(CustomerService _CustomerService, DbTransaction dbTransaction = null) {
            try {
                var parameters = new {
                    ID = _CustomerService.ID,
                    CustomerId = _CustomerService.CustomerId,
                    BusinessTypeId = _CustomerService.BusinessTypeId,
                    ServiceName = _CustomerService.ServiceName,
                    ServiceDescription = _CustomerService.ServiceDescription,
                    AddressLine1 = _CustomerService.AddressLine1,
                    AddressLine2 = _CustomerService.AddressLine2,
                    ZipCode = _CustomerService.ZipCode,
                    CityName = _CustomerService.CityName,
                    StateName = _CustomerService.StateName,
                    CountryName = _CustomerService.CountryName,
                    Longitude = _CustomerService.Longitude,
                    Latitude = _CustomerService.Latitude,
                    LogoFileName = _CustomerService.LogoFileName,
                    LogoFileSize = _CustomerService.LogoFileSize,
                    LogoFile = _CustomerService.LogoFile,
                    LogoFileType = _CustomerService.LogoFileType,
                    IsDefault = _CustomerService.IsDefault,
                    IsActive = _CustomerService.IsActive,
                    CreatedBy = _CustomerService.CreatedBy,
                };
                return _connection.ExecuteScalar<long?>(PROC_CUSTOMERSERVICE_INSERT, parameters, dbTransaction, commandType: CommandType.StoredProcedure) ?? 0;
            }
            catch (Exception ex) {
                throw new Exception("Add", ex);
            }
        }
        private long Update(CustomerService _CustomerService, DbTransaction dbTransaction = null) {
            try {
                var parameters = new {
                    ID = _CustomerService.ID,
                    CustomerId = _CustomerService.CustomerId,
                    BusinessTypeId = _CustomerService.BusinessTypeId,
                    ServiceName = _CustomerService.ServiceName,
                    ServiceDescription = _CustomerService.ServiceDescription,
                    AddressLine1 = _CustomerService.AddressLine1,
                    AddressLine2 = _CustomerService.AddressLine2,
                    ZipCode = _CustomerService.ZipCode,
                    CityName = _CustomerService.CityName,
                    StateName = _CustomerService.StateName,
                    CountryName = _CustomerService.CountryName,
                    Longitude = _CustomerService.Longitude,
                    Latitude = _CustomerService.Latitude,
                    LogoFileName = _CustomerService.LogoFileName,
                    LogoFileSize = _CustomerService.LogoFileSize,
                    LogoFile = _CustomerService.LogoFile,
                    LogoFileType = _CustomerService.LogoFileType,
                    IsDefault = _CustomerService.IsDefault,
                    IsActive = _CustomerService.IsActive,
                    UpdatedBy = _CustomerService.UpdatedBy,
                };
                return _connection.ExecuteScalar<long?>(PROC_CUSTOMERSERVICE_UPDATE, parameters, dbTransaction, commandType: CommandType.StoredProcedure) ?? 0;
            }
            catch (Exception ex) {
                throw new Exception("Update", ex);
            }
        }
        private long Delete(long Id, DbTransaction dbTransaction = null) {
            try {
                return _connection.Execute(PROC_CUSTOMERSERVICE_DELETE, new { ID = Id }, dbTransaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex) {
                throw new Exception("Delete", ex);
            }
        }
        private long DeleteByCustomerId(long CustomerId, DbTransaction dbTransaction = null) {
            try {
                return _connection.Execute(PROC_CUSTOMERSERVICE_DELETEBYCUSTOMERID, new { CustomerId }, dbTransaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex) {
                throw new Exception("Delete", ex);
            }
        }
        private IEnumerable<CustomerService> GetByCustomerId(long CustomerId) {
            return _connection.Query<CustomerService>(PROC_CUSTOMERSERVICE_GETBYCUSTOMERID, new { CustomerId }, commandType: CommandType.StoredProcedure);
        }
        private CustomerService GetById(long Id) {
            return _connection.QueryFirstOrDefault<CustomerService>(PROC_CUSTOMERSERVICE_GETBYID, new { ID = Id }, commandType: CommandType.StoredProcedure);
        }
        #endregion Private Functions
        #region Public Functions
        public void SaveCustomerServices(long CustomerId, List<CustomerService> CustomerServiceList, DbTransaction dbTransaction = null) {
            DeleteByCustomerId(CustomerId, dbTransaction);
            if (CustomerServiceList != null && CustomerServiceList.Count > 0) {
                foreach (CustomerService customerService in CustomerServiceList) {
                    customerService.CustomerId = CustomerId;
                    customerService.IsActive = true;
                    Insert(customerService, dbTransaction);
                }
            }
        }
        public long DeleteCustomerServicesByCustomerId(long CustomerId) {
            return DeleteByCustomerId(CustomerId);
        }
        public IEnumerable<CustomerService> GetCustomerServiceByCustomerId(long CustomerId) {
            return GetByCustomerId(CustomerId);
        }
        #endregion
    }
}
