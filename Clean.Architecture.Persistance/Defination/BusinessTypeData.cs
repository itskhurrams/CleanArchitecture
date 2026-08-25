using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using Dapper;

using System.Collections.Generic;
using System.Data;

namespace Clean.Architecture.Persistance.Defination {
    public class BusinessTypeData : IBusinessTypeData {
        private readonly IDbConnection _connection;
        public BusinessTypeData(IDbConnection connection) {
            _connection = connection;
        }
        #region SQL Procedures
        private const string PROC_BUSINESSTYPE_GETALL = "[Defination].[Proc_BusinessType_GetAll]";
        private const string PROC_BUSINESSTYPE_GETBYID = "[Defination].[Proc_BusinessType_GetById]";
        #endregion SQL Procedures
        #region Private Functions
        private IEnumerable<BusinessType> GetActiveBusinessTypes() {
            return _connection.Query<BusinessType>(PROC_BUSINESSTYPE_GETALL, commandType: CommandType.StoredProcedure);
        }
        private BusinessType GetBusinessType(short Id) {
            return _connection.QueryFirstOrDefault<BusinessType>(PROC_BUSINESSTYPE_GETBYID, new { ID = Id }, commandType: CommandType.StoredProcedure);
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
