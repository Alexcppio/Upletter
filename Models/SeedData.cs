using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Upletter.Models
{
    public static class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();
            if(context.Words.Count() == 0)
            {
                context.Words.AddRange(
                    new Word
                    {
                        Meaning = "Москва"
                    },
                    new Word
                    {
                        Meaning = "Екатеринбург"
                    });
                context.SaveChanges();
            }
        }
    }
}
