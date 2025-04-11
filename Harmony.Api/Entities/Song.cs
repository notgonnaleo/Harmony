namespace Harmony.Api.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Duration { get; set; }
        public int ArtistId { get; set; }
        public int Likes { get; set; }
        public int Reposts { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
