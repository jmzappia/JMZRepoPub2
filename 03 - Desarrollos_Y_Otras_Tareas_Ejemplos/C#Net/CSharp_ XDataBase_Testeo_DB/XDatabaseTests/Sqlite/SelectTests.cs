﻿/*************************************************************************************************************
* Programa: SelectTests.cs                                                                                   *
**************************************************************************************************************
* Descripción: Testeo de BD                                                                                  *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/


using System;
using System.Data;
using NUnit.Framework;
using XDatabase;

namespace XDatabaseTests.Sqlite
{
    public class SelectTests
    {
        [Test]
        public void TestSelectTable()
        {
            const string sqlSelectTable = "select 1, 2, 3 union select 4, 5, 6;";
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            var result = xQuery.SelectTable(sqlSelectTable);
            Assert.AreEqual(2*3, result.Rows.Count*result.Columns.Count);
        }

        [Test]
        public void TestSelectRow()
        {
            const string sqlSelectRow = "select 1, 'value', 3.3;";
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            var result = xQuery.SelectRow(sqlSelectRow);
            Assert.AreEqual(3, result.ItemArray.Length);
        }

        [Test]
        public void TestSelectColumn()
        {
            const string sqlSelectColumn = "select 1 union select 2 union select 3;";
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            var result = xQuery.SelectColumn(sqlSelectColumn);
            Assert.AreEqual(3, result.Table.Rows.Count);
        }

        [Test]
        public void TestArithmeticOperationWithSelectCell()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            Assert.AreEqual(30, xQuery.SelectCellAs<long>("select 10+20;"));
        }

        [Test]
        public void TestArgumentsCanBeSpecifiedWithinSelectTable()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            const string value = "asd";
            var result = xQuery.SelectTable("select @a;", new XParameter("@a", value))
                .Rows[0].ItemArray[0];
            Assert.AreEqual(result, value);
        }

        [Test]
        public void TestSelectCellCanReturnStringDataType()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            var result = xQuery.SelectCellAs<string>("select 'asd';");
            Assert.AreEqual("asd", result);
        }

        [Test]
        public void TestSelectCellCanReturnLongDataType()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            var result = xQuery.SelectCellAs<long>("select 100;");
            Assert.AreEqual(100L, result);
        }

        [Test]
        public void TestSelectCellCanReturnDoubleDataType()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            var result = xQuery.SelectCellAs<double>("select 1.1;");
            Assert.AreEqual(1.1d, result);
        }

        [Test]
        public void TestSelectCellReturnsDefaultValueOnError()
        {
            const string defValue = "default";
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            var result = xQuery.SelectCellAs("select 1.1;", defValue);
            Assert.AreEqual(defValue, result);
        }

        [Test]
        public void TestSelectCellReturnsValueIfNoErrors()
        {
            const string defValue = "default";
            const string nonDefValue = "non default";
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            var result = xQuery.SelectCellAs($"select '{nonDefValue}';", defValue);
            Assert.AreEqual(nonDefValue, result);
        }

        [Test]
        public void TestSelectCellThrowsFormatException()
        {
            const string sqlSelect = "select 1;";
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            Assert.Throws(Is.TypeOf<FormatException>(), delegate
            {
                xQuery.SelectCellAs<string>(sqlSelect);
            });
        }

        [Test]
        public void TestSelectCellThrowsDataException()
        {
            const string sqlSelect = "select 1, 2, 3;";
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            Assert.Throws(Is.TypeOf<DataException>(), delegate
            {
                xQuery.SelectCellAs<long>(sqlSelect);
            });
        }

        [Test]
        public void TestSelectCellThrowsDataExceptionOnEmptyResult()
        {
            const string sqlSelect = "select;";
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            Assert.Throws(Is.TypeOf<DataException>(), delegate
            {
                xQuery.SelectCellAs<long>(sqlSelect);
            });
        }

        [Test]
        public void TestErrorIsLogged()
        {
            const string sqlSelect = "select 1, 2, 3;";
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            xQuery.OnError += XQuery_OnError;
            try
            {
                xQuery.SelectCellAs<long>(sqlSelect);
            }
            catch (Exception)
            {
                // ignored
            }

            Assert.IsNotEmpty(xQuery.LastErrorMessage);
        }

        [Test]
        public void TestConnectionIsOpenAfterSelect()
        {
            const string sqlSelect = "select 123;";
            var xQuery = new XQuerySqlite()
            {
                ConnectionString = SetUp.SqliteConnectionString,
                KeepConnectionOpen = true
            };
            xQuery.SelectCellAs<long>(sqlSelect);
            Assert.IsTrue(xQuery.IsConnectionActive);
        }

        private void XQuery_OnError(string pErrorMessage)
        {
            /*Vacío*/
        }
    }
}
