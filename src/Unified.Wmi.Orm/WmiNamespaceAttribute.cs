using System;

namespace Unified.Wmi.Orm
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class WmiNamespaceAttribute : Attribute
    {
        public string Name { get; set; }
        public WmiNamespaceAttribute(string name)
        {
            Name = name;
        }
    }
}
