using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Odbc;

namespace PlutoSolutionsDataDrivenUnitTests
{
    [TestClass]
    public class DataSourceTest
    {
        public TestContext context { get; set; }

        [TestMethod]
        //[DeploymentItem("PlutoSolutionsDataDrivenUnitTests\\DBConnection.xlsx")]
        //[DataSource("MyExcelDataSource")]
        [DataSource(
            "System.Data.OleDb",
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DBConnection.xls",
            "Sheet1$",
            DataAccessMethod.Sequential
            )]
        public void ReadDataTest()
        {
            int A = int.Parse(context.DataRow["A"].ToString());
            int B = int.Parse(context.DataRow["B"].ToString());
            int expected = int.Parse(context.DataRow["C"].ToString());
            int actual = MathTest.Add(A, B);

            Console.WriteLine(string.Format("expected / actual : ", expected, actual));
            Assert.AreEqual(expected, actual);
        }
    }
}
