namespace Unified.Wmi.Orm.WmiInfo
{
    [WmiNamespace("Win32_SystemEnclosure")]
    public class SystemEnclosure
    {
        public string SerialNumber { get; set; }
    }
}
