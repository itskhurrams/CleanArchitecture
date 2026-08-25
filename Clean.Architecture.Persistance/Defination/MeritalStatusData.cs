using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using Dapper;

using System.Collections.Generic;
using System.Data;

namespace Clean.Architecture.Persistance.Defination {
    public class MeritalStatusData : IMeritalStatusData {
        private readonly IDbConnection _connection;
        public MeritalStatusData(IDbConnection connection) {
            _connection = connection;
        }
        #region SQL Procedures
        private const string PROC_MERITALSTATUS_GETALL = "[Defination].[Proc_MeritalStatus_GetAll]";
        private const string PROC_MERITALSTATUS_GETBYID = "[Defination].[Proc_MeritalStatus_GetById]";
        #endregion SQL Procedures
        #region Private Functions
        private IEnumerable<MeritalStatus> GetActiveMeritalStatuss() {
            return _connection.Query<MeritalStatus>(PROC_MERITALSTATUS_GETALL, commandType: CommandType.StoredProcedure);
        }
        private MeritalStatus GetMeritalStatus(short Id) {
            return _connection.QueryFirstOrDefault<MeritalStatus>(PROC_MERITALSTATUS_GETBYID, new { ID = Id }, commandType: CommandType.StoredProcedure);
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
