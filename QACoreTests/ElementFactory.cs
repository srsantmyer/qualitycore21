using QaCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QACoreTests {
    public class ElementFactory {
        public static BaseElement Xpath(string value) {
            return new BaseElement() { IdBy = IdByValues.Xpath, IdValue = value };
        }

        public static BaseElement Id(string value) {
            return new BaseElement() { IdBy = IdByValues.Id, IdValue = value };
        }

        //todo: Make sure I work!?
        public static BaseElement Name(string value)
        {
            return new BaseElement() { IdBy = IdByValues.Name, IdValue = value };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">can be a set value or update this.IdValue at runtime</param>
        /// <returns></returns>
        public static BaseElement LinkText(string value) {
            return new BaseElement() { IdBy = IdByValues.LinkText, IdValue = value };
        }
    }
}
