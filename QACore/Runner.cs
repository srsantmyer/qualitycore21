using OpenQA.Selenium;
using System;
using Models;
// using Interfaces;
using System.Data;
using System.Collections.Generic;

namespace QaCore
{
    public class Runner
    {
        WebDriverUtil driverUtil = new WebDriverUtil();
        StepActions stepActions = new StepActions();

        RunnerArguments arguments = null;
        IWebDriver webDriver = null;
        // IDataAccess dataAccess = null;
        string _valueCopy = "";
        Dictionary<string, string> _dict = new Dictionary<string, string>();

        DataSet ds = null;


        public Runner(RunnerArguments args)
        {
            arguments = args;
            webDriver = driverUtil.GetWebDriver(arguments.DriverType);
            stepActions = new StepActions(webDriver);
            switch(args.Source)
            {
                //case DatasourceType.Excel:
                //    dataAccess = new SpreadsheetDataAccess(args);
                //    break;
                case DatasourceType.SQLServer:
                    break;
                default:
                    break;
            }
        }


        //public void RunDataSet()
        //{
        //    ds = dataAccess.GetDataSet(arguments);
        //    foreach (DataTable dt in ds.Tables)
        //    {
        //        // if tablename = "Instructions" then skip
        //        // if tablename starts with "#" then skip
        //        if (dt.TableName != "Instructions" && !dt.TableName.StartsWith("#"))
        //        {
        //            RunDataTable(dt);
        //        }
        //    }
        //}

        //public void RunDataTable(DataTable dt)
        //{
        //    foreach (DataRow r in dt.Rows)
        //    {
        //        var v = ProcessRow(MapRowToStep(r));
        //        dataAccess.CreateLogRow(v);
        //        if (!v.Pass) {
        //            break;
        //        }
        //        //dataAccess.CreateLogRow(ProcessRow(MapRowToStep(r)));
        //    }
        //}

        /// <summary>
        /// map a data row to a step object
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        private TestStep MapRowToStep(DataRow r)
        {
            TestStep s = new TestStep()
            {
                Action = r["Action"].ToString(),
                ActionValue = r["ActionValue"].ToString(),
                Element = r["Element"].ToString(),
                ExpectedResult = r["ExpectedResult"].ToString(),
                FileName = arguments.FileName,
                IdBy = r["IdBy"].ToString(),
                IdValue = r["IdValue"].ToString()
            };
            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public StepResult ProcessRow(TestStep step)
        {
            StepResult r = new StepResult();

            switch (step.Action.ToLower())
            {
                case "clear":
                    r = stepActions.ClearAction(step);
                    break;
                case "click":
                    r = stepActions.ClickAction(step);
                    break;
                case "clicklocation":
                    r = stepActions.ClickLocationAction(step);
                    break;
                case "close":
                    r = stepActions.CloseAction(step);
                    break;
                case "dropdownselectbytext":
                    r = stepActions.DropdownSelectByTextAction(step);
                    break;
                case "execute":
                    throw new NotImplementedException();
                    // r = ExecuteAnotherTable(r, step.Action, step.ActionValue);
                    // break;
                case "find":
                    r = stepActions.FindAction(step);
                    break;
                case "findnot":
                    r = stepActions.FindNotAction(step);
                    break;
                case "findsafe":
                    r = stepActions.FindSafeAction(step);
                    break;
                case "findtextonpage":
                    r = stepActions.FindTextOnPage(step);
                    break;
                case "isnotvisible":
                    r = stepActions.IsNotVisible(step);
                    break;
                case "isvisible":
                    r = stepActions.IsVisible(step);
                    break;
                case "gettitle":
                    r = stepActions.GetTitleAction(step);
                    break;
                case "navigate":
                    r = stepActions.NavigateAction(step);
                    break;
                case "nexttab":
                    r = stepActions.NextTab(step);
                    break;
                case "read":
                    r = stepActions.ReadAction(step);
                    break;
                case "screenshot":
                    r = stepActions.ScreenshotAction(step);
                    break;
                case "sendkey":
                    r = stepActions.SendKeyAction(step);
                    break;
                case "sendtext":
                    r = stepActions.SendTextAction(step);
                    break;
                case "valuecopy":
                case "valuesave":
                    _valueCopy = stepActions.CopyValueAction(step).Note;
                    break;
                case "valuepaste":
                    step.ActionValue = _valueCopy;
                    r = stepActions.SendTextAction(step);
                    break;
                case "wait":
                    r = stepActions.Wait(step);
                    break;
                case "waitforpreloader":
                    r = stepActions.WaitForPreLoader(step);
                    break;
                case "waituntilvisible":
                    r = stepActions.WaitUntilVisible(step);
                    break;
                case "dictionarycopy":
                    _dict = stepActions.DictionaryCopy(step);
                    break;
                default:
                    LoggerUtil.Log(new NotImplementedException(), LogLevel.Error);
                    break;
            }
            return r;
        }

        public List<IWebElement> GetIt(string by, string selector) {
            return stepActions.GetElements(new TestStep() { IdBy = by, IdValue = selector });
        }

        /// <summary>
        /// Ideally this would be a step action, but it needs to act on the dataset
        /// </summary>
        /// <param name="r"></param>
        /// <param name="action"></param>
        /// <param name="actionValue"></param>
        /// <returns></returns>
        //private StepResult ExecuteAnotherTable(StepResult r, string action, string actionValue)
        //{
        //    r.Step = string.Format("{0}, {1}", action, actionValue);
        //    try
        //    {
        //        RunDataTable(ds.Tables[actionValue]);
        //        r.Pass = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        r.Step = string.Format("{0}, {1}", action, ex.Message);
        //    }
        //    return r;
        //}

        /// <summary>
        /// close and quit the webdriver;
        /// </summary>
        public void CloseDriver()
        {
            try
            {

                webDriver.Close();
                webDriver.Quit();
            }
            catch (Exception ex)
            {
                LoggerUtil.Log(ex, LogLevel.Trace);
            }
        }
    }
}
