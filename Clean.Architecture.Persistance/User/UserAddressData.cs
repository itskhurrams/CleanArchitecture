using Clean.Architecture.Domain.Interfaces.User;
using Clean.Architecture.Domain.User;

using Microsoft.Practices.EnterpriseLibrary.Data;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.User {
    class UserAddressData : IUserAddressData {
        private readonly Database _Database;
        public UserAddressData(Database Database) {
            _Database = Database;
        }
        #region SQL Procedures
        private const string PROC_USERADDRESS_INSERT = "[Core].[Proc_UserAddress_Insert]";
        private const string PROC_USERADDRESS_UPDATE = "[Core].[Proc_UserAddress_Update]";
        private const string PROC_USERADDRESS_GETBYID = "[Core].[Proc_UserAddress_GetById]";
        private const string PROC_USERADDRESS_DELETE = "[Core].[Proc_UserAddress_Delete]";
        private const string PROC_USERADDRESS_GETBYUSERID = "[Core].[Proc_UserAddress_GetByUserId]";
        private const string PROC_USERADDRESS_DELETEBYUSERID = "[Core].[Proc_UserAddress_DeleteByUserId]";
        #endregion SQL Procedures
        #region Parameters
        private const string ID = "ID";
        private const string ADDRESSTYPEID = "AddressTypeId";
        private const string USERID = "UserId";
        private const string ADDRESSLINE1 = "AddressLine1";
        private const string ADDRESSLINE2 = "AddressLine2";
        private const string ZIPCODE = "ZipCode";
        private const string CITYNAME = "CityName";
        private const string STATENAME = "StateName";
        private const string COUNTRYNAME = "CountryName";
        private const string LONGITUDE = "Longitude";
        private const string LATITUDE = "Latitude";
        private const string ISACTIVE = "IsActive";
        private const string CREATEDBY = "CreatedBy";
        private const string CREATEDDATE = "CreatedDate";
        private const string UPDATEDBY = "UpdatedBy";
        private const string UPDATEDDATE = "UpdatedDate";
        #endregion Parameters
        #region Private Functions
        private long Insert(UserAddress _UserAddress, DbTransaction dbTransaction = null) {
            try {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_USERADDRESS_INSERT)) {
                    _Database.AddInParameter(dbCommand, ID, DbType.Int64, _UserAddress.ID);
                    _Database.AddInParameter(dbCommand, ADDRESSTYPEID, DbType.Int16, _UserAddress.AddressTypeId);
                    _Database.AddInParameter(dbCommand, USERID, DbType.Int64, _UserAddress.UserId);
                    _Database.AddInParameter(dbCommand, ADDRESSLINE1, DbType.String, _UserAddress.AddressLine1);
                    _Database.AddInParameter(dbCommand, ADDRESSLINE2, DbType.String, _UserAddress.AddressLine2);
                    _Database.AddInParameter(dbCommand, ZIPCODE, DbType.String, _UserAddress.ZipCode);
                    _Database.AddInParameter(dbCommand, CITYNAME, DbType.String, _UserAddress.CityName);
                    _Database.AddInParameter(dbCommand, STATENAME, DbType.String, _UserAddress.StateName);
                    _Database.AddInParameter(dbCommand, COUNTRYNAME, DbType.String, _UserAddress.CountryName);
                    _Database.AddInParameter(dbCommand, LONGITUDE, DbType.String, _UserAddress.Longitude);
                    _Database.AddInParameter(dbCommand, LATITUDE, DbType.String, _UserAddress.Latitude);
                    _Database.AddInParameter(dbCommand, ISACTIVE, DbType.Boolean, _UserAddress.IsActive);
                    _Database.AddInParameter(dbCommand, CREATEDBY, DbType.String, _UserAddress.CreatedBy);

                    if (dbTransaction == null) {
                        return Common.Conversion.ToLong(_Database.ExecuteScalar(dbCommand));
                    }
                    else {
                        return Common.Conversion.ToLong(_Database.ExecuteScalar(dbCommand, dbTransaction));
                    }
                }
            }
            catch (Exception ex) {
                throw new Exception("Add", ex);
            }
        }
        private long Update(UserAddress _UserAddress, DbTransaction dbTransaction = null) {
            try {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_USERADDRESS_UPDATE)) {
                    _Database.AddInParameter(dbCommand, ID, DbType.Int64, _UserAddress.ID);
                    _Database.AddInParameter(dbCommand, ADDRESSTYPEID, DbType.Int16, _UserAddress.AddressTypeId);
                    _Database.AddInParameter(dbCommand, USERID, DbType.Int64, _UserAddress.UserId);
                    _Database.AddInParameter(dbCommand, ADDRESSLINE1, DbType.String, _UserAddress.AddressLine1);
                    _Database.AddInParameter(dbCommand, ADDRESSLINE2, DbType.String, _UserAddress.AddressLine2);
                    _Database.AddInParameter(dbCommand, ZIPCODE, DbType.String, _UserAddress.ZipCode);
                    _Database.AddInParameter(dbCommand, CITYNAME, DbType.String, _UserAddress.CityName);
                    _Database.AddInParameter(dbCommand, STATENAME, DbType.String, _UserAddress.StateName);
                    _Database.AddInParameter(dbCommand, COUNTRYNAME, DbType.String, _UserAddress.CountryName);
                    _Database.AddInParameter(dbCommand, LONGITUDE, DbType.String, _UserAddress.Longitude);
                    _Database.AddInParameter(dbCommand, LATITUDE, DbType.String, _UserAddress.Latitude);
                    _Database.AddInParameter(dbCommand, ISACTIVE, DbType.Boolean, _UserAddress.IsActive);
                    _Database.AddInParameter(dbCommand, UPDATEDBY, DbType.String, _UserAddress.UpdatedBy);

                    if (dbTransaction == null) {
                        return Common.Conversion.ToLong(_Database.ExecuteScalar(dbCommand));
                    }
                    else {
                        return Common.Conversion.ToLong(_Database.ExecuteScalar(dbCommand, dbTransaction));
                    }
                }
            }
            catch (Exception ex) {
                throw new Exception("Update", ex);
            }
        }
        private long Delete(long Id, DbTransaction dbTransaction = null) {
            try {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_USERADDRESS_DELETE)) {
                    _Database.AddInParameter(dbCommand, ID, DbType.Int64, Id);
                    if (dbTransaction == null) {
                        return _Database.ExecuteNonQuery(dbCommand);
                    }
                    else {
                        return _Database.ExecuteNonQuery(dbCommand, dbTransaction);
                    }
                }
            }
            catch (Exception ex) {
                throw new Exception("Delete", ex);
            }
        }
        private long DeleteByUserId(long UserId, DbTransaction dbTransaction = null) {
            try {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_USERADDRESS_DELETEBYUSERID)) {
                    _Database.AddInParameter(dbCommand, USERID, DbType.Int64, UserId);
                    if (dbTransaction == null) {
                        return _Database.ExecuteNonQuery(dbCommand);
                    }
                    else {
                        return _Database.ExecuteNonQuery(dbCommand, dbTransaction);
                    }
                }
            }
            catch (Exception ex) {
                throw new Exception("Delete", ex);
            }
        }
        private IEnumerable<UserAddress> GetByUserId(long UserId) {
            try {
                List<UserAddress> UserAddressList = null;
                using (DbCommand dbcmdUserAddress = _Database.GetStoredProcCommand(PROC_USERADDRESS_GETBYUSERID)) {
                    _Database.AddInParameter(dbcmdUserAddress, USERID, DbType.Int64, UserId);

                    using (IDataReader reader = _Database.ExecuteReader(dbcmdUserAddress)) {
                        if (UserAddressList == null) {
                            UserAddressList = new List<UserAddress>();
                        }
                        UserAddressList.Add(Mapper(reader));
                    }
                }
                return UserAddressList;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private UserAddress GetById(long Id) {
            try {
                UserAddress UserAddress = null;
                using (DbCommand dbcmdUserAddress = _Database.GetStoredProcCommand(PROC_USERADDRESS_GETBYID)) {
                    _Database.AddInParameter(dbcmdUserAddress, ID, DbType.Int64, Id);
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdUserAddress)) {
                        UserAddress = Mapper(reader);
                    }
                }
                return UserAddress;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private UserAddress Mapper(IDataReader reader) {
            try {
                UserAddress _UserAddress = new UserAddress();
                if (reader[ID] != null && reader[ID] != DBNull.Value) {
                    _UserAddress.ID = Common.Conversion.ToLong(reader[ID]);
                }
                if (reader[ADDRESSTYPEID] != null && reader[ADDRESSTYPEID] != DBNull.Value) {
                    _UserAddress.AddressTypeId = Common.Conversion.ToShort(reader[ADDRESSTYPEID]);
                }
                if (reader[USERID] != null && reader[USERID] != DBNull.Value) {
                    _UserAddress.UserId = Common.Conversion.ToLong(reader[USERID]);
                }
                if (reader[ADDRESSLINE1] != null && reader[ADDRESSLINE1] != DBNull.Value) {
                    _UserAddress.AddressLine1 = Common.Conversion.ToString(reader[ADDRESSLINE1]);
                }
                if (reader[ADDRESSLINE2] != null && reader[ADDRESSLINE2] != DBNull.Value) {
                    _UserAddress.AddressLine2 = Common.Conversion.ToString(reader[ADDRESSLINE2]);
                }
                if (reader[ZIPCODE] != null && reader[ZIPCODE] != DBNull.Value) {
                    _UserAddress.ZipCode = Common.Conversion.ToString(reader[ZIPCODE]);
                }
                if (reader[CITYNAME] != null && reader[CITYNAME] != DBNull.Value) {
                    _UserAddress.CityName = Common.Conversion.ToString(reader[CITYNAME]);
                }
                if (reader[STATENAME] != null && reader[STATENAME] != DBNull.Value) {
                    _UserAddress.StateName = Common.Conversion.ToString(reader[STATENAME]);
                }
                if (reader[COUNTRYNAME] != null && reader[COUNTRYNAME] != DBNull.Value) {
                    _UserAddress.CountryName = Common.Conversion.ToString(reader[COUNTRYNAME]);
                }
                if (reader[LONGITUDE] != null && reader[LONGITUDE] != DBNull.Value) {
                    _UserAddress.Longitude = Common.Conversion.ToString(reader[LONGITUDE]);
                }
                if (reader[LATITUDE] != null && reader[LATITUDE] != DBNull.Value) {
                    _UserAddress.Latitude = Common.Conversion.ToString(reader[LATITUDE]);
                }
                if (reader[ISACTIVE] != null && reader[ISACTIVE] != DBNull.Value) {
                    _UserAddress.IsActive = Common.Conversion.ToBool(reader[ISACTIVE]);
                }
                if (reader[CREATEDBY] != null && reader[CREATEDBY] != DBNull.Value) {
                    _UserAddress.CreatedBy = Common.Conversion.ToString(reader[CREATEDBY]);
                }
                if (reader[CREATEDDATE] != null && reader[CREATEDDATE] != DBNull.Value) {
                    _UserAddress.CreatedDate = Common.Conversion.ToDateTime(reader[CREATEDDATE]);
                }
                if (reader[UPDATEDBY] != null && reader[UPDATEDBY] != DBNull.Value) {
                    _UserAddress.UpdatedBy = Common.Conversion.ToString(reader[UPDATEDBY]);
                }
                if (reader[UPDATEDDATE] != null && reader[UPDATEDDATE] != DBNull.Value) {
                    _UserAddress.UpdatedDate = Common.Conversion.ToDateTime(reader[UPDATEDDATE]);
                }
                return _UserAddress;
            }
            catch (Exception exception) {
                throw exception;
            }
        }

        #endregion Private Functions
        #region Public Functions
        public void SaveUserAddresses(long UserId, List<UserAddress> UserAddressList, DbTransaction dbTransaction = null) {
            try {
                DeleteByUserId(UserId, dbTransaction);
                if (UserAddressList != null && UserAddressList.Count > 0) {
                    foreach (UserAddress userAddress in UserAddressList) {
                        userAddress.UserId = UserId;
                        userAddress.IsActive = true;
                        if (userAddress.ID == 0) {
                            Insert(userAddress, dbTransaction);
                        }
                        else {
                            Update(userAddress, dbTransaction);
                        }
                    }
                }
            }
            catch (Exception exception) {

                throw exception;
            }
        }
        public long DeleteAddressesByUserId(long UserId) {
            try {
                return DeleteByUserId(UserId);

            }
            catch (Exception exception) {

                throw exception;
            }
        }
        public IEnumerable<UserAddress> GetAddressesByUserId(long UserId) {
            try {
                return GetByUserId(UserId);

            }
            catch (Exception exception) {

                throw exception;
            }
        }
        #endregion
    }
}
