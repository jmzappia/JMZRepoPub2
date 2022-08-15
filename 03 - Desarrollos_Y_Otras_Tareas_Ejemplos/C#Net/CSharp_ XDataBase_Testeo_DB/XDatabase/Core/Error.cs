/*************************************************************************************************************
* Programa: Error.cs                                                                                         *
**************************************************************************************************************
* Descripción: Procedimiento de Core XDataBase - Errores de Ejecución                                        *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/


namespace XDatabase.Core
{
    public abstract partial class XQuery
    {
        public string LastErrorMessage { get; private set; }

        public delegate void ErrorEventHandler(string pErrorMessage);
        public event ErrorEventHandler OnError;
       
        private void RegisterError(string message)
        {
            LastErrorMessage = message;

            if (OnError != null)
            {
                OnError(LastErrorMessage);
            }
        }

        private void ClearError()
        {
            LastErrorMessage = null;
        }
    }
}
