namespace Harmony.Api.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Duration { get; set; }
        public User? Artist { get; set; }
        public IEnumerable<string>? Tags { get; set; }
        public IEnumerable<Interaction> Likes { get; set; } = new List<Interaction>();
        public IEnumerable<Interaction> Reposts { get; set; } = new List<Interaction>();
        public DateTime CreatedAt { get; set; }
    }
}
