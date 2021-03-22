using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using Models;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Diagnostics.Eventing.Reader;
using NLog;
using System.IO;

namespace QaCore
{
    public class StepActions
    {
        IWebDriver _driver;

        public StepActions()
        {
        }

        public StepActions(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Clear the element located by this step
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public StepResult ClearAction(TestStep step)
        {
            StepResult r = new StepResult();
            try
            {
                var e = GetBy(step.IdBy, step.IdValue);
                e.Clear();
                r = Pass(step);
            }
            catch (Exception ex)
            {
                r = Fail(step, ex);
            }
            return r;
        }

        /// <summary>
        /// Click on the element located by this step
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public StepResult ClickAction(TestStep step)
        {
            StepResult r = new StepResult();
            try
            {
                var e = GetBy(step.IdBy, step.IdValue);
                e.Click();
                r = Pass(step);
            }
            catch (Exception ex)
            {
                r = Fail(step, ex);
            }
            return r;
        }

        /// <summary>
        /// Find the element located by this step and then click RIGHT THERE
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public StepResult ClickLocationAction(TestStep step) {
            StepResult r = new StepResult();
            try {
                Actions actions = new Actions(_driver);
                actions.MoveToElement(GetBy(step.IdBy, step.IdValue));
                actions.Click();
                actions.Build().Perform();
                r = Pass(step);
            }
            catch (Exception ex) {
                r = Fail(step, ex);
            }
            return r;
        }

        public StepResult CloseAction(TestStep step)
        {
            StepResult r = new StepResult();
            try
            {
                _driver.Close();
                r = Pass(step);
            }
            catch (Exception ex)
            {
                r = Fail(step, ex);
            }
            return r;
        }

        public StepResult CopyValueAction(TestStep step)
        {
            StepResult r = new StepResult();
            try
            {
                var e = GetBy(step.IdBy, step.IdValue);
                r = Pass(step);
                r.Note = e.Text;
            }
            catch (Exception ex)
            {
                r = Fail(step, ex);
            }
            return r;
        }

        /// <summary>
        /// select a single dropdown list item by TEXT =
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public StepResult DropdownSelectByTextAction(TestStep step)
        {
            StepResult r = new StepResult();
            try
            {
                var e = GetBy(step.IdBy, step.IdValue);
                var selectElement = new SelectElement(e);
                selectElement.SelectByText(step.ActionValue);
                r = Pass(step);
            }
            catch(Exception ex)
            {
                r = Fail(step, ex);
            }
            return r;
        }

        /// <summary>
        /// select a single dropdown list item by VALUE = 
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public StepResult DropdownSelectByValueAction(TestStep step)
        {
            StepResult r = new StepResult();
            try
            {
                var e = GetBy(step.IdBy, step.IdValue);
                var selectElement = new SelectElement(e);
                selectElement.SelectByValue(step.ActionValue);

                r = Pass(step);
            }
            catch(Exception ex)
            {
                r = Fail(step, ex);
            }
            return r;
        }

        /// <summary>
        /// Find the element located by this step
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public StepResult FindAction(TestStep step)
        {
            StepResult r = new StepResult();
            try {
                Actions actions = new Actions(_driver);
                actions.MoveToElement(GetBy(step.IdBy, step.IdValue));
                actions.Build().Perform();
                r = Pass(step);
            }
            catch(Exception ex) {
                r = Fail(step, ex);
            }
            return r;
        }

        public StepResult NextTab(TestStep step) {
            StepResult r = new StepResult();
            try {
                _driver.SwitchTo().Window(_driver.WindowHandles.Last());
                //var e = _driver.FindElement(By.TagName("html"));
                //e.SendKeys(string.Format("{0}{1}", Keys.Control, Keys.NumberPad2));
                r = Pass(step);
            }
            catch(Exception ex) {
                r = Fail(step, ex);
            }
            return r;
        }

        /// <summary>
        /// Find the element located by this step
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public StepResult FindNotAction(TestStep step) {
            StepResult r = new StepResult();
            try {
                Actions actions = new Actions(_driver);
                actions.MoveToElement(GetBy(step.IdBy, step.IdValue));
                actions.Build().Perform();
                r = Fail(step, new Exception($"Element {step.IdValue} was found when we were not expecting it. ^CUSTOM_EXCEPTION^"));
            }
            catch (NoSuchElementException) {
                r = Pass(step);
            }
            catch (ElementNotVisibleException) {
                r = Pass(step);
            }
            catch (Exception ex) {
                if (!ex.Message.Contains("^CUSTOM_EXCEPTION^")) {
                    r = Fail(step, ex);
                }
            }
            return r;
        }

        /// <summary>
        /// Find action that does not throw error on No Such Element or Element Not Visible
        /// </summary>
        /// <param name="step"></param>
        /// <returns>Pass = true if found, Pass = false if not found</returns>
        public StepResult FindSafeAction(TestStep step) {
            StepResult r = new StepResult();
            try {
                Actions actions = new Actions(_driver);
                actions.MoveToElement(GetBy(step.IdBy, step.IdValue));
                actions.Build().Perform();
                r = Pass(step);
            }
            catch (NoSuchElementException) {
                r = Fail(step);
            }
            catch (ElementNotVisibleException) {
                r = Fail(step);
            }
            catch (Exception ex) {
                r = Fail(step, ex);
            }
            return r;
        }

        public StepResult IsNotVisible(TestStep step) {
            StepResult r = new StepResult();
            try {
                var e = GetBy(step.IdBy, step.IdValue).Displayed;
                if (!e) {
                    r = Pass(step);
                }
            }
            catch (Exception ex) {
                r = Fail(step, ex);
            }
            return r;
        }

        public StepResult IsVisible(TestStep step) {
            StepResult r = new StepResult();
            try {
                var e = GetBy(step.IdBy, step.IdValue).Displayed;
                if (e) {
                    r = Pass(step);
                }
            }
            catch (Exception ex) {
                r = Fail(step, ex);
            }
            return r;
        }

        /// <summary>
        /// Match the title of the current web page with the step value
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public StepResult GetTitleAction(TestStep step)
        {
            string v = "";
            StepResult r = new StepResult();
            try
            {
                string t = _driver.Title.ToLower();
                v = t;
                if (t == step.ActionValue.ToLower())
                {
                    r = Pass(step);
                }
                else
                {
                    r = Fail(step);
                }
            }
            catch (Exception ex)
            {
                r = Fail(step, ex);
            }
            r.Note = v;
            return r;
        }

        /// <summary>
        /// ItemOne|ItemTwo|ItemThree
        /// id^idValue^displayName|id2^idValue2^displayName2|etc
        /// </summary>
        /// <param name="step"></param>
        /// <returns>dictionary of idDisplayName,Value</returns>
        internal Dictionary<string, string> DictionaryCopy(TestStep step) {
            Dictionary<string, string> r = new Dictionary<string, string>();
            var vals = step.ActionValue.Split('|');
            foreach(var i in vals) {
                var item = i.Split('^');
                List<string> res = new List<string>();
                res.Add(item[2]);
                var result = CopyValueAction(new TestStep() {
                    IdBy = i[0].ToString(),
                    IdValue = i[1].ToString()
                }).Note;
                res.Add(result);
                r.Add(res[0], res[1]);
            }
            return r;
        }

        /// <summary>
        /// Navigate to a specific web page
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public StepResult NavigateAction(TestStep step)
        {
            StepResult r = new StepResult();
            try
            {
                _driver.Navigate().GoToUrl(step.ActionValue);
                r = Pass(step);
            }
            catch (Exception ex)
            {
                r = Fail(step, ex);
            }
            return r;
        }

        /// <summary>
        /// Read the text of the element located by this step
        /// </summary>
        /// <param name="step"></param>
        /// <returns>A StepResult. The READ value is in the NOTE</returns>
        public StepResult ReadAction(TestStep step)
        {
            StepResult r = new StepResult();
            try
            {
                var e = GetBy(step.IdBy, step.IdValue);
                r = Pass(step);
                if (e.TagName == "input") {
                    r.Note = e.GetAttribute("value");
                }
                else {
                    r.Note = e.Text;
                }
            }
            catch (Exception ex)
            {
                r = Fail(step, ex);
            }
            return r;
        }

        public string SaveScreenshot(string fileName)
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["ScreenshotPath"];
            if (string.IsNullOrWhiteSpace(path)) {
                path = @".\";
            }
            string r = "Unable to save file";
            if (ValidateSaveLocation(path)) {
                if (string.IsNullOrWhiteSpace(fileName)) {
                    fileName = Guid.NewGuid().ToString();
                }
                StringBuilder timeAndDate = new StringBuilder(DateTime.Now.ToString());
                timeAndDate.Replace("/", "_");
                timeAndDate.Replace(":", "_");
                timeAndDate.Append(".png");
                string imageName = timeAndDate.ToString();
                string saveAs = $"{path}\\{fileName.Replace(".xlsx", "")}";
                saveAs = $"{saveAs}_{imageName}";
                //saveAs += imageName;
                try {
                    ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(saveAs, ScreenshotImageFormat.Png);
                    r = saveAs;
                }
                catch {
                    // oh well
                }
            }
            return r;
        }

