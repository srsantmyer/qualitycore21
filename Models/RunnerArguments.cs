namespace Models
{
    public class RunnerArguments
    {
        public DatasourceType Source { get; set; }
        public string ConnectionString { get; set; }
        public string FileName { get; set; }
        public string SheetName { get; set; }
        public string ResultsFileName { get; set; }
        public string ResultsSheetName { get; set; }
        public DriverType DriverType { get; set; }
    }

    public enum DatasourceType
    {
        SQLServer,
        Excel
    }

    public enum DriverType
    {
        Firefox,
        Chrome
    };
}