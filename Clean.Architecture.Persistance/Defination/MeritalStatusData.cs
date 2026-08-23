using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using Microsoft.Practices.EnterpriseLibrary.Data;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.Defination {
    public class MeritalStatusData : IMeritalStatusData {
        private readonly Database _Database;
        public MeritalStatusData(Database Database) {
            _Database = Database;
        }
        #region SQL Procedures
        private const string PROC_MERITALSTATUS_GETALL = "[Defination].[Proc_MeritalStatus_GetAll]";
        private const string PROC_MERITALSTATUS_GETBYID = "[Defination].[Proc_MeritalStatus_GetById]";
        #endregion SQL Procedures
        #region Parameters
        private const string ID = "ID";
        private const string MERITALSTATUSTITLE = "MeritalStatusTitle";
        private const string ISACTIVE = "IsActive";
        #endregion Parameters
        #region Private Functions
        private IEnumerable<MeritalStatus> GetActiveMeritalStatuss() {
            List<MeritalStatus> meritalStatusList = new List<MeritalStatus>();
            using (DbCommand dbcmdMeritalStatus = _Database.GetStoredProcCommand(PROC_MERITALSTATUS_GETALL)) {
                using (IDataReader reader = _Database.ExecuteReader(dbcmdMeritalStatus)) {
                    while (reader.Read()) {
                        meritalStatusList.Add(Mapper(reader));
                    }
                }
            }
            return meritalStatusList;
        }
        private MeritalStatus GetMeritalStatus(short Id) {
            MeritalStatus meritalStatus = null;
            using (DbCommand dbcmdMeritalStatus = _Database.GetStoredProcCommand(PROC_MERITALSTATUS_GETBYID)) {
                _Database.AddInParameter(dbcmdMeritalStatus, ID, DbType.Int16, Id);
                using (IDataReader reader = _Database.ExecuteReader(dbcmdMeritalStatus)) {
                    if (reader.Read()) {
                        meritalStatus = Mapper(reader);
                    }
                }
            }
            return meritalStatus;
        }
        private MeritalStatus Mapper(IDataReader reader) {
            MeritalStatus _MeritalStatus = new MeritalStatus();
            if (reader[ID] != null && reader[ID] != DBNull.Value) {
                _MeritalStatus.ID = Common.Conversion.ToShort(reader[ID]);
            }

            if (reader[MERITALSTATUSTITLE] != null && reader[MERITALSTATUSTITLE] != DBNull.Value) {
                _MeritalStatus.MeritalStatusTitle = Common.Conversion.ToString(reader[MERITALSTATUSTITLE]);
            }

            if (reader[ISACTIVE] != null && reader[ISACTIVE] != DBNull.Value) {
                _MeritalStatus.IsActive = Common.Conversion.ToBool(reader[ISACTIVE]);
            }

            return _MeritalStatus;
        }
        #endregion Private Functions
        #region Public Functions
        public MeritalStatus GetMeritalStatusById(short Id) {
            return GetMeritalStatus(Id);
        }
        public IEnumerable<MeritalStatus> GetMeritalStatuses() {
            return GetActiveMeritalStatuss();
        }
        #endregion
    }
}
