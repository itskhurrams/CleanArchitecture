using Clean.Architecture.Domain.Interfaces.User;
using Clean.Architecture.Domain.User;

using Microsoft.Practices.EnterpriseLibrary.Data;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.User {
    class UserCustomerServiceData : IUserCustomerServiceData {
        private readonly Database _Database;
        public UserCustomerServiceData(Database Database) {
            _Database = Database;
        }
        #region SQL Procedures
        private const string PROC_USERCUSTOMERSERVICE_INSERT = "[Core].[Proc_UserCustomerService_Insert]";
        private const string PROC_USERCUSTOMERSERVICE_UPDATE = "[Core].[Proc_UserCustomerService_Update]";
        private const string PROC_USERCUSTOMERSERVICE_GETBYID = "[Core].[Proc_UserCustomerService_GetById]";
        private const string PROC_USERCUSTOMERSERVICE_DELETE = "[Core].[Proc_UserCustomerService_Delete]";
        private const string PROC_USERCUSTOMERSERVICE_GETBYUSERID = "[Core].[Proc_UserCustomerService_GetByUserId]";
        private const string PROC_USERCUSTOMERSERVICE_DELETEBYUSERID = "[Core].[Proc_UserCustomerService_DeleteByUserId]";
        #endregion SQL Procedures
        #region Parameters
        private const string ID = "ID";
        private const string USERID = "UserId";
        private const string CUSTOMERID = "CustomerId";
        private const string CUSTOMERSERVICEID = "CustomerServiceId";
        private const string ISACTIVE = "IsActive";
        private const string CREATEDBY = "CreatedBy";
        private const string CREATEDDATE = "CreatedDate";
        private const string UPDATEDBY = "UpdatedBy";
        private const string UPDATEDDATE = "UpdatedDate";
        #endregion Parameters
        #region Private Functions
        private long Insert(UserCustomerService _UserCustomerService, DbTransaction dbTransaction = null) {
            try {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_USERCUSTOMERSERVICE_INSERT)) {
                    _Database.AddInParameter(dbCommand, ID, DbType.Int64, _UserCustomerService.ID);
                    _Database.AddInParameter(dbCommand, USERID, DbType.Int64, _UserCustomerService.UserId);
                    _Database.AddInParameter(dbCommand, CUSTOMERID, DbType.Int64, _UserCustomerService.CustomerId);
                    _Database.AddInParameter(dbCommand, CUSTOMERSERVICEID, DbType.Int64, _UserCustomerService.CustomerServiceId);
                    _Database.AddInParameter(dbCommand, ISACTIVE, DbType.Boolean, _UserCustomerService.IsActive);
                    _Database.AddInParameter(dbCommand, CREATEDBY, DbType.String, _UserCustomerService.CreatedBy);

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
        private long Update(UserCustomerService _UserCustomerService, DbTransaction dbTransaction = null) {
            try {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_USERCUSTOMERSERVICE_UPDATE)) {
                    _Database.AddInParameter(dbCommand, ID, DbType.Int64, _UserCustomerService.ID);
                    _Database.AddInParameter(dbCommand, USERID, DbType.Int64, _UserCustomerService.UserId);
                    _Database.AddInParameter(dbCommand, CUSTOMERID, DbType.Int64, _UserCustomerService.CustomerId);
                    _Database.AddInParameter(dbCommand, CUSTOMERSERVICEID, DbType.Int64, _UserCustomerService.CustomerServiceId);
                    _Database.AddInParameter(dbCommand, ISACTIVE, DbType.Boolean, _UserCustomerService.IsActive);
                    _Database.AddInParameter(dbCommand, UPDATEDBY, DbType.String, _UserCustomerService.UpdatedBy);

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
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_USERCUSTOMERSERVICE_DELETE)) {
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
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_USERCUSTOMERSERVICE_DELETEBYUSERID)) {
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
                throw new Exception("DeleteByUserId", ex);
            }
        }
        private IEnumerable<UserCustomerService> GetByUserId(long UserId) {
            try {
                List<UserCustomerService> UserCustomerServiceList = null;
                using (DbCommand dbcmdUserCustomerService = _Database.GetStoredProcCommand(PROC_USERCUSTOMERSERVICE_GETBYUSERID)) {
                    _Database.AddInParameter(dbcmdUserCustomerService, USERID, DbType.Int64, UserId);

                    using (IDataReader reader = _Database.ExecuteReader(dbcmdUserCustomerService)) {
                        if (UserCustomerServiceList == null) {
                            UserCustomerServiceList = new List<UserCustomerService>();
                        }
                        UserCustomerServiceList.Add(Mapper(reader));
                    }
                }
                return UserCustomerServiceList;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private UserCustomerService GetById(long Id) {
            try {
                UserCustomerService UserCustomerService = null;
                using (DbCommand dbcmdUserCustomerService = _Database.GetStoredProcCommand(PROC_USERCUSTOMERSERVICE_GETBYID)) {
                    _Database.AddInParameter(dbcmdUserCustomerService, ID, DbType.Int64, Id);
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdUserCustomerService)) {
                        UserCustomerService = Mapper(reader);
                    }
                }
                return UserCustomerService;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private UserCustomerService Mapper(IDataReader reader) {
            try {
                UserCustomerService _UserCustomerService = new UserCustomerService();
                if (reader[ID] != null && reader[ID] != DBNull.Value) {
                    _UserCustomerService.ID = Common.Conversion.ToLong(reader[ID]);
                }

                if (reader[USERID] != null && reader[USERID] != DBNull.Value) {
                    _UserCustomerService.UserId = Common.Conversion.ToLong(reader[USERID]);
                }

                if (reader[CUSTOMERID] != null && reader[CUSTOMERID] != DBNull.Value) {
                    _UserCustomerService.CustomerId = Common.Conversion.ToLong(reader[CUSTOMERID]);
                }

                if (reader[CUSTOMERSERVICEID] != null && reader[CUSTOMERSERVICEID] != DBNull.Value) {
                    _UserCustomerService.CustomerServiceId = Common.Conversion.ToLong(reader[CUSTOMERSERVICEID]);
                }

                if (reader[ISACTIVE] != null && reader[ISACTIVE] != DBNull.Value) {
                    _UserCustomerService.IsActive = Common.Conversion.ToBool(reader[ISACTIVE]);
                }

                if (reader[CREATEDBY] != null && reader[CREATEDBY] != DBNull.Value) {
                    _UserCustomerService.CreatedBy = Common.Conversion.ToString(reader[CREATEDBY]);
                }

                if (reader[CREATEDDATE] != null && reader[CREATEDDATE] != DBNull.Value) {
                    _UserCustomerService.CreatedDate = Common.Conversion.ToDateTime(reader[CREATEDDATE]);
                }

                if (reader[UPDATEDBY] != null && reader[UPDATEDBY] != DBNull.Value) {
                    _UserCustomerService.UpdatedBy = Common.Conversion.ToString(reader[UPDATEDBY]);
                }

                if (reader[UPDATEDDATE] != null && reader[UPDATEDDATE] != DBNull.Value) {
                    _UserCustomerService.UpdatedDate = Common.Conversion.ToDateTime(reader[UPDATEDDATE]);
                }

                return _UserCustomerService;
            }
            catch (Exception exception) {
                throw exception;
            }
        }

        #endregion Private Functions
        #region Public Functions
        public void SaveUserCustomerServices(long UserId, List<UserCustomerService> UserCustomerServiceList, DbTransaction dbTransaction = null) {
            try {
                DeleteByUserId(UserId, dbTransaction);
                if (UserCustomerServiceList != null && UserCustomerServiceList.Count > 0) {
                    foreach (UserCustomerService userCustomerService in UserCustomerServiceList) {
                        userCustomerService.UserId = UserId;
                        userCustomerService.IsActive = true;
                        if (userCustomerService.ID == 0) {
                            Insert(userCustomerService, dbTransaction);
                        }
                        else {
                            Update(userCustomerService, dbTransaction);
                        }
                    }
                }
            }
            catch (Exception exception) {

                throw exception;
            }
        }
        public IEnumerable<UserCustomerService> GetUserCustomerServicesByUserId(long UserId) {
            try {
                return GetByUserId(UserId);

            }
            catch (Exception exception) {

                throw exception;
            }
        }

        public long DeleteUserCustomerServicesByUserId(long UserId) {
            try {
                return DeleteByUserId(UserId);

            }
            catch (Exception exception) {

                throw exception;
            }
        }


        #endregion
    }
}
