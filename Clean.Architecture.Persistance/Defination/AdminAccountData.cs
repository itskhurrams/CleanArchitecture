using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using Microsoft.Practices.EnterpriseLibrary.Data;

using System;
using System.Data;
using System.Data.Common;

namespace Clean.Architecture.Persistance.Defination {
    public class AdminAccountData : IAdminAccountData {
        private readonly Database _Database;
        public AdminAccountData(Database Database) {
            _Database = Database;
        }
        #region SQL Procedures
        private const string PROC_ADMINACCOUNT_LOGIN = "[Core].[Proc_AdminAccount_Login]";
        #endregion SQL Procedures

        #region Parameters
        private const string ID = "ID";
        private const string USERNAME = "UserName";
        private const string PASSCODE = "PassCode";
        #endregion Parameters
        #region Private Functions
        private AdminAccount GetUser(string userName, string passWord) {
            try {
                AdminAccount AdminAccount = null;
                using (DbCommand dbcmdAdminAccount = _Database.GetStoredProcCommand(PROC_ADMINACCOUNT_LOGIN)) {
                    _Database.AddInParameter(dbcmdAdminAccount, USERNAME, DbType.String, userName);
                    _Database.AddInParameter(dbcmdAdminAccount, PASSCODE, DbType.String, passWord);
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdAdminAccount)) {
                        AdminAccount = Mapper(reader);
                    }
                }
                return AdminAccount;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private AdminAccount Mapper(IDataReader reader) {
            try {
                AdminAccount _AdminAccount = new AdminAccount();
                if (reader[ID] != null && reader[ID] != DBNull.Value) {
                    _AdminAccount.ID = Common.Conversion.ToLong(reader[ID]);
                }

                if (reader[USERNAME] != null && reader[USERNAME] != DBNull.Value) {
                    _AdminAccount.UserName = Common.Conversion.ToString(reader[USERNAME]);
                }

                if (reader[PASSCODE] != null && reader[PASSCODE] != DBNull.Value) {
                    _AdminAccount.PassCode = Common.Conversion.ToString(reader[PASSCODE]);
                }

                return _AdminAccount;
            }
            catch (Exception exception) {
                throw exception;
            }
        }
        #endregion Private Functions
        #region Public Functions
        public AdminAccount Login(string UserName, string Password) {
            try {
                return GetUser(UserName, Password);
            }
            catch (Exception exception) {
                throw exception;
            }
        }

        #endregion

    }
}
