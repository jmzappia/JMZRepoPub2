/*************************************************************************************************************
* Programa: XQueryMsSql.cs                                                                                   *
**************************************************************************************************************
* Descripción: Consulta a base de datos MS SQL                                                               *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/


using System.Data.Common;
using System.Data.SqlClient;
using XDatabase.Core;

namespace XDatabase
{
    public class XQueryMsSql : XQuery
    {
        public XQueryMsSql()
        {

        }

        public XQueryMsSql(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override DbParameter GetParameter() => new SqlParameter();
        protected override DbConnection GetConnection() => new SqlConnection();
        protected override DbDataAdapter GetDataAdapter() => new SqlDataAdapter();
        protected override DbCommand GetCommand() => new SqlCommand();
    }
}
