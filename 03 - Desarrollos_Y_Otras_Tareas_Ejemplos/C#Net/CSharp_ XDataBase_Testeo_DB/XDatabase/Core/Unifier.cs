/*************************************************************************************************************
* Programa: Unifier.cs                                                                                       *
**************************************************************************************************************
* Descripción: Procedimiento de Core XDataBase - Unifica conexión a BD                                       *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/


using System.Data.Common;

namespace XDatabase.Core
{
    public abstract partial class XQuery
    {
        protected abstract DbParameter GetParameter();
        protected abstract DbConnection GetConnection();
        protected abstract DbDataAdapter GetDataAdapter();
        protected abstract DbCommand GetCommand();

        private DbParameter GetParameter(string name, object value)
        {
            var parameter = GetParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            return parameter;
        }
    }
}
