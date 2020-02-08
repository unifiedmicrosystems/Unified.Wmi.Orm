using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unified.Wmi.Orm.WmiInfo;

namespace Unified.Wmi.Orm.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void can_query()
        {
            var userInfo = WmiInfoMapper.GetWmiInfo<UserAccount>();
            var osInfo = WmiInfoMapper.GetWmiInfo<OperatingSystemInfo>();
            var cpuInfo = WmiInfoMapper.GetWmiInfo<ProcessorInfo>();
            var enclosureInfo = WmiInfoMapper.GetWmiInfo<SystemEnclosure>();
        }
    }
}
