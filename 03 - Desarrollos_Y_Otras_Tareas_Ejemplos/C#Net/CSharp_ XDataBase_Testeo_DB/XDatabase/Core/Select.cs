/*************************************************************************************************************
* Programa: Select.cs                                                                                        *
**************************************************************************************************************
* Descripción: Procedimiento de Core XDataBase - Selección de conexión a BD                                  *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/


using System;
using System.Data;

namespace XDatabase.Core
{
    public abstract partial class XQuery
    {
        public DataTable SelectTable(string sqlQuery, params XParameter[] args)
        {
            ClearError();
            var tableResults = new DataTable();
            try
            {
                if (!IsConnectionActive)
                {
                    OpenConnection();
                }
                using (var adapter = GetDataAdapter())
                {
                    var command = GetCommand();
                    command.Connection = Connection;
                    command.CommandText = sqlQuery;
                    command.CommandTimeout = Timeout;

                    adapter.SelectCommand = command;

                    adapter.SelectCommand.Parameters.Clear();
                    
                    if (args != null)
                    {
                        foreach (var arg in args)
                        {
                            var parameter = GetParameter(arg.ParameterName, arg.Value);
                            adapter.SelectCommand.Parameters.Add(parameter);
                        }
                    }
                    adapter.Fill(tableResults);
                    return tableResults;
                }
            }
            catch (Exception ex)
            {
                RegisterError(ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataRow SelectRow(string sqlQuery, params XParameter[] args)
        {
            var table = SelectTable(sqlQuery, args);
            return table != null && table.Rows.Count == 1 ? table.Rows[0] : null;
        }

        public DataColumn SelectColumn(string sqlQuery, params XParameter[] args)
        {
            var table = SelectTable(sqlQuery, args);
            return table != null && table.Columns.Count == 1 ? table.Columns[0] : null;
        }

        public T SelectCellAs<T>(string sqlQuery, params XParameter[] args)
        {
            var table = SelectTable(sqlQuery, args);
            if (table != null && 
                table.Rows.Count == 1 && 
                table.Columns.Count == 1 && 
                table.Rows[0].ItemArray[0].GetType() == typeof(T))
            {
                return (T)table.Rows[0].ItemArray[0];
            }

            if (table != null && 
                table.Rows.Count == 1 && 
                table.Columns.Count == 1)
            {
                throw new FormatException($"Tipo de celdas: {table.Rows[0].ItemArray[0].GetType()}.");
            }

            if (table != null && 
                (table.Rows.Count != 1 || 
                 table.Columns.Count != 1))
            {
                throw new DataException($"Retorno de resultados: {table.Rows.Count}x{table.Columns.Count}.");
            }

            throw new DataException("No hay datos. Tabla vacía.");
        }

        public T SelectCellAs<T>(string sqlQuery, T defaultValue = default(T), params XParameter[] args)
        {
            var table = SelectTable(sqlQuery, args);
            if (table != null && table.Rows.Count == 1 && table.Columns.Count == 1 && table.Rows[0].ItemArray[0].GetType() == typeof(T))
            {
                return (T)table.Rows[0].ItemArray[0];
            }
            else
            {
                return defaultValue;
            }
        }
    }
}
