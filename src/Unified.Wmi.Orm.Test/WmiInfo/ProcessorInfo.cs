namespace Unified.Wmi.Orm.WmiInfo
{
    [WmiNamespace("Win32_Processor")]
    public class ProcessorInfo
    {
        public string Name { get; set; }
        public int MaxClockSpeed { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public int NumberOfCores { get; set; }
        public int NumberOfLogicalProcessors { get; set; }
        public string SystemName { get; set; }
    }
}
