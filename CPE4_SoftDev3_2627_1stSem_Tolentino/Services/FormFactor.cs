using CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Services;

namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor()
        {
            return DeviceInfo.Idiom.ToString();
        }

        public string GetPlatform()
        {
            return DeviceInfo.Platform.ToString() + " - " + DeviceInfo.VersionString;
        }
    }
}
