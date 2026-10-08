using CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Datas;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Services;
using Microsoft.EntityFrameworkCore;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Data;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Data.Entities;

namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Services
{
    public class EventService : IEventService
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;

        public EventService(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<MethodResult> CreateEventAsync(EventModel model)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var eventEntity = new Event
                    {
                        Title = model.Title,
                        Date = model.Date,
                        Time = model.Time,
                        Venue = model.Venue,
                        Details = model.Details,
                        CreatedAt = DateTime.UtcNow
                    };

                    context.Events.Add(eventEntity);
                    await context.SaveChangesAsync();

                    return MethodResult.Ok();
                }
                catch (Exception ex)
                {
                    var innerException = ex.InnerException?.Message ?? ex.Message;
                    return MethodResult.Fail($"Error creating event: {innerException}");
                }
            }
        }
    }
}
