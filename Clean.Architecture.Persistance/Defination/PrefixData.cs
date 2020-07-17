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
            try {
                List<Prefix> PrefixList = null;
                using (DbCommand dbcmdPrefix = _Database.GetStoredProcCommand(PROC_PREFIX_GETALL)) {
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdPrefix)) {
                        if (PrefixList == null) {
                            PrefixList = new List<Prefix>();
                        }
                        PrefixList.Add(Mapper(reader));
                    }
                }
                return PrefixList;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private Prefix GetPrefix(short Id) {
            try {
                Prefix Prefix = null;
                using (DbCommand dbcmdPrefix = _Database.GetStoredProcCommand(PROC_PREFIX_GETBYID)) {
                    _Database.AddInParameter(dbcmdPrefix, ID, DbType.Int16, Id);
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdPrefix)) {
                        Prefix = Mapper(reader);
                    }
                }
                return Prefix;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private Prefix Mapper(IDataReader reader) {
            try {
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
            catch (Exception exception) {
                throw exception;
            }
        }
        #endregion Private Functions
        #region Public Functions
        public Prefix GetPrefixById(short Id) {
            try {
                return GetPrefix(Id);
            }
            catch (Exception exception) {
                throw exception;
            }
        }
        public IEnumerable<Prefix> GetPrefixes() {
            try {
                return GetActivePrefixs();
            }
            catch (Exception exception) {
                throw exception;
            }
        }
        #endregion
    }
}
