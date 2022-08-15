/*************************************************************************************************************
* Programa: XQuerySqlite.cs                                                                                  *
**************************************************************************************************************
* Descripción: Consulta a DB de SQLite                                                                       *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/


using System.Data.Common;
using System.Data.SQLite;
using XDatabase.Core;

namespace XDatabase
{
    public class XQuerySqlite : XQuery
    {
        public XQuerySqlite()
        {
            
        }

        public XQuerySqlite(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override DbParameter GetParameter() => new SQLiteParameter();
        protected override DbConnection GetConnection() => new SQLiteConnection();
        protected override DbDataAdapter GetDataAdapter() => new SQLiteDataAdapter();
        protected override DbCommand GetCommand() => new SQLiteCommand();
    }
}
