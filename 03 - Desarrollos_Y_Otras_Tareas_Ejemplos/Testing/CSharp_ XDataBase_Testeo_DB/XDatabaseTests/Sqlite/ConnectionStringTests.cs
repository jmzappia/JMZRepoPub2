/*************************************************************************************************************
* Programa: ConnetionStringTest.cs                                                                           *
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
    public class ConnectionStringTests
    {
        [Test]
        public void TestSqliteConnectionCanBeEstablished()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            Assert.IsTrue(xQuery.TestConnection());
        }

        [Test]
        public void TestSqliteConnectionCannotBeEstablished()
        {
            string connectionString = $"Data Source={Guid.NewGuid()};FailIfMissing=true;";
            var xQuery = new XQuerySqlite(connectionString);
            Assert.IsFalse(xQuery.TestConnection());
        }

        [Test]
        public void TestNoErrorWhileCheckingTheConnectionWithNull()
        {
            var xQuery = new XQuerySqlite();
            Assert.IsFalse(xQuery.TestConnection());
        }

        [Test]
        public void TestNoActiveConnectionAfterDefiningConnectionString()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            Assert.IsFalse(xQuery.IsConnectionActive);
        }

        [Test]
        public void TestConnectionIsBeingClosedByChangingKeepConnectionOpen()
        {
            const string select = "select 123;";
            var xQuery = new XQuerySqlite()
            {
                ConnectionString = SetUp.SqliteConnectionString,
                KeepConnectionOpen = true
            };
            xQuery.SelectCellAs<long>(select);
            xQuery.KeepConnectionOpen = false;
            Assert.IsFalse(xQuery.IsConnectionActive);
        }
    }
}
