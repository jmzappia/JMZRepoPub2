/*************************************************************************************************************
* Programa: XParameters.cs                                                                                   *
**************************************************************************************************************
* Descripción: Recepción de parámetros de conexión a BD                                                      *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/


namespace XDatabase
{
    public class XParameter
    {
        public string ParameterName;
        public object Value;

        public XParameter()
        {
        }

        public XParameter(string name, object value)
        {
            ParameterName = name;
            Value = value;
        }
    }
}
