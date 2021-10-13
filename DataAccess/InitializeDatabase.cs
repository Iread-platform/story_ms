using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using iread_story.DataAccess.Data;
using System.Globalization;
using iread_story.DataAccess.Data.Entity;

namespace iread_identity_ms.DataAccess.Data
{
    public class InitializeDatabase
    {
        public static async Task Run(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var applicationDbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                applicationDbContext.Database.Migrate();

                if (!applicationDbContext.Languages.Any())
                {
                    int index = 0;
                    applicationDbContext.Languages.AddRange(

                        CultureInfo.GetCultures(CultureTypes.NeutralCultures).ToList()
                        .ConvertAll<Language>((CultureInfo c) =>
                    {
                        index += 1;
                        return new Language()
                        {
                            Name = c.EnglishName,
                            Code = c.TwoLetterISOLanguageName,
                            LanguageId = index
                        };
                    }));

                    applicationDbContext.SaveChanges();
                }
            }
        }
    }
}