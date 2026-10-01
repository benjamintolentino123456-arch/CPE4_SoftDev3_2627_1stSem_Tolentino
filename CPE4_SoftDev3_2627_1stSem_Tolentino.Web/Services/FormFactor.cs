using CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Services;

namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor()
        {
            return "Web";
        }

        public string GetPlatform()
        {
            return Environment.OSVersion.ToString();
        }
    }
}
