using System;

namespace Unified.Wmi.Orm.WmiInfo
{
    [WmiNamespace("Win32_UserAccount")]
    public class UserAccount
    {
        public Int32 AccountType { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public bool Disabled { get; set; }
        public string Domain { get; set; }
        public string FullName { get; set; }
        public DateTime InstallDate { get; set; }
        public bool LocalAccount { get; set; }
        public bool Lockout { get; set; }
        public string Name { get; set; }
        public bool PasswordChangeable { get; set; }
        public bool PasswordExpires { get; set; }
        public bool PasswordRequired { get; set; }
        public string SID { get; set; }
        public Byte SIDType { get; set; }
        public string Status { get; set; }
    }
}
