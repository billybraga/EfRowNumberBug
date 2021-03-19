using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EfRowNumberBug
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using (var dbContext = AppDbContextFactory.Create(args))
            {
                await dbContext.Database.MigrateAsync();
                await dbContext.SaveChangesAsync();
            }

            await using (var dbContext = AppDbContextFactory.Create(args))
            {
                await dbContext
                    .Parents
                    .Select(
                        x => new
                        {
                            Id = x.Id,
                            Organization = new
                            {
                                Id = x.OptionalChild!.Id,
                                Version = x.OptionalChild!.Version,
                            }
                        }
                    )
                    .ToArrayAsync();
            }
        }
    }
}