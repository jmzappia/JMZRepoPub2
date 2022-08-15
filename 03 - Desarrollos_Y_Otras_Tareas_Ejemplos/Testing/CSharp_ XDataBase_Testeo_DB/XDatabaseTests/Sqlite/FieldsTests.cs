/*************************************************************************************************************
* Programa: FieldsTests.cs                                                                                   *
**************************************************************************************************************
* Descripción: Testeo de BD                                                                                  *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/


using System;
using NUnit.Framework;
using XDatabase;

namespace XDatabaseTests.Sqlite
{
    public class FieldsTests
    {
        [Test]
        public void TestTimeoutCanBeChanges()
        {
            var timeout = (int)TimeSpan.FromSeconds(10).TotalMilliseconds;
            var xQuery = new XQuerySqlite {Timeout = timeout};
            Assert.AreEqual(timeout, xQuery.Timeout);
        }

        [Test]
        public void TestTimeoutCannotBeSetToZero()
        {
            var xQuery = new XQuerySqlite();
            var defaultTimeout = xQuery.Timeout;
            xQuery.Timeout = 0;
            Assert.AreEqual(defaultTimeout, xQuery.Timeout);
        }
    }
}
