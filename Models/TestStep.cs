namespace Models
{
    public class TestStep
    {

        // default constructor
        public TestStep()
        {

        }

        // inline
        public TestStep(string idby, string idvalue, string action, string actionvalue, string expectedresult)
        {
            IdBy = idby;
            IdValue = idvalue;
            Action = action;
            ActionValue = actionvalue;
            ExpectedResult = expectedresult;
        }

        /// <summary>
        /// used to call ActionNames.Screenshot with a filename
        /// </summary>
        /// <param name="action"></param>
        /// <param name="filename"></param>
        public TestStep(string action, string filename)
        {
            Action = action;
            FileName = filename;
        }

        public TestStep(string action)
        {
            Action = action;
        }

        // properties
        public string Element { get; set; }
        public string IdBy { get; set; }
        public string IdValue { get; set; }
        public string Action { get; set; }
        public string ActionValue { get; set; }
        public string ExpectedResult { get; set; }
        public string FileName { get; set; }
    }
}
