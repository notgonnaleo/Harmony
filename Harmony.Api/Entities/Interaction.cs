namespace Harmony.Api.Entities
{
    public class Interaction
    {
        public int UserId { get; set; }
        public int SongId { get; set; }
        public int InteractionTypeId { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public enum InteractionType
    {
        Like = 1,
        Repost = 2
    }
}
