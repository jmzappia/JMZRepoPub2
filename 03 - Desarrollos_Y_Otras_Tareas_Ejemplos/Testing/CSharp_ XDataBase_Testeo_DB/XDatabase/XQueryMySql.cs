/*************************************************************************************************************
* Programa: XQueryMySql.cs                                                                                   *
**************************************************************************************************************
* Descripción: Consulta a base de datos MySQL                                                                *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/


using System.Data.Common;
using MySql.Data.MySqlClient;
using XDatabase.Core;

namespace XDatabase
{
    public class XQueryMySql : XQuery
    {
        public XQueryMySql()
        {
            
        }

        public XQueryMySql(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override DbParameter GetParameter() => new MySqlParameter();
        protected override DbConnection GetConnection() => new MySqlConnection();
        protected override DbDataAdapter GetDataAdapter() => new MySqlDataAdapter();
        protected override DbCommand GetCommand() => new MySqlCommand();
    }
}
