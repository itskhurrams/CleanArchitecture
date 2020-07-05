using Microsoft.Practices.EnterpriseLibrary.Data;
using Clean.Architecture.Application.Interfaces.Persistance.Customer;
using Clean.Architecture.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Clean.Architecture.Persistance.Customer
{
    public class CustomerAccountData : ICustomerAccountData
    {
        private readonly Database _Database;
        private readonly ICustomerServiceData _customerServiceData;
        public CustomerAccountData(Database Database, ICustomerServiceData customerServiceData)
        {
            _Database = Database;
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
        #region Parameters
        private const string ID = "ID";
        private const string USERNAME = "UserName";
        private const string PASSCODE = "PassCode";
        private const string CUSTOMERNAME = "CustomerName";
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
        private long Insert(CustomerAccount _CustomerAccount, DbTransaction dbTransaction = null)
        {
            try
            {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_CUSTOMERACCOUNT_INSERT))
                {
                    _Database.AddInParameter(dbCommand, ID, DbType.Int64, _CustomerAccount.ID);
                    _Database.AddInParameter(dbCommand, USERNAME, DbType.String, _CustomerAccount.UserName);
                    _Database.AddInParameter(dbCommand, PASSCODE, DbType.String, _CustomerAccount.PassCode);
                    _Database.AddInParameter(dbCommand, CUSTOMERNAME, DbType.String, _CustomerAccount.CustomerName);
                    _Database.AddInParameter(dbCommand, ADDRESSLINE1, DbType.String, _CustomerAccount.AddressLine1);
                    _Database.AddInParameter(dbCommand, ADDRESSLINE2, DbType.String, _CustomerAccount.AddressLine2);
                    _Database.AddInParameter(dbCommand, ZIPCODE, DbType.String, _CustomerAccount.ZipCode);
                    _Database.AddInParameter(dbCommand, CITYNAME, DbType.String, _CustomerAccount.CityName);
                    _Database.AddInParameter(dbCommand, STATENAME, DbType.String, _CustomerAccount.StateName);
                    _Database.AddInParameter(dbCommand, COUNTRYNAME, DbType.String, _CustomerAccount.CountryName);
                    _Database.AddInParameter(dbCommand, LONGITUDE, DbType.String, _CustomerAccount.Longitude);
                    _Database.AddInParameter(dbCommand, LATITUDE, DbType.String, _CustomerAccount.Latitude);
                    _Database.AddInParameter(dbCommand, ISACTIVE, DbType.Boolean, _CustomerAccount.IsActive);
                    _Database.AddInParameter(dbCommand, CREATEDBY, DbType.String, _CustomerAccount.CreatedBy);
                    if (dbTransaction == null)
                    {
                        return Common.Conversion.ToLong(_Database.ExecuteScalar(dbCommand));
                    }
                    else
                    {
                        return Common.Conversion.ToLong(_Database.ExecuteScalar(dbCommand, dbTransaction));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Add", ex);
            }
        }
        private long Update(CustomerAccount _CustomerAccount, DbTransaction dbTransaction = null)
        {
            try
            {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_CUSTOMERACCOUNT_UPDATE))
                {
                    _Database.AddInParameter(dbCommand, ID, DbType.Int64, _CustomerAccount.ID);
                    _Database.AddInParameter(dbCommand, USERNAME, DbType.String, _CustomerAccount.UserName);
                    _Database.AddInParameter(dbCommand, PASSCODE, DbType.String, _CustomerAccount.PassCode);
                    _Database.AddInParameter(dbCommand, CUSTOMERNAME, DbType.String, _CustomerAccount.CustomerName);
                    _Database.AddInParameter(dbCommand, ADDRESSLINE1, DbType.String, _CustomerAccount.AddressLine1);
                    _Database.AddInParameter(dbCommand, ADDRESSLINE2, DbType.String, _CustomerAccount.AddressLine2);
                    _Database.AddInParameter(dbCommand, ZIPCODE, DbType.String, _CustomerAccount.ZipCode);
                    _Database.AddInParameter(dbCommand, CITYNAME, DbType.String, _CustomerAccount.CityName);
                    _Database.AddInParameter(dbCommand, STATENAME, DbType.String, _CustomerAccount.StateName);
                    _Database.AddInParameter(dbCommand, COUNTRYNAME, DbType.String, _CustomerAccount.CountryName);
                    _Database.AddInParameter(dbCommand, LONGITUDE, DbType.String, _CustomerAccount.Longitude);
                    _Database.AddInParameter(dbCommand, LATITUDE, DbType.String, _CustomerAccount.Latitude);
                    _Database.AddInParameter(dbCommand, ISACTIVE, DbType.Boolean, _CustomerAccount.IsActive);
                    _Database.AddInParameter(dbCommand, UPDATEDBY, DbType.String, _CustomerAccount.UpdatedBy);
                    if (dbTransaction == null)
                    {
                        return Common.Conversion.ToLong(_Database.ExecuteScalar(dbCommand));
                    }
                    else
                    {
                        return Common.Conversion.ToLong(_Database.ExecuteScalar(dbCommand, dbTransaction));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Update", ex);
            }
        }
        private long Delete(long Id, DbTransaction dbTransaction = null)
        {
            try
            {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_CUSTOMERACCOUNT_DELETE))
                {
                    _Database.AddInParameter(dbCommand, ID, DbType.Int64, Id);
                    if (dbTransaction == null)
                    {
                        return _Database.ExecuteNonQuery(dbCommand);
                    }
                    else
                    {
                        return _Database.ExecuteNonQuery(dbCommand, dbTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Delete", ex);
            }
        }
        private long Available(string Username, DbTransaction dbTransaction = null)
        {
            try
            {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_CUSTOMERACCOUNT_CHECKAVAILABILITY))
                {
                    _Database.AddInParameter(dbCommand, USERNAME, DbType.String, Username);
                    if (dbTransaction == null)
                    {
                        return _Database.ExecuteNonQuery(dbCommand);
                    }
                    else
                    {
                        return _Database.ExecuteNonQuery(dbCommand, dbTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Available", ex);
            }
        }
        private IEnumerable<CustomerAccount> GetActiveCustomers()
        {
            try
            {
                List<CustomerAccount> CustomerAccountList = null;
                using (DbCommand dbcmdCustomerAccount = _Database.GetStoredProcCommand(PROC_CUSTOMERACCOUNT_GETALL))
                {
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdCustomerAccount))
                    {
                        if (CustomerAccountList == null)
                        {
                            CustomerAccountList = new List<CustomerAccount>();
                        }
                        CustomerAccountList.Add(Mapper(reader));
                    }
                }
                return CustomerAccountList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private CustomerAccount GetCustomer(long Id)
        {
            try
            {
                CustomerAccount CustomerAccount = null;
                using (DbCommand dbcmdCustomerAccount = _Database.GetStoredProcCommand(PROC_CUSTOMERACCOUNT_GETBYID))
                {
                    _Database.AddInParameter(dbcmdCustomerAccount, ID, DbType.Int64, Id);
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdCustomerAccount))
                    {
                        CustomerAccount = Mapper(reader);
                    }
                }
                return CustomerAccount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private CustomerAccount GetUser(string userName, string passWord)
        {
            try
            {
                CustomerAccount CustomerAccount = null;
                using (DbCommand dbcmdCustomerAccount = _Database.GetStoredProcCommand(PROC_CUSTOMERACCOUNT_LOGIN))
                {
                    _Database.AddInParameter(dbcmdCustomerAccount, USERNAME, DbType.String, userName);
                    _Database.AddInParameter(dbcmdCustomerAccount, PASSCODE, DbType.String, passWord);
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdCustomerAccount))
                    {
                        CustomerAccount = Mapper(reader);
                    }
                }
                return CustomerAccount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private CustomerAccount Mapper(IDataReader reader)
        {
            try
            {
                CustomerAccount _CustomerAccount = new CustomerAccount();
                if (reader[ID] != null && reader[ID] != DBNull.Value)
                {
                    _CustomerAccount.ID = Common.Conversion.ToLong(reader[ID]);
                }
                if (reader[USERNAME] != null && reader[USERNAME] != DBNull.Value)
                {
                    _CustomerAccount.UserName = Common.Conversion.ToString(reader[USERNAME]);
                }
                if (reader[PASSCODE] != null && reader[PASSCODE] != DBNull.Value)
                {
                    _CustomerAccount.PassCode = Common.Conversion.ToString(reader[PASSCODE]);
                }
                if (reader[CUSTOMERNAME] != null && reader[CUSTOMERNAME] != DBNull.Value)
                {
                    _CustomerAccount.CustomerName = Common.Conversion.ToString(reader[CUSTOMERNAME]);
                }
                if (reader[ADDRESSLINE1] != null && reader[ADDRESSLINE1] != DBNull.Value)
                {
                    _CustomerAccount.AddressLine1 = Common.Conversion.ToString(reader[ADDRESSLINE1]);
                }
                if (reader[ADDRESSLINE2] != null && reader[ADDRESSLINE2] != DBNull.Value)
                {
                    _CustomerAccount.AddressLine2 = Common.Conversion.ToString(reader[ADDRESSLINE2]);
                }
                if (reader[ZIPCODE] != null && reader[ZIPCODE] != DBNull.Value)
                {
                    _CustomerAccount.ZipCode = Common.Conversion.ToString(reader[ZIPCODE]);
                }
                if (reader[CITYNAME] != null && reader[CITYNAME] != DBNull.Value)
                {
                    _CustomerAccount.CityName = Common.Conversion.ToString(reader[CITYNAME]);
                }
                if (reader[STATENAME] != null && reader[STATENAME] != DBNull.Value)
                {
                    _CustomerAccount.StateName = Common.Conversion.ToString(reader[STATENAME]);
                }
                if (reader[COUNTRYNAME] != null && reader[COUNTRYNAME] != DBNull.Value)
                {
                    _CustomerAccount.CountryName = Common.Conversion.ToString(reader[COUNTRYNAME]);
                }
                if (reader[LONGITUDE] != null && reader[LONGITUDE] != DBNull.Value)
                {
                    _CustomerAccount.Longitude = Common.Conversion.ToString(reader[LONGITUDE]);
                }
                if (reader[LATITUDE] != null && reader[LATITUDE] != DBNull.Value)
                {
                    _CustomerAccount.Latitude = Common.Conversion.ToString(reader[LATITUDE]);
                }
                if (reader[ISACTIVE] != null && reader[ISACTIVE] != DBNull.Value)
                {
                    _CustomerAccount.IsActive = Common.Conversion.ToBool(reader[ISACTIVE]);
                }
                if (reader[CREATEDBY] != null && reader[CREATEDBY] != DBNull.Value)
                {
                    _CustomerAccount.CreatedBy = Common.Conversion.ToString(reader[CREATEDBY]);
                }
                if (reader[CREATEDDATE] != null && reader[CREATEDDATE] != DBNull.Value)
                {
                    _CustomerAccount.CreatedDate = Common.Conversion.ToDateTime(reader[CREATEDDATE]);
                }
                if (reader[UPDATEDBY] != null && reader[UPDATEDBY] != DBNull.Value)
                {
                    _CustomerAccount.UpdatedBy = Common.Conversion.ToString(reader[UPDATEDBY]);
                }
                if (reader[UPDATEDDATE] != null && reader[UPDATEDDATE] != DBNull.Value)
                {
                    _CustomerAccount.UpdatedDate = Common.Conversion.ToDateTime(reader[UPDATEDDATE]);
                }
                return _CustomerAccount;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        #endregion Private Functions
        #region Public Functions
        public bool CheckAvailability(string Username)
        {
            try
            {
                if (Available(Username) > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public long DeleteCustomer(long Id)
        {
            try
            {
                return Delete(Id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public CustomerAccount GetCustomerById(long Id)
        {
            try
            {
                return GetCustomer(Id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public IEnumerable<CustomerAccount> GetCustomers()
        {
            try
            {
                return GetActiveCustomers();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public CustomerAccount Login(string UserName, string Password)
        {
            try
            {
                return GetUser(UserName, Password);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public long SaveCustomer(CustomerAccount _CustomerAccount)
        {
            try
            {
                using (DbConnection connection = (DbConnection)_Database.CreateConnection())
                {
                    DbTransaction _transaction = null;
                    try
                    {
                        connection.Open();
                        _transaction = connection.BeginTransaction();
                        long CustomerId = 0;
                        if (_CustomerAccount.ID == 0)
                        {
                            CustomerId = Insert(_CustomerAccount, _transaction);
                        }
                        else
                        {
                            CustomerId = Update(_CustomerAccount, _transaction);
                        }
                        _customerServiceData.SaveCustomerServices(CustomerId, _CustomerAccount.CustomerServicesList, _transaction);
                        _transaction.Commit();
                        return CustomerId;
                    }
                    catch
                    {
                        _transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        #endregion
    }
}
