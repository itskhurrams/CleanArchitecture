using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using Dapper;

using System.Data;

namespace Clean.Architecture.Persistance.Defination {
    public class AdminAccountData : IAdminAccountData {
        private readonly IDbConnection _connection;
        public AdminAccountData(IDbConnection connection) {
            _connection = connection;
        }
        #region SQL Procedures
        private const string PROC_ADMINACCOUNT_LOGIN = "[Core].[Proc_AdminAccount_Login]";
        #endregion SQL Procedures

        #region Private Functions
        private AdminAccount GetUser(string userName, string passWord) {
            return _connection.QueryFirstOrDefault<AdminAccount>(PROC_ADMINACCOUNT_LOGIN, new { UserName = userName, PassCode = passWord }, commandType: CommandType.StoredProcedure);
        }
        #endregion Private Functions
        #region Public Functions
        public AdminAccount Login(string UserName, string Password) {
            return GetUser(UserName, Password);
        }

        #endregion

    }
}