        public bool ValidateSaveLocation(string path) {            
            try {
                var ac = new DirectoryInfo(path).GetAccessControl();
                return true;
            }
            catch (UnauthorizedAccessException) {
                return true;
            }
            catch {
                return false;
            }
        }

        /// <summary>
        /// take a screenshot
        /// </summary>
        /// <param name="step"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public StepResult ScreenshotAction(TestStep step)
        {
            StepResult r = new StepResult();
            try
            {
                string saveAs = SaveScreenshot(step.FileName);
                r = Pass(step);
                r.Note = saveAs;
            }
            catch (Exception ex)
            {
                r = Fail(step, ex);
            }
            return r;
        }

        /// <summary>
        /// Send a single key to the element located by this step
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public StepResult SendKeyAction(TestStep step)
        {
            StepResult r = new StepResult();
            try
            {
                var e = GetBy(step.IdBy, step.IdValue);
                SendAKey(e, step.ActionValue);
                r = Pass(step);
            }
            catch (Exception ex)
            {
                r = Fail(step, ex);
            }
            return r;
        }

        /// <summary>
        /// Send a sequence of keystrokes to the element located by this step
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public StepResult SendTextAction(TestStep step)
        {
            StepResult r = new StepResult();
            try
            {
                var e = GetBy(step.IdBy, step.IdValue);
                e.SendKeys(step.ActionValue);
                r = Pass(step);
            }
            catch (Exception ex)
            {
                r = Fail(step, ex);
            }
            return r;
        }

