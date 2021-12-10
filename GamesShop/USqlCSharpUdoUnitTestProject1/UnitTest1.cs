using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using Microsoft.Analytics.UnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GamesShop;
using GamesShop.Controllers;
using System.Web.Mvc;

namespace USqlCSharpUdoUnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		public UnitTest1()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestMethod]
		public void TestMethod1()
		{
			TestingCodeController objTestingCodeController = new TestingCodeController();
			int x = 5, y = 2;
			int result = objTestingCodeController.Test2(x, y);
			Assert.AreEqual(7, result);
		}
		[TestMethod]
		public void TestMethod2()
		{
			TestingCodeController objTestingCodeController = new TestingCodeController();
			int x = 5, y = 2;
			int result = objTestingCodeController.Test3(x, y);
			Assert.AreEqual(3, result);
		}
		[TestMethod]
		public void TestMethod3()
		{
			TestingCodeController objTestingCodeController = new TestingCodeController();
			int x = 5, y = 2;
			int result = objTestingCodeController.Test4(x, y);
			Assert.AreEqual(35, result);
		}
		[TestMethod]
		public void Index()
		{
			HomeController controller = new HomeController();

			ViewResult result = controller.Index() as ViewResult;

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void About()
		{
			HomeController controller = new HomeController();

			ViewResult result = controller.About() as ViewResult;

			Assert.AreEqual("Your application description page.", result.ViewBag.Message);
		}

		[TestMethod]
		public void Contact()
		{
			HomeController controller = new HomeController();

			ViewResult result = controller.Contact() as ViewResult;

			Assert.IsNotNull(result);
		}
		[TestMethod]
		public void Info()
		{
			ManagerController controller = new ManagerController();

			ViewResult result = controller.Products() as ViewResult;

			Assert.IsNull(result);
		}
	}
}
