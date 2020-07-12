using Microsoft.Practices.EnterpriseLibrary.Data;
using Clean.Architecture.Domain.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Clean.Architecture.Domain.Interfaces.User;

namespace Clean.Architecture.Persistance.User
{
    public class UserAccountData : IUserAccountData
    {
        private readonly Database _database;
        private readonly IUserAddressData _userAddressData;
        private readonly IUserPackageData _userPackageData;
        private readonly IUserCustomerServiceData _userCustomerServiceData;
        public UserAccountData(Database database, IUserAddressData userAddressData, IUserPackageData userPackageData, IUserCustomerServiceData userCustomerServiceData)
        {
            _database = database;
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
        #region Parameters
        private const string ID = "ID";
        private const string USERNAME = "UserName";
        private const string PASSCODE = "PassCode";
        private const string PREFIXID = "PrefixId";
        private const string PREFIXTITLE = "PrefixTitle";
        private const string FIRSTNAME = "FirstName";
        private const string MIDDLENAME = "MiddleName";
        private const string LASTNAME = "LastName";
        private const string SUFIXID = "SufixId";
        private const string SUFIXTITLE = "SufixTitle";
        private const string GENDER = "Gender";
        private const string DOB = "DOB";
        private const string CELLNUMBER = "CellNumber";
        private const string MARITALSTATUSID = "MaritalStatusId";
        private const string MARITALSTATUSTITLE = "MaritalStatusTitle";
        private const string ISACTIVE = "IsActive";
        private const string CREATEDBY = "CreatedBy";
        private const string CREATEDDATE = "CreatedDate";
        private const string UPDATEDBY = "UpdatedBy";
        private const string UPDATEDDATE = "UpdatedDate";
        #endregion Parameters
        #region Private Functions
        private long Insert(UserAccount _UserAccount, DbTransaction dbTransaction = null)
        {
            try
            {
                using (DbCommand dbCommand = _database.GetStoredProcCommand(PROC_USERACCOUNT_INSERT))
                {
                    _database.AddInParameter(dbCommand, ID, DbType.Int64, _UserAccount.ID);
                    _database.AddInParameter(dbCommand, USERNAME, DbType.String, _UserAccount.UserName);
                    _database.AddInParameter(dbCommand, PASSCODE, DbType.String, _UserAccount.PassCode);
                    _database.AddInParameter(dbCommand, PREFIXID, DbType.Int16, _UserAccount.PrefixId);
                    _database.AddInParameter(dbCommand, PREFIXTITLE, DbType.String, _UserAccount.PrefixTitle);
                    _database.AddInParameter(dbCommand, FIRSTNAME, DbType.String, _UserAccount.FirstName);
                    _database.AddInParameter(dbCommand, MIDDLENAME, DbType.String, _UserAccount.MiddleName);
                    _database.AddInParameter(dbCommand, LASTNAME, DbType.String, _UserAccount.LastName);
                    _database.AddInParameter(dbCommand, SUFIXID, DbType.Int16, _UserAccount.SufixId);
                    _database.AddInParameter(dbCommand, SUFIXTITLE, DbType.String, _UserAccount.SufixTitle);
                    _database.AddInParameter(dbCommand, GENDER, DbType.String, _UserAccount.Gender);
                    _database.AddInParameter(dbCommand, DOB, DbType.Date, _UserAccount.DOB);
                    _database.AddInParameter(dbCommand, CELLNUMBER, DbType.String, _UserAccount.CellNumber);
                    _database.AddInParameter(dbCommand, MARITALSTATUSID, DbType.Int16, _UserAccount.MaritalStatusId);
                    _database.AddInParameter(dbCommand, MARITALSTATUSTITLE, DbType.String, _UserAccount.MaritalStatusTitle);
                    _database.AddInParameter(dbCommand, ISACTIVE, DbType.Boolean, _UserAccount.IsActive);
                    _database.AddInParameter(dbCommand, CREATEDBY, DbType.String, _UserAccount.CreatedBy);
                    if (dbTransaction == null)
                    {
                        return Common.Conversion.ToLong(_database.ExecuteScalar(dbCommand));
                    }
                    else
                    {
                        return Common.Conversion.ToLong(_database.ExecuteScalar(dbCommand, dbTransaction));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Add", ex);
            }
        }
        private long Update(UserAccount _UserAccount, DbTransaction dbTransaction = null)
        {
            try
            {
                using (DbCommand dbCommand = _database.GetStoredProcCommand(PROC_USERACCOUNT_UPDATE))
                {
                    _database.AddInParameter(dbCommand, ID, DbType.Int64, _UserAccount.ID);
                    _database.AddInParameter(dbCommand, USERNAME, DbType.String, _UserAccount.UserName);
                    _database.AddInParameter(dbCommand, PASSCODE, DbType.String, _UserAccount.PassCode);
                    _database.AddInParameter(dbCommand, PREFIXID, DbType.Int16, _UserAccount.PrefixId);
                    _database.AddInParameter(dbCommand, PREFIXTITLE, DbType.String, _UserAccount.PrefixTitle);
                    _database.AddInParameter(dbCommand, FIRSTNAME, DbType.String, _UserAccount.FirstName);
                    _database.AddInParameter(dbCommand, MIDDLENAME, DbType.String, _UserAccount.MiddleName);
                    _database.AddInParameter(dbCommand, LASTNAME, DbType.String, _UserAccount.LastName);
                    _database.AddInParameter(dbCommand, SUFIXID, DbType.Int16, _UserAccount.SufixId);
                    _database.AddInParameter(dbCommand, SUFIXTITLE, DbType.String, _UserAccount.SufixTitle);
                    _database.AddInParameter(dbCommand, GENDER, DbType.String, _UserAccount.Gender);
                    _database.AddInParameter(dbCommand, DOB, DbType.Date, _UserAccount.DOB);
                    _database.AddInParameter(dbCommand, CELLNUMBER, DbType.String, _UserAccount.CellNumber);
                    _database.AddInParameter(dbCommand, MARITALSTATUSID, DbType.Int16, _UserAccount.MaritalStatusId);
                    _database.AddInParameter(dbCommand, MARITALSTATUSTITLE, DbType.String, _UserAccount.MaritalStatusTitle);
                    _database.AddInParameter(dbCommand, ISACTIVE, DbType.Boolean, _UserAccount.IsActive);
                    _database.AddInParameter(dbCommand, CREATEDBY, DbType.String, _UserAccount.CreatedBy);
                    _database.AddInParameter(dbCommand, CREATEDDATE, DbType.DateTime, _UserAccount.CreatedDate);
                    _database.AddInParameter(dbCommand, UPDATEDBY, DbType.String, _UserAccount.UpdatedBy);
                    _database.AddInParameter(dbCommand, UPDATEDDATE, DbType.DateTime, _UserAccount.UpdatedDate);
                    if (dbTransaction == null)
                    {
                        return Common.Conversion.ToLong(_database.ExecuteScalar(dbCommand));
                    }
                    else
                    {
                        return Common.Conversion.ToLong(_database.ExecuteScalar(dbCommand, dbTransaction));
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
                using (DbCommand dbCommand = _database.GetStoredProcCommand(PROC_USERACCOUNT_DELETE))
                {
                    _database.AddInParameter(dbCommand, ID, DbType.Int64, Id);
                    if (dbTransaction == null)
                    {
                        return _database.ExecuteNonQuery(dbCommand);
                    }
                    else
                    {
                        return _database.ExecuteNonQuery(dbCommand, dbTransaction);
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
                using (DbCommand dbCommand = _database.GetStoredProcCommand(PROC_USERACCOUNT_CHECKAVAILABILITY))
                {
                    _database.AddInParameter(dbCommand, USERNAME, DbType.String, Username);
                    if (dbTransaction == null)
                    {
                        return _database.ExecuteNonQuery(dbCommand);
                    }
                    else
                    {
                        return _database.ExecuteNonQuery(dbCommand, dbTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Available", ex);
            }
        }
        private IEnumerable<UserAccount> GetActiveUser()
        {
            try
            {
                List<UserAccount> userAccountList = null;
                using (DbCommand dbcmdUserAccount = _database.GetStoredProcCommand(PROC_USERACCOUNT_GETALL))
                {
                    using (IDataReader reader = _database.ExecuteReader(dbcmdUserAccount))
                    {
                        if (userAccountList == null)
                        {
                            userAccountList = new List<UserAccount>();
                        }
                        userAccountList.Add(Mapper(reader));
                    }
                }
                return userAccountList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private UserAccount GetUser(long Id)
        {
            try
            {
                UserAccount userAccount = null;
                using (DbCommand dbcmdUserAccount = _database.GetStoredProcCommand(PROC_USERACCOUNT_GETBYID))
                {
                    _database.AddInParameter(dbcmdUserAccount, ID, DbType.Int64, Id);
                    using (IDataReader reader = _database.ExecuteReader(dbcmdUserAccount))
                    {
                        userAccount = Mapper(reader);
                    }
                }
                return userAccount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private UserAccount GetUser(string userName, string passWord)
        {
            try
            {
                UserAccount userAccount = null;
                using (DbCommand dbcmdUserAccount = _database.GetStoredProcCommand(PROC_USERACCOUNT_LOGIN))
                {
                    _database.AddInParameter(dbcmdUserAccount, USERNAME, DbType.String, userName);
                    _database.AddInParameter(dbcmdUserAccount, PASSCODE, DbType.String, passWord);
                    using (IDataReader reader = _database.ExecuteReader(dbcmdUserAccount))
                    {
                        userAccount = Mapper(reader);
                    }
                }
                return userAccount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private UserAccount Mapper(IDataReader reader)
        {
            try
            {
                UserAccount _UserAccount = new UserAccount();
                if (reader[ID] != null && reader[ID] != DBNull.Value)
                {
                    _UserAccount.ID = Common.Conversion.ToLong(reader[ID]);
                }
                if (reader[USERNAME] != null && reader[USERNAME] != DBNull.Value)
                {
                    _UserAccount.UserName = Common.Conversion.ToString(reader[USERNAME]);
                }
                if (reader[PASSCODE] != null && reader[PASSCODE] != DBNull.Value)
                {
                    _UserAccount.PassCode = Common.Conversion.ToString(reader[PASSCODE]);
                }
                if (reader[PREFIXID] != null && reader[PREFIXID] != DBNull.Value)
                {
                    _UserAccount.PrefixId = Common.Conversion.ToShort(reader[PREFIXID]);
                }
                if (reader[PREFIXTITLE] != null && reader[PREFIXTITLE] != DBNull.Value)
                {
                    _UserAccount.PrefixTitle = Common.Conversion.ToString(reader[PREFIXTITLE]);
                }
                if (reader[FIRSTNAME] != null && reader[FIRSTNAME] != DBNull.Value)
                {
                    _UserAccount.FirstName = Common.Conversion.ToString(reader[FIRSTNAME]);
                }
                if (reader[MIDDLENAME] != null && reader[MIDDLENAME] != DBNull.Value)
                {
                    _UserAccount.MiddleName = Common.Conversion.ToString(reader[MIDDLENAME]);
                }
                if (reader[LASTNAME] != null && reader[LASTNAME] != DBNull.Value)
                {
                    _UserAccount.LastName = Common.Conversion.ToString(reader[LASTNAME]);
                }
                if (reader[SUFIXID] != null && reader[SUFIXID] != DBNull.Value)
                {
                    _UserAccount.SufixId = Common.Conversion.ToShort(reader[SUFIXID]);
                }
                if (reader[SUFIXTITLE] != null && reader[SUFIXTITLE] != DBNull.Value)
                {
                    _UserAccount.SufixTitle = Common.Conversion.ToString(reader[SUFIXTITLE]);
                }
                if (reader[GENDER] != null && reader[GENDER] != DBNull.Value)
                {
                    _UserAccount.Gender = Common.Conversion.ToString(reader[GENDER]);
                }
                if (reader[DOB] != null && reader[DOB] != DBNull.Value)
                {
                    _UserAccount.DOB = Common.Conversion.ToDateTime(reader[DOB]);
                }
                if (reader[CELLNUMBER] != null && reader[CELLNUMBER] != DBNull.Value)
                {
                    _UserAccount.CellNumber = Common.Conversion.ToString(reader[CELLNUMBER]);
                }
                if (reader[MARITALSTATUSID] != null && reader[MARITALSTATUSID] != DBNull.Value)
                {
                    _UserAccount.MaritalStatusId = Common.Conversion.ToShort(reader[MARITALSTATUSID]);
                }
                if (reader[MARITALSTATUSTITLE] != null && reader[MARITALSTATUSTITLE] != DBNull.Value)
                {
                    _UserAccount.MaritalStatusTitle = Common.Conversion.ToString(reader[MARITALSTATUSTITLE]);
                }
                if (reader[ISACTIVE] != null && reader[ISACTIVE] != DBNull.Value)
                {
                    _UserAccount.IsActive = Common.Conversion.ToBool(reader[ISACTIVE]);
                }
                if (reader[CREATEDBY] != null && reader[CREATEDBY] != DBNull.Value)
                {
                    _UserAccount.CreatedBy = Common.Conversion.ToString(reader[CREATEDBY]);
                }
                if (reader[CREATEDDATE] != null && reader[CREATEDDATE] != DBNull.Value)
                {
                    _UserAccount.CreatedDate = Common.Conversion.ToDateTime(reader[CREATEDDATE]);
                }
                if (reader[UPDATEDBY] != null && reader[UPDATEDBY] != DBNull.Value)
                {
                    _UserAccount.UpdatedBy = Common.Conversion.ToString(reader[UPDATEDBY]);
                }
                if (reader[UPDATEDDATE] != null && reader[UPDATEDDATE] != DBNull.Value)
                {
                    _UserAccount.UpdatedDate = Common.Conversion.ToDateTime(reader[UPDATEDDATE]);
                }
                return _UserAccount;
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
        public long DeleteUser(long Id)
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
        public UserAccount GetUserById(long Id)
        {
            try
            {
                return GetUser(Id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public IEnumerable<UserAccount> GetUsers()
        {
            try
            {
                return GetUsers();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public UserAccount Login(string UserName, string Password)
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
        public long SaveUser(UserAccount _userAccount)
        {
            try
            {
                using (SqlConnection connection = (SqlConnection)_database.CreateConnection())
                {
                    SqlTransaction _transaction = null;
                    try
                    {
                        connection.Open();
                        _transaction = connection.BeginTransaction();
                        long UserId = 0;
                        if (_userAccount.ID == 0)
                        {
                            UserId = Insert(_userAccount, _transaction);
                        }
                        else
                        {
                            UserId = Update(_userAccount, _transaction);
                        }
                        _userAddressData.SaveUserAddresses(UserId, _userAccount.UserAddressList, _transaction);
                        _userPackageData.SaveUserPackages(UserId, _userAccount.UserPackageList, _transaction);
                        _userCustomerServiceData.SaveUserCustomerServices(UserId, _userAccount.UserCustomerServiceList, _transaction);
                        _transaction.Commit();
                        return UserId;
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