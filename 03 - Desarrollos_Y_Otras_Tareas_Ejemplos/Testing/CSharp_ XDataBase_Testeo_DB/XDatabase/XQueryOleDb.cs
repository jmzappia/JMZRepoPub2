/*************************************************************************************************************
* Programa: XQueryOleDb.cs                                                                                   *
**************************************************************************************************************
* Descripción: Consulta a BD mediante OLE                                                                    *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/


using System.Data.Common;
using System.Data.OleDb;
using XDatabase.Core;

namespace XDatabase
{
    public class XQueryOleDb : XQuery
    {
        public XQueryOleDb()
        {
            
        }

        public XQueryOleDb(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override DbParameter GetParameter() => new OleDbParameter();
        protected override DbConnection GetConnection() => new OleDbConnection();
        protected override DbDataAdapter GetDataAdapter() => new OleDbDataAdapter();
        protected override DbCommand GetCommand() => new OleDbCommand();
    }
}
