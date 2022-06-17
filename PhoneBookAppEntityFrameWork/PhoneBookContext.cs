using Microsoft.EntityFrameworkCore;
using PhoneBookAppEntityFrameWork.Models;
using Microsoft.Extensions.Configuration;

namespace PhoneBookAppEntityFrameWork
{
    public class PhoneBookContext : DbContext
    {
        //this creats the table "Contacts"
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        }
    }
}
