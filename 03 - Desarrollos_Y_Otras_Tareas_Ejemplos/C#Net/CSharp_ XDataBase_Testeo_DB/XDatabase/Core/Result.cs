/*************************************************************************************************************
* Programa: Result.cs                                                                                        *
**************************************************************************************************************
* Descripción: Procedimiento de Core XDataBase - Resultados de consultas                                     *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/

namespace XDatabase.Core
{
    public abstract partial class XQuery
    {
        public enum XResult
        {
            Error = -1,
            NothingChanged = 0,
            ChangesApplied = 1
        }
    }
}
