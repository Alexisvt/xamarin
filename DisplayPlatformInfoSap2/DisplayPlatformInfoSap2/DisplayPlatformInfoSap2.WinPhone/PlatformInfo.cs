using Microsoft.Phone.Info;
using System;


namespace DisplayPlatformInfoSap2
{
    public class PlatformInfo
    {
        public string GetModel()
        {
            return String.Format("{0} {1}", DeviceStatus.DeviceManufacturer, DeviceStatus.DeviceName);
        }

        public string GetVersion()
        {
            return Environment.OSVersion.ToString();
        }
    }
}
