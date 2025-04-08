using Harmony.Api.Entities;
using Harmony.Api.Resolvers;

namespace Harmony.Api.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(u => u.Id);
            descriptor.Field(u => u.Username);

            descriptor
                .Field("totalLikesGiven")
                .ResolveWith<UserResolver>(r => r.GetTotalLikesGivenAsync(default!))
                .Type<IntType>();

            descriptor
                .Field("uploadedSongs")
                .ResolveWith<UserResolver>(r => r.GetUserUploadedSongs(default!))
                .Type<ListType<SongType>>();
        }
    }
}