        public StepResult FindTextOnPage(TestStep step)
        {
            StepResult r = new StepResult();
            try
            {
                if (_driver.PageSource.Contains(step.ActionValue))
                {
                    r = Pass(step);
                }
            }
            catch(Exception ex)
            {
                r = Fail(step, ex);
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        private StepResult Pass(TestStep step)
        {
            StepResult r = new StepResult()
            {
                Pass = true,
                Step = string.Format("{0}, {1}",step.Action, step.ActionValue)
            };
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="step"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private StepResult Fail(TestStep step, Exception ex)
        {
            SaveScreenshot(step.FileName);
            StepResult r = new StepResult()
            {
                Pass = false,
                Step = string.Format("{0}, {1}", step.Action, step.ActionValue),
                Note = (ex != null) ? ex.Message : ""
            };
            if (ex != null)
            {
                LoggerUtil.Log(ex, LogLevel.Error);
            }
            // return r;
            throw (ex);
        }

        private StepResult Fail(TestStep step) {
            SaveScreenshot(step.FileName);
            StepResult r = new StepResult() {
                Pass = false,
                Step = string.Format("{0}, {1}", step.Action, step.ActionValue),
                Note = "Item was not found"
            };
            return r;
        }

        /// <summary>
        /// Get the element identified BY and USING
        /// </summary>
        /// <param name="s"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        private IWebElement GetBy(string s, string v)
        {
            IWebElement r = null;
            switch(s.ToLower())
            {
                case "id":
                    r = _driver.FindElement(By.Id(v));
                    break;
                case "name":
                    r = _driver.FindElement(By.Name(v));
                    break;
                case "xpath":
                    r = _driver.FindElement(By.XPath(v));
                    break;
                case "cssselector":
                case "css":
                    r = _driver.FindElement(By.CssSelector(v));
                    break;
                case "linktext":
                    r = _driver.FindElement(By.LinkText(v));
                    break;
                case "partiallinktext":
                    r = _driver.FindElement(By.PartialLinkText(v));
                    break;
                case "tagname":
                case "tag":
                    r = _driver.FindElement(By.TagName(v));
                    break;
                case "classname":
                case "class":
                    r = _driver.FindElement(By.ClassName(v));
                    break;
            }
            return r;
        }

        private void SendAKey(IWebElement e, string s)
        {
            switch (s.ToLower())
            {
                case "enter":
                    e.SendKeys(Keys.Enter);
                    break;
                case "downarrow":
                    e.SendKeys(Keys.ArrowDown);
                    break;
                case "uparrow":
                    e.SendKeys(Keys.ArrowUp);
                    break;
                case "space":
                    e.SendKeys(Keys.Space);
                    break;
                case "backspace":
                    e.SendKeys(Keys.Backspace);
                    break;
                default:
                    // throw new NotImplementedException();
                    break;
            }
        }

        /// <summary>
        /// sleep for s seconds
        /// </summary>
        /// <param name="s"></param>
        public StepResult Wait(TestStep step) {
            int i = 1;
            int.TryParse(step.ActionValue, out i);
            Thread.Sleep(i * 1000);
            return Pass(step);
        }

        public StepResult WaitForPreLoader(TestStep step) {
            StepResult r = new StepResult();
            try {
                string n = "preloader";
                if (!string.IsNullOrWhiteSpace(step.ActionValue)) {
                    n = step.ActionValue;
                }
                var wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(1));
                var clickableElement = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(n)));
                r = Pass(step);
            }
            catch (Exception ex) {
                r = Fail(step, ex);
            }
            return r;
        }

