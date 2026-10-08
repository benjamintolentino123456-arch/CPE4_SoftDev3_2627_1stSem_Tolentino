using CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Datas;

namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Services
{
    public interface IEventService
    {
        Task<MethodResult> CreateEventAsync(EventModel model);
    }
}
