using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using Microsoft.Practices.EnterpriseLibrary.Data;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.Defination {
    public class BusinessTypeData : IBusinessTypeData {
        private readonly Database _Database;
        public BusinessTypeData(Database Database) {
            _Database = Database;
        }
        #region SQL Procedures
        private const string PROC_BUSINESSTYPE_GETALL = "[Defination].[Proc_BusinessType_GetAll]";
        private const string PROC_BUSINESSTYPE_GETBYID = "[Defination].[Proc_BusinessType_GetById]";
        #endregion SQL Procedures
        #region Parameters
        private const string ID = "ID";
        private const string BUSINESSTYPETITLE = "BusinessTypeTitle";
        private const string BUSINESSTYPEDESCRIPTION = "BusinessTypeDescription";
        private const string ISACTIVE = "IsActive";
        #endregion Parameters
        #region Private Functions
        private IEnumerable<BusinessType> GetActiveBusinessTypes() {
            List<BusinessType> businessTypeList = new List<BusinessType>();
            using (DbCommand dbcmdBusinessType = _Database.GetStoredProcCommand(PROC_BUSINESSTYPE_GETALL)) {
                using (IDataReader reader = _Database.ExecuteReader(dbcmdBusinessType)) {
                    while (reader.Read()) {
                        businessTypeList.Add(Mapper(reader));
                    }
                }
            }
            return businessTypeList;
        }
        private BusinessType GetBusinessType(short Id) {
            BusinessType businessType = null;
            using (DbCommand dbcmdBusinessType = _Database.GetStoredProcCommand(PROC_BUSINESSTYPE_GETBYID)) {
                _Database.AddInParameter(dbcmdBusinessType, ID, DbType.Int16, Id);
                using (IDataReader reader = _Database.ExecuteReader(dbcmdBusinessType)) {
                    if (reader.Read()) {
                        businessType = Mapper(reader);
                    }
                }
            }
            return businessType;
        }
        private BusinessType Mapper(IDataReader reader) {
            BusinessType _BusinessType = new BusinessType();
            if (reader[ID] != null && reader[ID] != DBNull.Value) {
                _BusinessType.ID = Common.Conversion.ToShort(reader[ID]);
            }

            if (reader[BUSINESSTYPETITLE] != null && reader[BUSINESSTYPETITLE] != DBNull.Value) {
                _BusinessType.BusinessTypeTitle = Common.Conversion.ToString(reader[BUSINESSTYPETITLE]);
            }

            if (reader[BUSINESSTYPEDESCRIPTION] != null && reader[BUSINESSTYPEDESCRIPTION] != DBNull.Value) {
                _BusinessType.BusinessTypeDescription = Common.Conversion.ToString(reader[BUSINESSTYPEDESCRIPTION]);
            }

            if (reader[ISACTIVE] != null && reader[ISACTIVE] != DBNull.Value) {
                _BusinessType.IsActive = Common.Conversion.ToBool(reader[ISACTIVE]);
            }

            return _BusinessType;
        }
        #endregion Private Functions
        #region Public Functions
        public BusinessType GetBusinessTypeById(short Id) {
            return GetBusinessType(Id);
        }
        public IEnumerable<BusinessType> GetBusinessTypes() {
            return GetActiveBusinessTypes();
        }
        #endregion
    }
}
