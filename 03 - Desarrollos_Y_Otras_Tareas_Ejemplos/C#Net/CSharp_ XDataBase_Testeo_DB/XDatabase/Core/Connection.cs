/*************************************************************************************************************
* Programa: Connections.cs                                                                                   *
**************************************************************************************************************
* Descripción: Procedimiento de Core XDataBase - Conexiones a BD                                             *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/

using System;
using System.Data;
using System.Data.Common;

namespace XDatabase.Core
{
    public abstract partial class XQuery : IDisposable
    {
        public DbConnection Connection { get; private set; }
        public string ConnectionString;

        public bool KeepConnectionOpen
        {
            get { return _keepOpen;}
            set
            {
                _keepOpen = value;
                if (!value)
                {
                    CloseConnection();
                }
            }
        }

        public int Timeout
        {
            get { return _timeout; }
            set
            {
                if (value > 0)
                {
                    _timeout = value;
                }
            }
        }

        public bool IsConnectionActive
        {
            get
            {
                if (Connection != null)
                {
                    return Connection.State == ConnectionState.Open ||
                           Connection.State == ConnectionState.Executing ||
                           Connection.State == ConnectionState.Fetching;
                }
                return false;
            }
        }

        public bool TestConnection(string connectionString = null)
        {
            ClearError();

            using (var newConnection = GetConnection())
            {
                try
                {
                    newConnection.ConnectionString = connectionString ?? ConnectionString;
                    newConnection.Open();
                    newConnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    RegisterError(ex.Message);
                    return false;
                }
            }
        }

        private int _timeout = TimeSpan.FromSeconds(30).Seconds;
        private bool _keepOpen = false;

        private void OpenConnection()
        {
            ClearError();

            Connection = GetConnection();
            try
            {
                Connection.ConnectionString = ConnectionString;
                Connection.Open();
            }
            catch (Exception ex)
            {
                RegisterError(ex.Message);
            }
        }

        private void CloseConnection()
        {
            if (Connection != null && !IsInTransactionMode && !KeepConnectionOpen)
            {
                Connection.Close();
            }
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
