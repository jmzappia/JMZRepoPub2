/*************************************************************************************************************
* Programa: OLeDbTest.cs                                                                                     *
**************************************************************************************************************
* Descripción: Testeo de BD mediante OLE                                                                     *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/

using NUnit.Framework;
using XDatabase;

namespace XDatabaseTests.OleDb
{
    public class OleDbTests
    {
        [Test]
        public void TestOleDbConnectionCannotBeEstablished()
        {
            const string connectionString = "Destino?";
            var xQuery = new XQueryOleDb(connectionString);
            Assert.IsFalse(xQuery.TestConnection());
        }

        [Test]
        public void TestOleDbInstanceTypeEqualsToOleDb()
        {
            var xQuery = new XQueryOleDb();
            Assert.AreEqual(typeof(XQueryOleDb), xQuery.GetType());
        }
    }
}
