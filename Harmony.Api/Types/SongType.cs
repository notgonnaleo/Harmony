using Harmony.Api.Entities;

namespace Harmony.Api.Types
{
    public class SongType : ObjectType<Song>
    {
        protected override void Configure(IObjectTypeDescriptor<Song> descriptor)
        {
            descriptor.Field(u => u.Id)
                .Description("Song Unique Id");
            descriptor.Field(u => u.Title)
                .Description("Song Title Name");
        }
    }
}
