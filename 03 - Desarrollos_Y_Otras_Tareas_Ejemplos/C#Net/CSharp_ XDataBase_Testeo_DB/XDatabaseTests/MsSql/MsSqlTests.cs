/*************************************************************************************************************
* Programa: MsSqlTest.cs                                                                                     *
**************************************************************************************************************
* Descripción: Testeo de BD MS SQL                                                                           *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/

using NUnit.Framework;
using XDatabase;

namespace XDatabaseTests.MsSql
{
    public class MsSqlTests
    {
        [Test]
        public void TestMsSqlConnectionCannotBeEstablished()
        {
            const string connectionString = "Source?";
            var xQuery = new XQueryMySql(connectionString);
            Assert.IsFalse(xQuery.TestConnection());
        }

        [Test]
        public void TestMsSqlInstanceTypeEqualsToMsSql()
        {
            var xQuery = new XQueryMsSql();
            Assert.AreEqual(typeof(XQueryMsSql), xQuery.GetType());
        }
    }
}
