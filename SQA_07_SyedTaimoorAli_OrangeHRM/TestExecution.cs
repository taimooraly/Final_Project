using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Data;

namespace SQA_07_SyedTaimoorAli_OrangeHRM
{
    [TestClass]
    public class TestExecution : BasePage
    {
        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            LogReport("TestReport");
        }
        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            extentReports.Flush();
        }
        [TestInitialize]
        public void TestInit()
        {
            SeleniumInitialization("Chrome");
            ParentTest = extentReports.CreateTest(TestContext.TestName);
        }
        [TestCleanup]
        public void TestClose()
        {
            SeleniumClose();
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "Login", DataAccessMethod.Sequential)]
        public void Login()
        {
            ChildTest = ParentTest.CreateNode("Login");
            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            string gotourl = TestContext.DataRow["goto"].ToString();
            LoginPage.Login(url, user, pass, gotourl);
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "TestCase01.xml", "Users", DataAccessMethod.Sequential)]
        public void Test_Case_01()
        {
            ChildTest = ParentTest.CreateNode("Login");
            //login
            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            string gotourl = TestContext.DataRow["goto"].ToString();
            LoginPage.Login(url, user, pass, gotourl);
            ChildTest = ParentTest.CreateNode("Create Users");
            //create user
            string Key = TestContext.DataRow["Key"].ToString();
            string Key1 = TestContext.DataRow["Key1"].ToString();
            string Key2 = TestContext.DataRow["Key2"].ToString();
            string Key3 = TestContext.DataRow["Key3"].ToString();
            string Key4 = TestContext.DataRow["Key4"].ToString();
            string Key5 = TestContext.DataRow["Key5"].ToString();
            TestCaseOne.CreateUsers(Key, Key1, Key2, Key3, Key4, Key5);
            ChildTest = ParentTest.CreateNode("Update Users");
            //update users
            string searchname = TestContext.DataRow["searchname"].ToString();
            string updatedname = TestContext.DataRow["updatedname"].ToString();
            TestCaseOne.UpdateUser(searchname, updatedname);
            ChildTest = ParentTest.CreateNode("Delete Users");
            //delete users
            string deletename = TestContext.DataRow["deletename"].ToString();
            TestCaseOne.DeleteUser(deletename);
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "TestCase02.xml", "PIM", DataAccessMethod.Sequential)]
        public void Test_Case_02()
        {
            ChildTest = ParentTest.CreateNode("Login");
            //login
            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            string gotourl = TestContext.DataRow["goto"].ToString();
            LoginPage.Login(url, user, pass, gotourl);
            ChildTest = ParentTest.CreateNode("PIM");
            string firstname = TestContext.DataRow["firstname"].ToString();
            string middlename = TestContext.DataRow["middlename"].ToString();
            string lastname = TestContext.DataRow["lastname"].ToString();
            string ID = TestContext.DataRow["ID"].ToString();
            string searchId = TestContext.DataRow["searchId"].ToString();
            string nickname = TestContext.DataRow["nickname"].ToString();
            TestCaseTwo.PIM(firstname, middlename, lastname, ID, searchId, nickname);
        }
    }
}
