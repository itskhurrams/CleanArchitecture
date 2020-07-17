using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using Microsoft.Practices.EnterpriseLibrary.Data;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.Defination {
    public class PackageData : IPackageData {
        private readonly Database _Database;
        public PackageData(Database Database) {
            _Database = Database;
        }
        #region SQL Procedures
        private const string PROC_PACKAGE_GETALL = "[Defination].[Proc_Package_GetAll]";
        private const string PROC_PACKAGE_GETBYID = "[Defination].[Proc_Package_GetById]";
        #endregion SQL Procedures
        #region Parameters
        private const string ID = "ID";
        private const string TITLE = "Title";
        private const string DETAIL = "Detail";
        private const string ISACTIVE = "IsActive";
        private const string CREATEDBY = "CreatedBy";
        private const string CREATEDDATE = "CreatedDate";
        private const string UPDATEDBY = "UpdatedBy";
        private const string UPDATEDDATE = "UpdatedDate";
        #endregion Parameters
        #region Private Functions
        private IEnumerable<Package> GetActivePackages() {
            try {
                List<Package> PackageList = null;
                using (DbCommand dbcmdPackage = _Database.GetStoredProcCommand(PROC_PACKAGE_GETALL)) {
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdPackage)) {
                        if (PackageList == null) {
                            PackageList = new List<Package>();
                        }
                        PackageList.Add(Mapper(reader));
                    }
                }
                return PackageList;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private Package GetPackage(int Id) {
            try {
                Package Package = null;
                using (DbCommand dbcmdPackage = _Database.GetStoredProcCommand(PROC_PACKAGE_GETBYID)) {
                    _Database.AddInParameter(dbcmdPackage, ID, DbType.Int16, Id);
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdPackage)) {
                        Package = Mapper(reader);
                    }
                }
                return Package;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private Package Mapper(IDataReader reader) {
            try {
                Package _Package = new Package();
                if (reader[ID] != null && reader[ID] != DBNull.Value) {
                    _Package.ID = Common.Conversion.ToInt(reader[ID]);
                }
                if (reader[TITLE] != null && reader[TITLE] != DBNull.Value) {
                    _Package.Title = Common.Conversion.ToString(reader[TITLE]);
                }
                if (reader[DETAIL] != null && reader[DETAIL] != DBNull.Value) {
                    _Package.Detail = Common.Conversion.ToString(reader[DETAIL]);
                }
                if (reader[ISACTIVE] != null && reader[ISACTIVE] != DBNull.Value) {
                    _Package.IsActive = Common.Conversion.ToBool(reader[ISACTIVE]);
                }
                if (reader[CREATEDBY] != null && reader[CREATEDBY] != DBNull.Value) {
                    _Package.CreatedBy = Common.Conversion.ToString(reader[CREATEDBY]);
                }
                if (reader[CREATEDDATE] != null && reader[CREATEDDATE] != DBNull.Value) {
                    _Package.CreatedDate = Common.Conversion.ToDateTime(reader[CREATEDDATE]);
                }
                if (reader[UPDATEDBY] != null && reader[UPDATEDBY] != DBNull.Value) {
                    _Package.UpdatedBy = Common.Conversion.ToString(reader[UPDATEDBY]);
                }
                if (reader[UPDATEDDATE] != null && reader[UPDATEDDATE] != DBNull.Value) {
                    _Package.UpdatedDate = Common.Conversion.ToDateTime(reader[UPDATEDDATE]);
                }
                return _Package;
            }
            catch (Exception exception) {
                throw exception;
            }
        }
        #endregion Private Functions
        #region Public Functions
        public Package GetPackageById(int Id) {
            try {
                return GetPackage(Id);
            }
            catch (Exception exception) {
                throw exception;
            }
        }
        public IEnumerable<Package> GetPackages() {
            try {
                return GetActivePackages();
            }
            catch (Exception exception) {
                throw exception;
            }
        }
        #endregion
    }
}
