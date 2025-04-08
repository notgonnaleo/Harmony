using Harmony.Api.Entities;
using Harmony.Api.Resolvers;

namespace Harmony.Api.Types
{
    public class SongType : ObjectType<Song>
    {
        protected override void Configure(IObjectTypeDescriptor<Song> descriptor)
        {
            descriptor.Field(u => u.Id);
            descriptor.Field(u => u.Title);
        }
    }
}
