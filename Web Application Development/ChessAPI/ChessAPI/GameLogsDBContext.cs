using Microsoft.EntityFrameworkCore;

namespace ChessAPI
{
    public class GameLogsDBContext : DbContext
    {
        public DbSet<GameLogs> GameLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = cis411group5projectserver.database.windows.net; Initial Catalog = CIS411Database; User ID = CIS411AppUser; Password = AppUserCIS411; TrustServerCertificate = True");
        }
    }
}
