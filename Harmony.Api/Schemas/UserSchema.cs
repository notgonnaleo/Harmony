using Harmony.Api.Entities;
using Harmony.Api.Resolvers;

namespace Harmony.Api.Schemas
{
    public class UserSchema : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(u => u.Id);
            descriptor.Field(u => u.Username);

            descriptor
                .Field("getUserLikedSongs")
                .ResolveWith<UserResolver>(r => r.GetUserLikedSongs(default!))
                .Type<ListType<SongSchema>>();

            descriptor
                .Field("uploadedSongs")
                .ResolveWith<UserResolver>(r => r.GetUserUploadedSongs(default!))
                .Type<ListType<SongSchema>>();
        }
    }
}
