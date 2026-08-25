using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using Dapper;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Clean.Architecture.Persistance.Defination {
    public class SufixData : ISufixData {
        private readonly IDbConnection _connection;
        public SufixData(IDbConnection connection) {
            _connection = connection;
        }
        #region SQL Procedures
        private const string PROC_SUFIX_GETALL = "[Defination].[Proc_Sufix_GetAll]";
        private const string PROC_SUFIX_GETBYID = "[Defination].[Proc_Sufix_GetById]";
        #endregion SQL Procedures
        #region Private Functions
        private IEnumerable<Sufix> GetActiveSufixs() {
            IEnumerable<dynamic> rows = _connection.Query(PROC_SUFIX_GETALL, commandType: CommandType.StoredProcedure);
            return rows.Select(Mapper).ToList();
        }
        private Sufix GetSufix(short Id) {
            dynamic row = _connection.QueryFirstOrDefault(PROC_SUFIX_GETBYID, new { ID = Id }, commandType: CommandType.StoredProcedure);
            return row == null ? null : Mapper(row);
        }
        private Sufix Mapper(dynamic row) {
            IDictionary<string, object> columns = row;
            Sufix _Sufix = new Sufix();
            if (columns.TryGetValue("ID", out object id) && id != null) {
                _Sufix.ID = Convert.ToInt16(id);
            }

            if (columns.TryGetValue("SufixTitle", out object sufixTitle) && sufixTitle != null) {
                _Sufix.SufixTitle = Convert.ToString(sufixTitle);
            }

            if (columns.TryGetValue("IsAcitve", out object isAcitve) && isAcitve != null) {
                _Sufix.IsAcitve = Convert.ToBoolean(isAcitve);
            }
            else if (columns.TryGetValue("IsActive", out object isActive) && isActive != null) {
                _Sufix.IsAcitve = Convert.ToBoolean(isActive);
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
