using System;

namespace Unified.Wmi.Orm.WmiInfo
{
    [WmiNamespace("Win32_OperatingSystem")]
    public class OperatingSystemInfo
    {
        public string[] MUILanguages { get; set; }
        public DateTime LastBootUpTime { get; set; }
        public int NumberOfProcesses { get; set; }
        public string Organization { get; set; }
        public string OSLanguage { get; set; }
        public int ServicePackMajorVersion { get; set; }
        public int ServicePackMinorVersion { get; set; }
        public string Version { get; set; }
        public string EncryptionLevel { get; set; }
        public int TotalVisibleMemorySize { get; set; }
    }
}
