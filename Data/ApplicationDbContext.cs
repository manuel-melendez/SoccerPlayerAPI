
using Microsoft.EntityFrameworkCore;
using SoccerPlayerAPI.Models;

namespace SoccerPlayerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<SoccerPlayer> Players { get; set; }
    }
}
