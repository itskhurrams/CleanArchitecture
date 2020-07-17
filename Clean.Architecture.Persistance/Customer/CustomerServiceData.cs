using Clean.Architecture.Domain.Customer;
using Clean.Architecture.Domain.Interfaces.Customer;

using Microsoft.Practices.EnterpriseLibrary.Data;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.Customer {
    public class CustomerServiceData : ICustomerServiceData {
        private readonly Database _Database;
        public CustomerServiceData(Database Database) {
            _Database = Database;
        }
        #region SQL Procedures
        private const string PROC_CUSTOMERSERVICE_INSERT = "[Core].[Proc_CustomerService_Insert]";
        private const string PROC_CUSTOMERSERVICE_UPDATE = "[Core].[Proc_CustomerService_Update]";
        private const string PROC_CUSTOMERSERVICE_GETBYID = "[Core].[Proc_CustomerService_GetById]";
        private const string PROC_CUSTOMERSERVICE_DELETE = "[Core].[Proc_CustomerService_Delete]";
        private const string PROC_CUSTOMERSERVICE_GETBYCUSTOMERID = "[Core].[Proc_CustomerService_GetByCustomerId]";
        private const string PROC_CUSTOMERSERVICE_DELETEBYCUSTOMERID = "[Core].[Proc_CustomerService_DeleteByCustomerId]";
        #endregion SQL Procedures
        #region Parameters
        private const string ID = "ID";
        private const string CUSTOMERID = "CustomerId";
        private const string BUSINESSTYPEID = "BusinessTypeId";
        private const string SERVICENAME = "ServiceName";
        private const string SERVICEDESCRIPTION = "ServiceDescription";
        private const string ADDRESSLINE1 = "AddressLine1";
        private const string ADDRESSLINE2 = "AddressLine2";
        private const string ZIPCODE = "ZipCode";
        private const string CITYNAME = "CityName";
        private const string STATENAME = "StateName";
        private const string COUNTRYNAME = "CountryName";
        private const string LONGITUDE = "Longitude";
        private const string LATITUDE = "Latitude";
        private const string LOGOFILENAME = "LogoFileName";
        private const string LOGOFILESIZE = "LogoFileSize";
        private const string LOGOFILE = "LogoFile";
        private const string LOGOFILETYPE = "LogoFileType";
        private const string ISDEFAULT = "IsDefault";
        private const string ISACTIVE = "IsActive";
        private const string CREATEDBY = "CreatedBy";
        private const string CREATEDDATE = "CreatedDate";
        private const string UPDATEDBY = "UpdatedBy";
        private const string UPDATEDDATE = "UpdatedDate";
        #endregion Parameters
        #region Private Functions
        private long Insert(CustomerService _CustomerService, DbTransaction dbTransaction = null) {
            try {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_CUSTOMERSERVICE_INSERT)) {
                    _Database.AddInParameter(dbCommand, ID, DbType.Int64, _CustomerService.ID);
                    _Database.AddInParameter(dbCommand, CUSTOMERID, DbType.Int64, _CustomerService.CustomerId);
                    _Database.AddInParameter(dbCommand, BUSINESSTYPEID, DbType.Int16, _CustomerService.BusinessTypeId);
                    _Database.AddInParameter(dbCommand, SERVICENAME, DbType.String, _CustomerService.ServiceName);
                    _Database.AddInParameter(dbCommand, SERVICEDESCRIPTION, DbType.String, _CustomerService.ServiceDescription);
                    _Database.AddInParameter(dbCommand, ADDRESSLINE1, DbType.String, _CustomerService.AddressLine1);
                    _Database.AddInParameter(dbCommand, ADDRESSLINE2, DbType.String, _CustomerService.AddressLine2);
                    _Database.AddInParameter(dbCommand, ZIPCODE, DbType.String, _CustomerService.ZipCode);
                    _Database.AddInParameter(dbCommand, CITYNAME, DbType.String, _CustomerService.CityName);
                    _Database.AddInParameter(dbCommand, STATENAME, DbType.String, _CustomerService.StateName);
                    _Database.AddInParameter(dbCommand, COUNTRYNAME, DbType.String, _CustomerService.CountryName);
                    _Database.AddInParameter(dbCommand, LONGITUDE, DbType.String, _CustomerService.Longitude);
                    _Database.AddInParameter(dbCommand, LATITUDE, DbType.String, _CustomerService.Latitude);
                    _Database.AddInParameter(dbCommand, LOGOFILENAME, DbType.String, _CustomerService.LogoFileName);
                    _Database.AddInParameter(dbCommand, LOGOFILESIZE, DbType.Int64, _CustomerService.LogoFileSize);
                    _Database.AddInParameter(dbCommand, LOGOFILE, DbType.Binary, _CustomerService.LogoFile);
                    _Database.AddInParameter(dbCommand, LOGOFILETYPE, DbType.String, _CustomerService.LogoFileType);
                    _Database.AddInParameter(dbCommand, ISDEFAULT, DbType.Boolean, _CustomerService.IsDefault);
                    _Database.AddInParameter(dbCommand, ISACTIVE, DbType.Boolean, _CustomerService.IsActive);
                    _Database.AddInParameter(dbCommand, CREATEDBY, DbType.String, _CustomerService.CreatedBy);
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
        private long Update(CustomerService _CustomerService, DbTransaction dbTransaction = null) {
            try {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_CUSTOMERSERVICE_UPDATE)) {
                    _Database.AddInParameter(dbCommand, ID, DbType.Int64, _CustomerService.ID);
                    _Database.AddInParameter(dbCommand, CUSTOMERID, DbType.Int64, _CustomerService.CustomerId);
                    _Database.AddInParameter(dbCommand, BUSINESSTYPEID, DbType.Int16, _CustomerService.BusinessTypeId);
                    _Database.AddInParameter(dbCommand, SERVICENAME, DbType.String, _CustomerService.ServiceName);
                    _Database.AddInParameter(dbCommand, SERVICEDESCRIPTION, DbType.String, _CustomerService.ServiceDescription);
                    _Database.AddInParameter(dbCommand, ADDRESSLINE1, DbType.String, _CustomerService.AddressLine1);
                    _Database.AddInParameter(dbCommand, ADDRESSLINE2, DbType.String, _CustomerService.AddressLine2);
                    _Database.AddInParameter(dbCommand, ZIPCODE, DbType.String, _CustomerService.ZipCode);
                    _Database.AddInParameter(dbCommand, CITYNAME, DbType.String, _CustomerService.CityName);
                    _Database.AddInParameter(dbCommand, STATENAME, DbType.String, _CustomerService.StateName);
                    _Database.AddInParameter(dbCommand, COUNTRYNAME, DbType.String, _CustomerService.CountryName);
                    _Database.AddInParameter(dbCommand, LONGITUDE, DbType.String, _CustomerService.Longitude);
                    _Database.AddInParameter(dbCommand, LATITUDE, DbType.String, _CustomerService.Latitude);
                    _Database.AddInParameter(dbCommand, LOGOFILENAME, DbType.String, _CustomerService.LogoFileName);
                    _Database.AddInParameter(dbCommand, LOGOFILESIZE, DbType.Int64, _CustomerService.LogoFileSize);
                    _Database.AddInParameter(dbCommand, LOGOFILE, DbType.Binary, _CustomerService.LogoFile);
                    _Database.AddInParameter(dbCommand, LOGOFILETYPE, DbType.String, _CustomerService.LogoFileType);
                    _Database.AddInParameter(dbCommand, ISDEFAULT, DbType.Boolean, _CustomerService.IsDefault);
                    _Database.AddInParameter(dbCommand, ISACTIVE, DbType.Boolean, _CustomerService.IsActive);
                    _Database.AddInParameter(dbCommand, UPDATEDBY, DbType.String, _CustomerService.UpdatedBy);
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
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_CUSTOMERSERVICE_DELETE)) {
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
        private long DeleteByCustomerId(long CustomerId, DbTransaction dbTransaction = null) {
            try {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_CUSTOMERSERVICE_DELETEBYCUSTOMERID)) {
                    _Database.AddInParameter(dbCommand, CUSTOMERID, DbType.Int64, CustomerId);
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
        private IEnumerable<CustomerService> GetByCustomerId(long CustomerId) {
            try {
                List<CustomerService> CustomerServiceList = null;
                using (DbCommand dbcmdCustomerService = _Database.GetStoredProcCommand(PROC_CUSTOMERSERVICE_GETBYCUSTOMERID)) {
                    _Database.AddInParameter(dbcmdCustomerService, CUSTOMERID, DbType.Int64, CustomerId);
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdCustomerService)) {
                        if (CustomerServiceList == null) {
                            CustomerServiceList = new List<CustomerService>();
                        }
                        CustomerServiceList.Add(Mapper(reader));
                    }
                }
                return CustomerServiceList;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private CustomerService GetById(long Id) {
            try {
                CustomerService CustomerService = null;
                using (DbCommand dbcmdCustomerService = _Database.GetStoredProcCommand(PROC_CUSTOMERSERVICE_GETBYID)) {
                    _Database.AddInParameter(dbcmdCustomerService, ID, DbType.Int64, Id);
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdCustomerService)) {
                        CustomerService = Mapper(reader);
                    }
                }
                return CustomerService;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private CustomerService Mapper(IDataReader reader) {
            try {
                CustomerService _CustomerService = new CustomerService();
                if (reader[ID] != null && reader[ID] != DBNull.Value) {
                    _CustomerService.ID = Common.Conversion.ToLong(reader[ID]);
                }
                if (reader[CUSTOMERID] != null && reader[CUSTOMERID] != DBNull.Value) {
                    _CustomerService.CustomerId = Common.Conversion.ToLong(reader[CUSTOMERID]);
                }
                if (reader[BUSINESSTYPEID] != null && reader[BUSINESSTYPEID] != DBNull.Value) {
                    _CustomerService.BusinessTypeId = Common.Conversion.ToShort(reader[BUSINESSTYPEID]);
                }
                if (reader[SERVICENAME] != null && reader[SERVICENAME] != DBNull.Value) {
                    _CustomerService.ServiceName = Common.Conversion.ToString(reader[SERVICENAME]);
                }
                if (reader[SERVICEDESCRIPTION] != null && reader[SERVICEDESCRIPTION] != DBNull.Value) {
                    _CustomerService.ServiceDescription = Common.Conversion.ToString(reader[SERVICEDESCRIPTION]);
                }
                if (reader[ADDRESSLINE1] != null && reader[ADDRESSLINE1] != DBNull.Value) {
                    _CustomerService.AddressLine1 = Common.Conversion.ToString(reader[ADDRESSLINE1]);
                }
                if (reader[ADDRESSLINE2] != null && reader[ADDRESSLINE2] != DBNull.Value) {
                    _CustomerService.AddressLine2 = Common.Conversion.ToString(reader[ADDRESSLINE2]);
                }
                if (reader[ZIPCODE] != null && reader[ZIPCODE] != DBNull.Value) {
                    _CustomerService.ZipCode = Common.Conversion.ToString(reader[ZIPCODE]);
                }
                if (reader[CITYNAME] != null && reader[CITYNAME] != DBNull.Value) {
                    _CustomerService.CityName = Common.Conversion.ToString(reader[CITYNAME]);
                }
                if (reader[STATENAME] != null && reader[STATENAME] != DBNull.Value) {
                    _CustomerService.StateName = Common.Conversion.ToString(reader[STATENAME]);
                }
                if (reader[COUNTRYNAME] != null && reader[COUNTRYNAME] != DBNull.Value) {
                    _CustomerService.CountryName = Common.Conversion.ToString(reader[COUNTRYNAME]);
                }
                if (reader[LONGITUDE] != null && reader[LONGITUDE] != DBNull.Value) {
                    _CustomerService.Longitude = Common.Conversion.ToString(reader[LONGITUDE]);
                }
                if (reader[LATITUDE] != null && reader[LATITUDE] != DBNull.Value) {
                    _CustomerService.Latitude = Common.Conversion.ToString(reader[LATITUDE]);
                }
                if (reader[LOGOFILENAME] != null && reader[LOGOFILENAME] != DBNull.Value) {
                    _CustomerService.LogoFileName = Common.Conversion.ToString(reader[LOGOFILENAME]);
                }
                if (reader[LOGOFILESIZE] != null && reader[LOGOFILESIZE] != DBNull.Value) {
                    _CustomerService.LogoFileSize = Common.Conversion.ToLong(reader[LOGOFILESIZE]);
                }
                if (reader[LOGOFILE] != null && reader[LOGOFILE] != DBNull.Value) {
                    _CustomerService.LogoFile = Common.Conversion.ToByteArray(reader[LOGOFILE]);
                }
                if (reader[LOGOFILETYPE] != null && reader[LOGOFILETYPE] != DBNull.Value) {
                    _CustomerService.LogoFileType = Common.Conversion.ToString(reader[LOGOFILETYPE]);
                }
                if (reader[ISDEFAULT] != null && reader[ISDEFAULT] != DBNull.Value) {
                    _CustomerService.IsDefault = Common.Conversion.ToBool(reader[ISDEFAULT]);
                }
                if (reader[ISACTIVE] != null && reader[ISACTIVE] != DBNull.Value) {
                    _CustomerService.IsActive = Common.Conversion.ToBool(reader[ISACTIVE]);
                }
                if (reader[CREATEDBY] != null && reader[CREATEDBY] != DBNull.Value) {
                    _CustomerService.CreatedBy = Common.Conversion.ToString(reader[CREATEDBY]);
                }
                if (reader[CREATEDDATE] != null && reader[CREATEDDATE] != DBNull.Value) {
                    _CustomerService.CreatedDate = Common.Conversion.ToDateTime(reader[CREATEDDATE]);
                }
                if (reader[UPDATEDBY] != null && reader[UPDATEDBY] != DBNull.Value) {
                    _CustomerService.UpdatedBy = Common.Conversion.ToString(reader[UPDATEDBY]);
                }
                if (reader[UPDATEDDATE] != null && reader[UPDATEDDATE] != DBNull.Value) {
                    _CustomerService.UpdatedDate = Common.Conversion.ToDateTime(reader[UPDATEDDATE]);
                }
                return _CustomerService;
            }
            catch (Exception exception) {
                throw exception;
            }
        }
        #endregion Private Functions
        #region Public Functions
        public void SaveCustomerServices(long CustomerId, List<CustomerService> CustomerServiceList, DbTransaction dbTransaction = null) {
            try {
                DeleteByCustomerId(CustomerId, dbTransaction);
                if (CustomerServiceList != null && CustomerServiceList.Count > 0) {
                    foreach (CustomerService CustomerService in CustomerServiceList) {
                        CustomerService.CustomerId = CustomerId;
                        CustomerService.IsActive = true;
                        if (CustomerService.ID == 0) {
                            Insert(CustomerService, dbTransaction);
                        }
                        else {
                            Update(CustomerService, dbTransaction);
                        }
                    }
                }
            }
            catch (Exception exception) {
                throw exception;
            }
        }
        public long DeleteCustomerServicesByCustomerId(long CustomerId) {
            try {
                return DeleteByCustomerId(CustomerId);
            }
            catch (Exception exception) {
                throw exception;
            }
        }
        public IEnumerable<CustomerService> GetCustomerServiceByCustomerId(long CustomerId) {
            try {
                return GetByCustomerId(CustomerId);
            }
            catch (Exception exception) {
                throw exception;
            }
        }
        #endregion
    }
}
