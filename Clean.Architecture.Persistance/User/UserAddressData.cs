using Clean.Architecture.Domain.Interfaces.User;
using Clean.Architecture.Domain.User;

using Dapper;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.User {
    public class UserAddressData : IUserAddressData {
        private readonly IDbConnection _connection;
        public UserAddressData(IDbConnection connection) {
            _connection = connection;
        }
        #region SQL Procedures
        private const string PROC_USERADDRESS_INSERT = "[Core].[Proc_UserAddress_Insert]";
        private const string PROC_USERADDRESS_UPDATE = "[Core].[Proc_UserAddress_Update]";
        private const string PROC_USERADDRESS_GETBYID = "[Core].[Proc_UserAddress_GetById]";
        private const string PROC_USERADDRESS_DELETE = "[Core].[Proc_UserAddress_Delete]";
        private const string PROC_USERADDRESS_GETBYUSERID = "[Core].[Proc_UserAddress_GetByUserId]";
        private const string PROC_USERADDRESS_DELETEBYUSERID = "[Core].[Proc_UserAddress_DeleteByUserId]";
        #endregion SQL Procedures
        #region Private Functions
        private long Insert(UserAddress _UserAddress, DbTransaction dbTransaction = null) {
            try {
                var parameters = new {
                    ID = _UserAddress.ID,
                    AddressTypeId = _UserAddress.AddressTypeId,
                    UserId = _UserAddress.UserId,
                    AddressLine1 = _UserAddress.AddressLine1,
                    AddressLine2 = _UserAddress.AddressLine2,
                    ZipCode = _UserAddress.ZipCode,
                    CityName = _UserAddress.CityName,
                    StateName = _UserAddress.StateName,
                    CountryName = _UserAddress.CountryName,
                    Longitude = _UserAddress.Longitude,
                    Latitude = _UserAddress.Latitude,
                    IsActive = _UserAddress.IsActive,
                    CreatedBy = _UserAddress.CreatedBy,
                };
                return _connection.ExecuteScalar<long?>(PROC_USERADDRESS_INSERT, parameters, dbTransaction, commandType: CommandType.StoredProcedure) ?? 0;
            }
            catch (Exception ex) {
                throw new Exception("Add", ex);
            }
        }
        private long Update(UserAddress _UserAddress, DbTransaction dbTransaction = null) {
            try {
                var parameters = new {
                    ID = _UserAddress.ID,
                    AddressTypeId = _UserAddress.AddressTypeId,
                    UserId = _UserAddress.UserId,
                    AddressLine1 = _UserAddress.AddressLine1,
                    AddressLine2 = _UserAddress.AddressLine2,
                    ZipCode = _UserAddress.ZipCode,
                    CityName = _UserAddress.CityName,
                    StateName = _UserAddress.StateName,
                    CountryName = _UserAddress.CountryName,
                    Longitude = _UserAddress.Longitude,
                    Latitude = _UserAddress.Latitude,
                    IsActive = _UserAddress.IsActive,
                    UpdatedBy = _UserAddress.UpdatedBy,
                };
                return _connection.ExecuteScalar<long?>(PROC_USERADDRESS_UPDATE, parameters, dbTransaction, commandType: CommandType.StoredProcedure) ?? 0;
            }
            catch (Exception ex) {
                throw new Exception("Update", ex);
            }
        }
        private long Delete(long Id, DbTransaction dbTransaction = null) {
            try {
                return _connection.Execute(PROC_USERADDRESS_DELETE, new { ID = Id }, dbTransaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex) {
                throw new Exception("Delete", ex);
            }
        }
        private long DeleteByUserId(long UserId, DbTransaction dbTransaction = null) {
            try {
                return _connection.Execute(PROC_USERADDRESS_DELETEBYUSERID, new { UserId }, dbTransaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex) {
                throw new Exception("DeleteByUserId", ex);
            }
        }
        private IEnumerable<UserAddress> GetByUserId(long UserId) {
            return _connection.Query<UserAddress>(PROC_USERADDRESS_GETBYUSERID, new { UserId }, commandType: CommandType.StoredProcedure);
        }
        private UserAddress GetById(long Id) {
            return _connection.QueryFirstOrDefault<UserAddress>(PROC_USERADDRESS_GETBYID, new { ID = Id }, commandType: CommandType.StoredProcedure);
        }
        #endregion Private Functions
        #region Public Functions
        public void SaveUserAddresses(long UserId, List<UserAddress> UserAddressList, DbTransaction dbTransaction = null) {
            DeleteByUserId(UserId, dbTransaction);
            if (UserAddressList != null && UserAddressList.Count > 0) {
                foreach (UserAddress userAddress in UserAddressList) {
                    userAddress.UserId = UserId;
                    userAddress.IsActive = true;
                    Insert(userAddress, dbTransaction);
                }
            }
        }
        public long DeleteAddressesByUserId(long UserId) {
            return DeleteByUserId(UserId);
        }
        public IEnumerable<UserAddress> GetAddressesByUserId(long UserId) {
            return GetByUserId(UserId);
        }
        #endregion
    }
}
