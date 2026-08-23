using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using Microsoft.Practices.EnterpriseLibrary.Data;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.Defination {
    public class AddressTypeData : IAddressTypeData {
        private readonly Database _Database;
        public AddressTypeData(Database Database) {
            _Database = Database;
        }
        #region SQL Procedures
        private const string PROC_ADDRESSTYPE_GETALL = "[Defination].[Proc_AddressType_GetAll]";
        private const string PROC_ADDRESSTYPE_GETBYID = "[Defination].[Proc_AddressType_GetById]";
        #endregion SQL Procedures
        #region Parameters
        private const string ID = "ID";
        private const string ADDRESSTYPETITLE = "AddressTypeTitle";
        private const string ADDRESSTYPEDESCRIPTION = "AddressTypeDescription";
        private const string ISACTIVE = "IsActive";
        #endregion Parameters
        #region Private Functions
        private IEnumerable<AddressType> GetActiveAddressTypes() {
            List<AddressType> addressTypeList = new List<AddressType>();
            using (DbCommand dbcmdAddressType = _Database.GetStoredProcCommand(PROC_ADDRESSTYPE_GETALL)) {
                using (IDataReader reader = _Database.ExecuteReader(dbcmdAddressType)) {
                    while (reader.Read()) {
                        addressTypeList.Add(Mapper(reader));
                    }
                }
            }
            return addressTypeList;
        }
        private AddressType GetAddressType(short Id) {
            AddressType addressType = null;
            using (DbCommand dbcmdAddressType = _Database.GetStoredProcCommand(PROC_ADDRESSTYPE_GETBYID)) {
                _Database.AddInParameter(dbcmdAddressType, ID, DbType.Int16, Id);
                using (IDataReader reader = _Database.ExecuteReader(dbcmdAddressType)) {
                    if (reader.Read()) {
                        addressType = Mapper(reader);
                    }
                }
            }
            return addressType;
        }
        private AddressType Mapper(IDataReader reader) {
            AddressType _AddressType = new AddressType();
            if (reader[ID] != null && reader[ID] != DBNull.Value) {
                _AddressType.ID = Common.Conversion.ToShort(reader[ID]);
            }

            if (reader[ADDRESSTYPETITLE] != null && reader[ADDRESSTYPETITLE] != DBNull.Value) {
                _AddressType.AddressTypeTitle = Common.Conversion.ToString(reader[ADDRESSTYPETITLE]);
            }

            if (reader[ADDRESSTYPEDESCRIPTION] != null && reader[ADDRESSTYPEDESCRIPTION] != DBNull.Value) {
                _AddressType.AddressTypeDescription = Common.Conversion.ToString(reader[ADDRESSTYPEDESCRIPTION]);
            }

            if (reader[ISACTIVE] != null && reader[ISACTIVE] != DBNull.Value) {
                _AddressType.IsActive = Common.Conversion.ToBool(reader[ISACTIVE]);
            }

            return _AddressType;
        }
        #endregion Private Functions
        #region Public Functions
        public AddressType GetAddressTypeById(short Id) {
            return GetAddressType(Id);
        }

        public IEnumerable<AddressType> GetAddressTypes() {
            return GetActiveAddressTypes();
        }
        #endregion

    }
}
