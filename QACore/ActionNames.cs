using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaCore {
    public static class ActionNames {
        public static readonly string Clear = "clear";
        /// <summary>
        /// Click the element identified by IdBy and IdValue
        /// </summary>
        public readonly static string Click = "click";
        /// <summary>
        /// Set the cursor over an element and click there
        /// </summary>
        public static readonly string ClickLocation = "clicklocation";
        /// <summary>
        /// Click a location and send a down arrow composite step
        /// </summary>
        public static readonly string ClickLocationAndSendDown = "clicklocationandsenddown";
        /// <summary>
        /// click a location and send a backspace
        /// </summary>
        public static readonly string ClickLocationAndSendBackSpace = "clicklocationandsendbackspace";
        /// <summary>
        /// get an array of elements and click ActionValue number of them
        /// </summary>
        public static readonly string ClickXLocationsInArray = "clickxlocationsinarray";

        public static readonly string Close = "close";
        public static readonly string DropDownSelectBy = "dropdownselectbytext";
        public static readonly string DropDownGetSelectedOption = "dropdowngetselectedoption";
        public static readonly string Execute = "execute";
        /// <summary>
        /// execute a javascript command, the ActionValue, Expected result being the array location of the element
        /// </summary>
        public static readonly string ExecuteJs = "executejs";
        /// <summary>
        /// Find the element on the page by IdBy and IdValue
        /// </summary>
        public static readonly string Find = "find";
        /// <summary>
        /// This element should NOT be found
        /// </summary>
        public static readonly string FindNot = "findnot";
        /// <summary>
        /// true / false IS this element found?
        /// </summary>
        public static readonly string FindSafe = "findsafe";
        /// <summary>
        /// Is the element found and visible
        /// </summary>
        public static readonly string IsVisible = "isvisible";
        /// <summary>
        /// is the element found and NOT visible
        /// </summary>
        public static readonly string IsNotVisible = "isnotvisible";
        public static readonly string FindTextOnPage = "findtextonpage";
        /// <summary>
        /// Match the title of the current web page with the ActionValue
        /// </summary>
        public static readonly string GetTitle = "gettitle";
        public static readonly string Navigate = "navigate";
        public static readonly string Read = "read";
        public static readonly string ScreenShot = "screenshot";
        public static readonly string SendKey = "sendkey";
        /// <summary>
        /// Send ActionValue text to the element identified by IdBy and IdValue
        /// </summary>
        public static readonly string SendText = "sendtext";
        public static readonly string ValueCopy = "valuecopy";
        public static readonly string ValueSave = "valuesave";
        public static readonly string ValuePaste = "valuepaste";
        public static readonly string Wait = "wait";
        /// <summary>
        /// Wait for the preloader (spinner) to go away for up to 1 minute. Preloader is identified with Id by default value or step ActionValue
        /// </summary>
        public static readonly string WaitForPreLoader = "waitforpreloader";
        public static readonly string WaitUntilVisible = "waituntilvisible";
        public static readonly string DictionaryCopy = "dictionarycopy";
        public static readonly string NextTab = "nexttab";
    }
}
