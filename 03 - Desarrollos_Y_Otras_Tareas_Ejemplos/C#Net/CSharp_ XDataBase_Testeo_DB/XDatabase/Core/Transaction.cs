/*************************************************************************************************************
* Programa: Transaction.cs                                                                                   *
**************************************************************************************************************
* Descripción: Procedimiento de Core XDataBase - Transacciones en BD                                         *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/


using System;
using System.Data.Common;

namespace XDatabase.Core
{
    public abstract partial class XQuery
    {
        public bool IsInTransactionMode => _transaction != null;
        private DbTransaction _transaction;

        public bool BeginTransaction()
        {
            ClearError();
            try
            {
                if (!IsConnectionActive)
                {
                    OpenConnection();
                }
                _transaction = Connection.BeginTransaction();
                return true;
            }
            catch (Exception ex)
            {
                RegisterError(ex.Message);
                return false;
            }
        }

        public bool CommitTransaction()
        {
            ClearError();
            try
            {
                _transaction.Commit();
                _transaction = null;
                return true;
            }
            catch (Exception ex)
            {
                RegisterError(ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool RollbackTransaction()
        {
            ClearError();
            try
            {
                _transaction.Rollback();
                _transaction = null;
                return true;
            }
            catch (Exception ex)
            {
                RegisterError(ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
