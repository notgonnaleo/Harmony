namespace Harmony.Api.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? EmailAddress { get; set; }
        public string? DisplayName { get; set; }
        public bool Verified { get; set; }
        public int Followers { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
