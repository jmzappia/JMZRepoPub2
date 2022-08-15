/*************************************************************************************************************
* Programa: MySqlTest.cs                                                                                     *
**************************************************************************************************************
* Descripción: Testeo de BD MySQL                                                                            *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/

using NUnit.Framework;
using XDatabase;

namespace XDatabaseTests.MySql
{
    public class MySqlTests
    {
        [Test]
        public void TestMySqlConnectionCannotBeEstablished()
        {
            const string connectionString = "Source?";
            var xQuery = new XQueryMySql(connectionString);
            Assert.IsFalse(xQuery.TestConnection());
        }

        [Test]
        public void TestMySqlInstanceTypeEqualsToMySql()
        {
            var xQuery = new XQueryMySql();
            Assert.AreEqual(typeof(XQueryMySql), xQuery.GetType());
        }
    }
}
