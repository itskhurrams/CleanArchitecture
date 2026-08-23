using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using Microsoft.Practices.EnterpriseLibrary.Data;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.Defination {
    public class SufixData : ISufixData {
        private readonly Database _Database;
        public SufixData(Database Database) {
            _Database = Database;
        }
        #region SQL Procedures
        private const string PROC_SUFIX_GETALL = "[Defination].[Proc_Sufix_GetAll]";
        private const string PROC_SUFIX_GETBYID = "[Defination].[Proc_Sufix_GetById]";
        #endregion SQL Procedures
        #region Parameters
        private const string ID = "ID";
        private const string SUFIXTITLE = "SufixTitle";
        private const string ISACITVE = "IsAcitve";
        #endregion Parameters
        #region Private Functions
        private IEnumerable<Sufix> GetActiveSufixs() {
            List<Sufix> sufixList = new List<Sufix>();
            using (DbCommand dbcmdSufix = _Database.GetStoredProcCommand(PROC_SUFIX_GETALL)) {
                using (IDataReader reader = _Database.ExecuteReader(dbcmdSufix)) {
                    while (reader.Read()) {
                        sufixList.Add(Mapper(reader));
                    }
                }
            }
            return sufixList;
        }
        private Sufix GetSufix(short Id) {
            Sufix sufix = null;
            using (DbCommand dbcmdSufix = _Database.GetStoredProcCommand(PROC_SUFIX_GETBYID)) {
                _Database.AddInParameter(dbcmdSufix, ID, DbType.Int16, Id);
                using (IDataReader reader = _Database.ExecuteReader(dbcmdSufix)) {
                    if (reader.Read()) {
                        sufix = Mapper(reader);
                    }
                }
            }
            return sufix;
        }
        private Sufix Mapper(IDataReader reader) {
            Sufix _Sufix = new Sufix();
            if (reader[ID] != null && reader[ID] != DBNull.Value) {
                _Sufix.ID = Common.Conversion.ToShort(reader[ID]);
            }

            if (reader[SUFIXTITLE] != null && reader[SUFIXTITLE] != DBNull.Value) {
                _Sufix.SufixTitle = Common.Conversion.ToString(reader[SUFIXTITLE]);
            }

            try {
                if (reader[ISACITVE] != null && reader[ISACITVE] != DBNull.Value) {
                    _Sufix.IsAcitve = Common.Conversion.ToBool(reader[ISACITVE]);
                }
            }
            catch {
                try {
                    if (reader["IsActive"] != null && reader["IsActive"] != DBNull.Value) {
                        _Sufix.IsAcitve = Common.Conversion.ToBool(reader["IsActive"]);
                    }
                }
                catch { }
            }

            return _Sufix;
        }
        #endregion Private Functions
        #region Public Functions
        public Sufix GetSufixById(short Id) {
            return GetSufix(Id);
        }
        public IEnumerable<Sufix> GetSufixes() {
            return GetActiveSufixs();
        }
        #endregion
    }
}
