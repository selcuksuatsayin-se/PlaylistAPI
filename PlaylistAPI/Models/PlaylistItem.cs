﻿namespace PlaylistAPI.Models
{
    public class PlaylistItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string? Duration { get; set; }
    }
}
