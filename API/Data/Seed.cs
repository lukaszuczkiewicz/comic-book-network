using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();

                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("pAsSwOrD"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedComicSeries(DataContext context)
        {
            //return if there are already some comic series in db
            if (await context.ComicSeries.AnyAsync()) return;

            var comicSeriesData = await System.IO.File.ReadAllTextAsync("Data/ComicSeriesSeedData.json");
            var comicSeries = JsonSerializer.Deserialize<List<ComicSeries>>(comicSeriesData);
            foreach (var cs in comicSeries)
            {
                context.ComicSeries.Add(cs);
            }

            await context.SaveChangesAsync();
        }
    }
}
