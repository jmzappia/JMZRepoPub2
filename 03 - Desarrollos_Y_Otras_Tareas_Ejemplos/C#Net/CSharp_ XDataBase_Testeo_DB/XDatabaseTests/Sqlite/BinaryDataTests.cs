/*************************************************************************************************************
* Programa: BinaryDataTests.cs                                                                               *
**************************************************************************************************************
* Descripción: Testeo de BD                                                                                  *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 25/06/2018                                                                                    *
*************************************************************************************************************/


using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using XDatabase;

namespace XDatabaseTests.Sqlite
{
    public class BinaryDataTests
    {
        [Test]
        public void TestInsertBinaryDataIntoCell()
        {
            const string sqlCreateTable = "create table test (bin blob);";
            const string sqlInsertBin = "insert into test (bin) values (@bin);";
            var binData = new byte[] { 1,0,1,1,0,1,1,0 };
            
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            xQuery.BeginTransaction();
            xQuery.Create(sqlCreateTable);
            Assert.IsTrue(xQuery.InsertBinaryIntoCell(binData, sqlInsertBin, "@bin"));
        }

        [Test]
        public void TestInsertFileIntoCell()
        {
            const string sqlCreateTable = "create table test (bin blob);";
            const string sqlInsertFile = "insert into test (bin) values (@bin);";
            var file = Assembly.GetExecutingAssembly().Location;

            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            xQuery.BeginTransaction();
            xQuery.Create(sqlCreateTable);
            Assert.IsTrue(xQuery.InsertFileIntoCell(file, sqlInsertFile, "@bin"));
        }

        [Test]
        public void TestSelectBinaryDataFromCell()
        {
            const string sqlCreateTable = "create table test (bin blob);";
            const string sqlInsertBin = "insert into test (bin) values (@bin);";
            var binData = new byte[] { 1, 0, 1, 1, 0, 1, 1, 0 };

            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            xQuery.BeginTransaction();
            xQuery.Create(sqlCreateTable);
            xQuery.InsertBinaryIntoCell(binData, sqlInsertBin, "@bin");
            var result = xQuery.SelectCellAs<byte[]>("select bin from test");
            Assert.AreEqual(binData, result);
        }

        [Test]
        public void TestSelectBinaryDataFromCellAsImage()
        {
            const string sqlCreateTable = "create table test (bin blob);";
            const string sqlInsertImage = "insert into test (bin) values (@bin);";
            const string sqlSelectImage = "select * from test;";
            const int imageDimension = 100;
            var image = new Bitmap(imageDimension, imageDimension);
            byte[] binary;

            using (var g = Graphics.FromImage(image))
            {
                g.Clear(Color.Gold);
            }

            using (var memory = new MemoryStream())
            {
                image.Save(memory, ImageFormat.Png);
                binary = memory.ToArray();
            }

            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            xQuery.BeginTransaction();
            xQuery.Create(sqlCreateTable);
            xQuery.InsertBinaryIntoCell(binary, sqlInsertImage, "@bin");
            var retrivedImage = xQuery.SelectBinaryAsImage(sqlSelectImage);
            Assert.AreEqual(100, retrivedImage.Size.Width);
        }

        [Test]
        public void TestSelectBinaryDataFromCellAndSaveToFile()
        {
            const string sqlCreateTable = "create table test (bin blob);";
            const string sqlInsertImage = "insert into test (bin) values (@bin);";
            const string sqlSelectImage = "select bin from test limit 1;";
            const string fileName = "image.png";
            const int imageDimension = 100;
            var image = new Bitmap(imageDimension, imageDimension);
            byte[] binary;

            using (var g = Graphics.FromImage(image))
            {
                g.Clear(Color.Gold);
            }

            using (var memory = new MemoryStream())
            {
                image.Save(memory, ImageFormat.Png);
                binary = memory.ToArray();
            }

            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            xQuery.BeginTransaction();
            xQuery.Create(sqlCreateTable);
            xQuery.InsertBinaryIntoCell(binary, sqlInsertImage, "@bin");
            File.Delete(fileName);
            var result = xQuery.SelectBinaryAndSave(fileName, sqlSelectImage);
            Assert.IsTrue(result);
        }
    }
}
