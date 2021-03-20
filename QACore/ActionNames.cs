using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaCore {
    public static class ActionNames {
        public static string Clear = "clear";
        /// <summary>
        /// Click the element identified by IdBy and IdValue
        /// </summary>
        public static string Click = "click";
        /// <summary>
        /// Set the cursor over an element and click there
        /// </summary>
        public static string ClickLocation = "clicklocation";
        public static string Close = "close";
        public static string DropDownSelectBy = "dropdownselectbytext";
        public static string Execute = "execute";
        /// <summary>
        /// Find the element on the page by IdBy and IdValue
        /// </summary>
        public static string Find = "find";
        /// <summary>
        /// This element should NOT be found
        /// </summary>
        public static string FindNot = "findnot";
        /// <summary>
        /// true / false IS this element found?
        /// </summary>
        public static string FindSafe = "findsafe";
        /// <summary>
        /// Is the element found and visible
        /// </summary>
        public static string IsVisible = "isvisible";
        /// <summary>
        /// is the element found and NOT visible
        /// </summary>
        public static string IsNotVisible = "isnotvisible";
        public static string FindTextOnPage = "findtextonpage";
        /// <summary>
        /// Match the title of the current web page with the ActionValue
        /// </summary>
        public static string GetTitle = "gettitle";
        public static string Navigate = "navigate";
        public static string Read = "read";
        public static string ScreenShot = "screenshot";
        public static string SendKey = "sendkey";
        /// <summary>
        /// Send ActionValue text to the element identified by IdBy and IdValue
        /// </summary>
        public static string SendText = "sendtext";
        public static string ValueCopy = "valuecopy";
        public static string ValueSave = "valuesave";
        public static string ValuePaste = "valuepaste";
        public static string Wait = "wait";
        /// <summary>
        /// Wait for the preloader (spinner) to go away for up to 1 minute. Preloader is identified with Id by default value or step ActionValue
        /// </summary>
        public static string WaitForPreLoader = "waitforpreloader";
        public static string WaitUntilVisible = "waituntilvisible";
        public static string DictionaryCopy = "dictionarycopy";
        public static string NextTab = "nexttab";
    }
}
