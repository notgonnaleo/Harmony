namespace Harmony.Api.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Duration { get; set; }
        public User Artist { get; set; }
        public List<Models.Interaction>? Likes { get; set; }
        public List<Models.Interaction>? Reposts { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
