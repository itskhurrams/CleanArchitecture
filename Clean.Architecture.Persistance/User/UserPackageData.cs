using Clean.Architecture.Domain.Interfaces.User;
using Clean.Architecture.Domain.User;

using Microsoft.Practices.EnterpriseLibrary.Data;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.User {
    class UserPackageData : IUserPackageData {
        private readonly Database _Database;
        public UserPackageData(Database Database) {
            _Database = Database;
        }
        #region SQL Procedures
        private const string PROC_USERPACKAGE_INSERT = "[Core].[Proc_UserPackage_Insert]";
        private const string PROC_USERPACKAGE_UPDATE = "[Core].[Proc_UserPackage_Update]";
        private const string PROC_USERPACKAGE_GETBYID = "[Core].[Proc_UserPackage_GetById]";
        private const string PROC_USERPACKAGE_DELETE = "[Core].[Proc_UserPackage_Delete]";
        private const string PROC_USERPACKAGE_GETBYUSERID = "[Core].[Proc_UserPackage_GetByUserId]";
        private const string PROC_USERPACKAGE_DELETEBYUSERID = "[Core].[Proc_UserPackage_DeleteByUserId]";
        #endregion SQL Procedures
        #region Parameters
        private const string ID = "ID";
        private const string USERID = "UserId";
        private const string PACKAGEID = "PackageId";
        private const string ISACTIVE = "IsActive";
        private const string CREATEDBY = "CreatedBy";
        private const string CREATEDDATE = "CreatedDate";
        private const string UPDATEDBY = "UpdatedBy";
        private const string UPDATEDDATE = "UpdatedDate";
        #endregion Parameters
        #region Private Functions
        private long Insert(UserPackage _UserPackage, DbTransaction dbTransaction = null) {
            try {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_USERPACKAGE_INSERT)) {
                    _Database.AddInParameter(dbCommand, ID, DbType.Int64, _UserPackage.ID);
                    _Database.AddInParameter(dbCommand, USERID, DbType.Int64, _UserPackage.UserId);
                    _Database.AddInParameter(dbCommand, PACKAGEID, DbType.Int32, _UserPackage.PackageId);
                    _Database.AddInParameter(dbCommand, ISACTIVE, DbType.Boolean, _UserPackage.IsActive);
                    _Database.AddInParameter(dbCommand, CREATEDBY, DbType.String, _UserPackage.CreatedBy);

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
        private long Update(UserPackage _UserPackage, DbTransaction dbTransaction = null) {
            try {
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_USERPACKAGE_UPDATE)) {
                    _Database.AddInParameter(dbCommand, ID, DbType.Int64, _UserPackage.ID);
                    _Database.AddInParameter(dbCommand, USERID, DbType.Int64, _UserPackage.UserId);
                    _Database.AddInParameter(dbCommand, PACKAGEID, DbType.Int32, _UserPackage.PackageId);
                    _Database.AddInParameter(dbCommand, ISACTIVE, DbType.Boolean, _UserPackage.IsActive);
                    _Database.AddInParameter(dbCommand, UPDATEDBY, DbType.String, _UserPackage.UpdatedBy);

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
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_USERPACKAGE_DELETE)) {
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
                using (DbCommand dbCommand = _Database.GetStoredProcCommand(PROC_USERPACKAGE_DELETEBYUSERID)) {
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
        private IEnumerable<UserPackage> GetByUserId(long UserId) {
            try {
                List<UserPackage> UserPackageList = null;
                using (DbCommand dbcmdUserPackage = _Database.GetStoredProcCommand(PROC_USERPACKAGE_GETBYUSERID)) {
                    _Database.AddInParameter(dbcmdUserPackage, USERID, DbType.Int64, UserId);

                    using (IDataReader reader = _Database.ExecuteReader(dbcmdUserPackage)) {
                        if (UserPackageList == null) {
                            UserPackageList = new List<UserPackage>();
                        }
                        UserPackageList.Add(Mapper(reader));
                    }
                }
                return UserPackageList;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private UserPackage GetById(long Id) {
            try {
                UserPackage UserPackage = null;
                using (DbCommand dbcmdUserPackage = _Database.GetStoredProcCommand(PROC_USERPACKAGE_GETBYID)) {
                    _Database.AddInParameter(dbcmdUserPackage, ID, DbType.Int32, Id);
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdUserPackage)) {
                        UserPackage = Mapper(reader);
                    }
                }
                return UserPackage;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private UserPackage Mapper(IDataReader reader) {
            try {
                UserPackage _UserPackage = new UserPackage();
                if (reader[ID] != null && reader[ID] != DBNull.Value) {
                    _UserPackage.ID = Common.Conversion.ToLong(reader[ID]);
                }

                if (reader[USERID] != null && reader[USERID] != DBNull.Value) {
                    _UserPackage.UserId = Common.Conversion.ToLong(reader[USERID]);
                }

                if (reader[PACKAGEID] != null && reader[PACKAGEID] != DBNull.Value) {
                    _UserPackage.PackageId = Common.Conversion.ToInt(reader[PACKAGEID]);
                }

                if (reader[ISACTIVE] != null && reader[ISACTIVE] != DBNull.Value) {
                    _UserPackage.IsActive = Common.Conversion.ToBool(reader[ISACTIVE]);
                }

                if (reader[CREATEDBY] != null && reader[CREATEDBY] != DBNull.Value) {
                    _UserPackage.CreatedBy = Common.Conversion.ToString(reader[CREATEDBY]);
                }

                if (reader[CREATEDDATE] != null && reader[CREATEDDATE] != DBNull.Value) {
                    _UserPackage.CreatedDate = Common.Conversion.ToDateTime(reader[CREATEDDATE]);
                }

                if (reader[UPDATEDBY] != null && reader[UPDATEDBY] != DBNull.Value) {
                    _UserPackage.UpdatedBy = Common.Conversion.ToString(reader[UPDATEDBY]);
                }

                if (reader[UPDATEDDATE] != null && reader[UPDATEDDATE] != DBNull.Value) {
                    _UserPackage.UpdatedDate = Common.Conversion.ToDateTime(reader[UPDATEDDATE]);
                }

                return _UserPackage;
            }
            catch (Exception exception) {
                throw exception;
            }
        }

        #endregion Private Functions
        #region Public Functions
        public void SaveUserPackages(long UserId, List<UserPackage> UserPackageList, DbTransaction dbTransaction = null) {
            try {
                DeleteByUserId(UserId, dbTransaction);
                if (UserPackageList != null && UserPackageList.Count > 0) {
                    foreach (UserPackage userPackage in UserPackageList) {
                        userPackage.UserId = UserId;
                        userPackage.IsActive = true;
                        if (userPackage.ID == 0) {
                            Insert(userPackage, dbTransaction);
                        }
                        else {
                            Update(userPackage, dbTransaction);
                        }
                    }
                }
            }
            catch (Exception exception) {

                throw exception;
            }
        }
        public IEnumerable<UserPackage> GetPackagesByUserId(long UserId) {
            try {
                return GetByUserId(UserId);

            }
            catch (Exception exception) {

                throw exception;
            }
        }

        public long DeletePackagesByUserId(long UserId) {
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
