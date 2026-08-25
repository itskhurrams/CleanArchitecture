using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using Dapper;

using System.Collections.Generic;
using System.Data;

namespace Clean.Architecture.Persistance.Defination {
    public class AddressTypeData : IAddressTypeData {
        private readonly IDbConnection _connection;
        public AddressTypeData(IDbConnection connection) {
            _connection = connection;
        }
        #region SQL Procedures
        private const string PROC_ADDRESSTYPE_GETALL = "[Defination].[Proc_AddressType_GetAll]";
        private const string PROC_ADDRESSTYPE_GETBYID = "[Defination].[Proc_AddressType_GetById]";
        #endregion SQL Procedures
        #region Private Functions
        private IEnumerable<AddressType> GetActiveAddressTypes() {
            return _connection.Query<AddressType>(PROC_ADDRESSTYPE_GETALL, commandType: CommandType.StoredProcedure);
        }
        private AddressType GetAddressType(short Id) {
            return _connection.QueryFirstOrDefault<AddressType>(PROC_ADDRESSTYPE_GETBYID, new { ID = Id }, commandType: CommandType.StoredProcedure);
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
