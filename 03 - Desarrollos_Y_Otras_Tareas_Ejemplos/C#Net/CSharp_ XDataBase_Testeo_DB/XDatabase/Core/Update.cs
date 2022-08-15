/*************************************************************************************************************
* Programa: Update.cs                                                                                        *
**************************************************************************************************************
* Descripción: Procedimiento de Core XDataBase - Actualización de formato BD                                 *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/


using System;
using System.Data.Common;

namespace XDatabase.Core
{
    public abstract partial class XQuery
    {
        public int Update(string pSqlQuery, params XParameter[] args)
        {
            ClearError();
            try
            {
                if (!IsConnectionActive)
                {
                    OpenConnection();
                }
                using (var command = GetCommand())
                {
                    command.Connection = Connection;
                    command.CommandText = pSqlQuery;
                    command.CommandTimeout = Timeout;

                    if (args != null)
                    {
                        foreach (var arg in args)
                        {
                            var parameter = GetParameter(arg.ParameterName, arg.Value);
                            command.Parameters.Add(parameter);
                        }
                    }
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                RegisterError(ex.Message);
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        public int Delete(string pSqlQuery, params XParameter[] args)
        {
            return Update(pSqlQuery, args);
        }

        public int Insert(string pSqlQuery, params XParameter[] args)
        {
            return Update(pSqlQuery, args);
        }

        public int Create(string pSqlQuery, params XParameter[] args)
        {
            return Update(pSqlQuery, args);
        }
    }
}
