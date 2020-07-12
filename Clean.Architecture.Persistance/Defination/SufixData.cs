using Microsoft.Practices.EnterpriseLibrary.Data;
using Clean.Architecture.Domain.Defination;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Clean.Architecture.Domain.Interfaces.Defination;

namespace Clean.Architecture.Persistance.Defination
{
    public class SufixData : ISufixData
    {
        private readonly Database _Database;
        public SufixData(Database Database)
        {
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
        private IEnumerable<Sufix> GetActiveSufixs()
        {
            try
            {
                List<Sufix> SufixList = null;
                using (DbCommand dbcmdSufix = _Database.GetStoredProcCommand(PROC_SUFIX_GETALL))
                {
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdSufix))
                    {
                        if (SufixList == null)
                        {
                            SufixList = new List<Sufix>();
                        }
                        SufixList.Add(Mapper(reader));
                    }
                }
                return SufixList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private Sufix GetSufix(short Id)
        {
            try
            {
                Sufix Sufix = null;
                using (DbCommand dbcmdSufix = _Database.GetStoredProcCommand(PROC_SUFIX_GETBYID))
                {
                    _Database.AddInParameter(dbcmdSufix, ID, DbType.Int16, Id);
                    using (IDataReader reader = _Database.ExecuteReader(dbcmdSufix))
                    {
                        Sufix = Mapper(reader);
                    }
                }
                return Sufix;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private Sufix Mapper(IDataReader reader)
        {
            try
            {
                Sufix _Sufix = new Sufix();
                if (reader[ID] != null && reader[ID] != DBNull.Value)
                {
                    _Sufix.ID = Common.Conversion.ToShort(reader[ID]);
                }

                if (reader[SUFIXTITLE] != null && reader[SUFIXTITLE] != DBNull.Value)
                {
                    _Sufix.SufixTitle = Common.Conversion.ToString(reader[SUFIXTITLE]);
                }

                if (reader[ISACITVE] != null && reader[ISACITVE] != DBNull.Value)
                {
                    _Sufix.IsAcitve = Common.Conversion.ToBool(reader[ISACITVE]);
                }

                return _Sufix;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        #endregion Private Functions
        #region Public Functions
        public Sufix GetSufixById(short Id)
        {
            try
            {
                return GetSufix(Id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public IEnumerable<Sufix> GetSufixes()
        {
            try
            {
                return GetActiveSufixs();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        #endregion
    }
}
