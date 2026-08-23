using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using Microsoft.Practices.EnterpriseLibrary.Data;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.Defination {
    public class PrefixData : IPrefixData {
        private readonly Database _Database;
        public PrefixData(Database Database) {
            _Database = Database;
        }
        #region SQL Procedures
        private const string PROC_PREFIX_GETALL = "[Defination].[Proc_Prefix_GetAll]";
        private const string PROC_PREFIX_GETBYID = "[Defination].[Proc_Prefix_GetById]";
        #endregion SQL Procedures
        #region Parameters
        private const string ID = "ID";
        private const string PREFIXTITLE = "PrefixTitle";
        private const string ISACTIVE = "IsActive";
        #endregion Parameters
        #region Private Functions
        private IEnumerable<Prefix> GetActivePrefixs() {
            List<Prefix> prefixList = new List<Prefix>();
            using (DbCommand dbcmdPrefix = _Database.GetStoredProcCommand(PROC_PREFIX_GETALL)) {
                using (IDataReader reader = _Database.ExecuteReader(dbcmdPrefix)) {
                    while (reader.Read()) {
                        prefixList.Add(Mapper(reader));
                    }
                }
            }
            return prefixList;
        }
        private Prefix GetPrefix(short Id) {
            Prefix prefix = null;
            using (DbCommand dbcmdPrefix = _Database.GetStoredProcCommand(PROC_PREFIX_GETBYID)) {
                _Database.AddInParameter(dbcmdPrefix, ID, DbType.Int16, Id);
                using (IDataReader reader = _Database.ExecuteReader(dbcmdPrefix)) {
                    if (reader.Read()) {
                        prefix = Mapper(reader);
                    }
                }
            }
            return prefix;
        }
        private Prefix Mapper(IDataReader reader) {
            Prefix _Prefix = new Prefix();
            if (reader[ID] != null && reader[ID] != DBNull.Value) {
                _Prefix.ID = Common.Conversion.ToShort(reader[ID]);
            }

            if (reader[PREFIXTITLE] != null && reader[PREFIXTITLE] != DBNull.Value) {
                _Prefix.PrefixTitle = Common.Conversion.ToString(reader[PREFIXTITLE]);
            }

            if (reader[ISACTIVE] != null && reader[ISACTIVE] != DBNull.Value) {
                _Prefix.IsActive = Common.Conversion.ToBool(reader[ISACTIVE]);
            }

            return _Prefix;
        }
        #endregion Private Functions
        #region Public Functions
        public Prefix GetPrefixById(short Id) {
            return GetPrefix(Id);
        }
        public IEnumerable<Prefix> GetPrefixes() {
            return GetActivePrefixs();
        }
        #endregion
    }
}