        /// <summary>
        /// Wait for a maximum of one minute for the element to become visible
        /// By ID or XPATH
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public StepResult WaitUntilVisible(TestStep step) {
            StepResult r = new StepResult();
            try {
                var n = step.IdValue;
                var wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(1));
                switch (step.IdBy) {
                    case "xpath":
                        var xpe = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(n)));
                        break;
                    default:
                        var ide = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(n)));
                        break;
                }
                r = Pass(step);
            }
            catch (Exception ex) {
                r = Fail(step, ex);
            }
            return r;
        }

        public List<IWebElement> GetElements(TestStep step) {
            try {
                switch (step.IdBy.ToLower()) {
                    case "id":
                        return _driver.FindElements(By.Id(step.IdValue)).ToList();
                        
                    case "name":
                        return _driver.FindElements(By.Name(step.IdValue)).ToList();

                    case "xpath":
                        return _driver.FindElements(By.XPath(step.IdValue)).ToList();

                    case "cssselector":
                    case "css":
                        return _driver.FindElements(By.CssSelector(step.IdValue)).ToList();

                    case "linktext":
                        return _driver.FindElements(By.LinkText(step.IdValue)).ToList();

                    case "partiallinktext":
                        return _driver.FindElements(By.PartialLinkText(step.IdValue)).ToList();

                    case "tagname":
                    case "tag":
                        return _driver.FindElements(By.TagName(step.IdValue)).ToList();

                    case "classname":
                    case "class":
                        return _driver.FindElements(By.ClassName(step.IdValue)).ToList();
        
                }
                return null;
            }
            catch(Exception ex) {
                return null;
            }
        }
    }
}
