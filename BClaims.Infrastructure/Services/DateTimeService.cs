using BClaims.Application.Common.Interfaces;

namespace BClaims.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
