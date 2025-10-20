using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PlaylistAPI.Models
{
    public class PlaylistContext : DbContext
    {
        public PlaylistContext(DbContextOptions<PlaylistContext> options)
            : base(options)
        { }

        public DbSet<PlaylistItem> PlaylistItems { get; set; } = null!;
    }
}

