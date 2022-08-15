/*************************************************************************************************************
* Programa: InitialStateTest.cs                                                                              *
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
    public class InitialStateTests
    {
        [Test]
        public void TestInitialStateOfErrorMessageIsNull()
        {
            var xQuery = new XQuerySqlite();
            Assert.IsNull(xQuery.LastErrorMessage);
        }

        [Test]
        public void TestInitialStateOfTimeoutIs30s()
        {
            var xQuery = new XQuerySqlite();
            Assert.AreEqual(TimeSpan.FromSeconds(30).Seconds, xQuery.Timeout);
        }

        [Test]
        public void TestInitialStateOfConnectionStringIsNull()
        {
            var xQuery = new XQuerySqlite();
            Assert.IsNull(xQuery.ConnectionString);
        }

        [Test]
        public void TestInitialStateOfIsActiveConnectionIsFalse()
        {
            var xQuery = new XQuerySqlite();
            Assert.IsFalse(xQuery.IsConnectionActive);
        }

        [Test]
        public void TestInitialStateOfIsTransactionModeIsFalse()
        {
            var xQuery = new XQuerySqlite();
            Assert.IsFalse(xQuery.IsInTransactionMode);
        }

        [Test]
        public void TestKeepConnectionOpenIsFalseByDefault()
        {
            var xQuery = new XQuerySqlite();
            Assert.IsFalse(xQuery.KeepConnectionOpen);
        }

        [Test]
        public void TestSqliteInstanceTypeEqualsToSqlite()
        {
            var xQuery = new XQuerySqlite();
            Assert.AreEqual(typeof(XQuerySqlite), xQuery.GetType());
        }
    }
}
