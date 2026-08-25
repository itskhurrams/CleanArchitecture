using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using Dapper;

using System.Collections.Generic;
using System.Data;

namespace Clean.Architecture.Persistance.Defination {
    public class PrefixData : IPrefixData {
        private readonly IDbConnection _connection;
        public PrefixData(IDbConnection connection) {
            _connection = connection;
        }
        #region SQL Procedures
        private const string PROC_PREFIX_GETALL = "[Defination].[Proc_Prefix_GetAll]";
        private const string PROC_PREFIX_GETBYID = "[Defination].[Proc_Prefix_GetById]";
        #endregion SQL Procedures
        #region Private Functions
        private IEnumerable<Prefix> GetActivePrefixs() {
            return _connection.Query<Prefix>(PROC_PREFIX_GETALL, commandType: CommandType.StoredProcedure);
        }
        private Prefix GetPrefix(short Id) {
            return _connection.QueryFirstOrDefault<Prefix>(PROC_PREFIX_GETBYID, new { ID = Id }, commandType: CommandType.StoredProcedure);
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
