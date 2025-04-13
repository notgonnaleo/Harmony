namespace Harmony.Api.Types
{
    public class SongType : ObjectType<Models.Song>
    {
        protected override void Configure(IObjectTypeDescriptor<Models.Song> descriptor)
        {
            descriptor.Name("SongType");

            descriptor.Field(u => u.Id)
                .Description("Song unique id");
            descriptor.Field(u => u.Title)
                .Description("Song title name");
            descriptor.Field(u => u.Duration)
                .Description("Song time duration in seconds");
            descriptor.Field(u => u.Likes)
                .Description("Song total amount of likes");
            descriptor.Field(u => u.Reposts)
                .Description("Song total amount of reposts");
            descriptor.Field(u => u.Artist)
                .Description("Song artist");
            descriptor.Field(u => u.CreatedAt)
                .Description("Song creation datetime");
            descriptor.Field(u => u.ModifiedAt)
                .Description("Song last modification datetime");
        }
    }
}
