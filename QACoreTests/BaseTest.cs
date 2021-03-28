#define IsTest
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
//using HpaElements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using OpenQA.Selenium;
using QaCore;
//using static HpaDesktopTests.Variables.Logins;

namespace QACoreTests {
    [TestClass]
    public abstract class BaseTest {
        private static RunnerArguments args = new RunnerArguments() {
            ConnectionString = "",
            DriverType = DriverType.Chrome,
            FileName = "",
            ResultsFileName = "",
            ResultsSheetName = "",
            SheetName = "",
            Source = DatasourceType.SQLServer
        };
        public static Runner runner;// = new Runner(args);

        // properties
        //QaCore.WebDriverUtil util = new WebDriverUtil();
        //public IWebDriver webDriver;
        //public StepActions stepActions;


        //  constructor
        public BaseTest() {
            //webDriver = util.GetWebDriver(DriverType.Chrome);
            //stepActions = new StepActions(webDriver);
        }

        // methods
        public void RunStep(TestStep tStep) {
            var tResult = runner.ProcessRow(tStep);
            if (!tResult.Pass) {
                throw new Exception(string.Format("Test Step failed: Action = {0}, Element = {1}", tStep.Action, tStep.IdValue));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        //public UserAccount GetUserAccount(string key) {
        //    return new UserAccount() {
        //        EmailAddress = System.Configuration.ConfigurationManager.AppSettings["email" + key].ToString(),
        //        Password = System.Configuration.ConfigurationManager.AppSettings["password" + key].ToString(),
        //        Username = System.Configuration.ConfigurationManager.AppSettings["username" + key].ToString()
        //    };
        //}

        /// <summary>
        /// uses action GetTitle to compare result to title variable
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool IsTitle(string title) {
            var t = runner.ProcessRow(new TestStep() { Action = ActionNames.GetTitle, ActionValue = title });
            return t.Pass;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetUrl() {
            var url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
            if (string.IsNullOrWhiteSpace(url)) {
                url = "https://qc.highlandhub.com";
            }
            return url;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="action"></param>
        /// <param name="actionValue"></param>
        /// <param name="expectedValue"></param>
        /// <returns></returns>
        public StepResult DoIt(BaseElement element, string action, string actionValue, string expectedValue) {
            // in case we need to do something later, set the result to r
            var r = runner.ProcessRow(new TestStep(element.IdBy, element.IdValue, action, actionValue, expectedValue));
            return r;
        }

        /// <summary>
        /// overload - just the element and action
        /// </summary>
        /// <param name="element"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public StepResult DoIt(BaseElement element, string action) {
            return DoIt(element, action, "", "");
        }

        /// <summary>
        /// overload - just the element, action and custom value like for send text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="action"></param>
        /// <param name="actionValue"></param>
        /// <returns></returns>
        public StepResult DoIt(BaseElement element, string action, string actionValue) {
            return DoIt(element, action, actionValue, "");
        }

        /// <summary>
        /// Find this text, error if not
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public StepResult FindIt(string searchText) {
            return DoIt(new BaseElement(), ActionNames.FindTextOnPage, searchText);
        }

        /// <summary>
        /// multi step find element, clear element and send text
        /// </summary>
        /// <param name="e"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public StepResult FindClearSend(BaseElement e, string v) {
            var f = DoIt(e, ActionNames.Find);
            if (f.Pass) {
                f = DoIt(e, ActionNames.Clear);
                if (f.Pass) {
                    f = DoIt(e, ActionNames.SendText, v);
                }
            }
            return f;
        }

        public List<IWebElement> GetIt(BaseElement selector) {
            return runner.GetIt(selector.IdBy, selector.IdValue);
        }

        public void Navigate(string url) {
            runner.ProcessRow(new Models.TestStep("", "", ActionNames.Navigate, url, ""));
        }

        /// <summary>
        /// Wait for the default preloader to go away
        /// </summary>
        public void WaitForPreloader() {
            DoIt(new BaseElement() { IdBy = "", IdValue = "" }, ActionNames.WaitForPreLoader, "", "");
            Wait(2);
        }

        public void Wait(int seconds) {
            runner.ProcessRow(new TestStep("", "", ActionNames.Wait, seconds.ToString(), ""));
        }

        public void ScreenShot(string filename) {
            runner.ProcessRow(new TestStep(ActionNames.ScreenShot, filename));
        }

        public void NextTab() {
            runner.ProcessRow(new TestStep(ActionNames.NextTab));
        }

        [TestInitialize]
        public void Setup() {
            runner = new Runner(args);
            //begin transaction
        }

        [TestCleanup]
        public void CleanUp() {
            runner.CloseDriver();
            //webDriver.Quit();
        }
    }
}