
using System;
using NUnit.Framework;
using Xclass.Database;
using MySql.Data.MySqlClient;

namespace XclassTests.Database
{
    [TestFixture]
    public class MySqlQueryTests
    {
        [Test(Description = "")]
        public void Test_IamTooLazy()
        {
            MySqlQuery sqlite = new MySqlQuery();
            Assert.Fail("I'm too lazy to write unit tests. I'll do it later. Really!");
        }
    }
}
