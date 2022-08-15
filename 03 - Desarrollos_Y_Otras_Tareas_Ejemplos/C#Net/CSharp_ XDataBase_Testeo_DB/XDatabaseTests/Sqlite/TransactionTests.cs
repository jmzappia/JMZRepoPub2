/*************************************************************************************************************
* Programa: TransactionTests.cs                                                                             *
**************************************************************************************************************
* Descripción: Testeo de BD                                                                                  *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/


using NUnit.Framework;
using XDatabase;

namespace XDatabaseTests.Sqlite
{
    public class TransactionTests
    {
        [Test]
        public void TestTransactionFailsIfNoConnectionSpecified()
        {
            var xQuery = new XQuerySqlite();
            Assert.IsFalse(xQuery.BeginTransaction());
            Assert.IsNotNull(xQuery.LastErrorMessage);
        }

        [Test]
        public void TestCoomitTransactionFailsIfWasNotStarted()
        {
            var xQuery = new XQuerySqlite();
            Assert.IsFalse(xQuery.CommitTransaction());
        }

        [Test]
        public void TestConnectionIsActiveAfterBeginTransaction()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            xQuery.BeginTransaction();
            Assert.IsTrue(xQuery.IsConnectionActive);
        }

        [Test]
        public void TestConnectionIsClosedAfterCommit()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            xQuery.BeginTransaction();
            xQuery.CommitTransaction();
            Assert.IsFalse(xQuery.IsConnectionActive);
        }

        [Test]
        public void TestConnectionIsClosedAfterRollback()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            xQuery.BeginTransaction();
            xQuery.RollbackTransaction();
            Assert.IsFalse(xQuery.IsConnectionActive);
        }

        [Test]
        public void TestTransactionFlagIsBeingSet()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            xQuery.BeginTransaction();
            Assert.True(xQuery.IsInTransactionMode);
        }

        [Test]
        public void TestConnectionIsNotBeingClosedIfKeepOpenWhenCommit()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString)
            {
                KeepConnectionOpen = true
            };
            xQuery.BeginTransaction();
            xQuery.CommitTransaction();
            Assert.IsTrue(xQuery.IsConnectionActive);
        }

        [Test]
        public void TestConnectionIsNotBeingClosedIfKeepOpenWhenRollback()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString)
            {
                KeepConnectionOpen = true
            };
            xQuery.BeginTransaction();
            xQuery.RollbackTransaction();
            Assert.IsTrue(xQuery.IsConnectionActive);
        }
    }
}
