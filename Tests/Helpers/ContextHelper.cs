using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Tests.Helpers
{
    public class ContextHelper
    {
        public static HolidaysContext GetContext()
        {
            CleanupContext();
            return NewContext();
        }

        public static HolidaysContext GetContext<T>(T entity)
        {
            CleanupContext();
            FillContext(entity);
            return NewContext();
        }

        private static void CleanupContext()
        {
            using (var context = NewContext())
            {
                context.Database.EnsureDeleted();
            }
        }

        private static void FillContext(dynamic dataSet)
        {
            var options = GetContextOptions();

            using (var context = new HolidaysContext(options))
            {
                context.AddRange(dataSet);
                context.SaveChanges();
            }
        }

        private static HolidaysContext NewContext()
        {
            var options = GetContextOptions();
            return new HolidaysContext(options);
        }

        private static DbContextOptions<HolidaysContext> GetContextOptions()
        {
            var options = new DbContextOptionsBuilder<HolidaysContext>().UseInMemoryDatabase("HOLIDAYS")
                .Options;

            return options;
        }

    }
}
